using AutoMapper;
using EntityService.Model;
using IWriteBusinessLayer;
using IReadRepositories;
using IWriteRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using IWriteRepository.Base;
using IReadRepositories.Base;
using ReadRepositories.Base;
using DTOs.RequestDTOs;
using Infrastructure.WebApiServices.Results;

namespace WriteBusinessLayer
{
    public class ProductsWriteService : IProductsWriteService
    {
        private readonly IBaseWriteRepository<Product> _productWriteRepository;
        private readonly IBaseWriteRepository<ProductImage> _productImageWriteRepository;
        private readonly IBaseWriteRepository<Image> _imageWriteRepository;
        private readonly IBaseReadRepository _baseReadRepository;
        private readonly IMapper _mapper;
        public ProductsWriteService(
                                IBaseWriteRepository<Product> productWriteRepository,
                                IBaseWriteRepository<ProductImage> productImageWriteRepository,
                                IBaseWriteRepository<Image> imageWriteRepository,
                                IBaseReadRepository baseReadRepository,
                                IMapper mapper)
        {
            _productWriteRepository = productWriteRepository;
            _productImageWriteRepository = productImageWriteRepository;
            _imageWriteRepository = imageWriteRepository;
            _baseReadRepository = baseReadRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProductRequestDTO>> Create(ProductRequestDTO dto)
        {
            Product entity = _mapper.Map<ProductRequestDTO, Product>(dto);
            await _productWriteRepository.Create(entity);
            await _productWriteRepository.Save();
            await _productWriteRepository.Detached(entity);
            ProductRequestDTO result = _mapper.Map<Product, ProductRequestDTO>(entity);
            return new Result<ProductRequestDTO>().Ok(result);
        }

        public async Task<Result<ProductWithImagesRequestDTO>> CreateProductWithImages(ProductWithImagesRequestDTO productWithImagesDTO)
        {
            Result<ProductWithImagesRequestDTO> result = null;
            using (IDbContextTransaction transaction = _productWriteRepository.GetUnitOfWork().Result.GetTransaction())
            {
                try
                {
                    Product product = _mapper.Map<ProductWithImagesRequestDTO, Product>(productWithImagesDTO);
                    await _productWriteRepository.Create(product);
                    var dtoCreated = _mapper.Map<Product, ProductWithImagesRequestDTO>(product);
                    result = new Result<ProductWithImagesRequestDTO>().Ok(dtoCreated);                    

                    //List<ProductImage> productImages = _mapper.Map<List<ProductImageRequestDTO>, List<ProductImage>>(productWithImagesDTO.ProductImages);

                    //List<Task> taskList = new List<Task>();
                    //productImages.Select(pi => pi.Image).Where(i => i is not null).ToList().ForEach(i => taskList.Add(_imageWriteRepository.Create(i)));

                    //Task.WaitAll(taskList.ToArray());
                    //taskList.Clear();

                    //var priority = 1;
                    //foreach (ProductImage productImage in productImages)
                    //{
                    //    var imageId = productImage.Image is null ? productImage.IdImage : productImage.Image.Id;
                    //    taskList.Add(_productImageWriteRepository.Create(new ProductImage() { IdImage = imageId, IdProduct = product.Id, Priority = priority }));
                    //    priority++;
                    //}
                    //Task.WaitAll(taskList.ToArray());
                    result.AddInfoMessage($"Product with Id [{product.Id}] Created");
                    await _productWriteRepository.Save();
                    await _productWriteRepository.Detached(product);
                    transaction.Commit();
                    result.AddInfoMessage($"Commit done");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return result.Fail(productWithImagesDTO, e.Message);
                }
            }
            return result;
        }

        public async Task<Result<ProductRequestDTO>> Update(ProductRequestDTO dto)
        {
            Product entity = _mapper.Map<ProductRequestDTO, Product>(dto);
            entity.FechaBaja = DateTime.Now;
            await _productWriteRepository.Update(entity);
            await _productWriteRepository.Save();
            await _productWriteRepository.Detached(entity);
            ProductRequestDTO result = _mapper.Map<Product, ProductRequestDTO>(entity);
            return new Result<ProductRequestDTO>().Ok(dto);
        }

        public async Task<Result<ProductWithImagesRequestDTO>> UpdateProductWithImages(ProductWithImagesRequestDTO productWithImagesDTO)
        {
            var result = new Result<ProductWithImagesRequestDTO>().Ok(productWithImagesDTO);
            using (IDbContextTransaction transaction = _productWriteRepository.GetUnitOfWork().Result.GetTransaction())
            {
                try
                {
                    Product product = await _baseReadRepository.GetFirstByCondition<Product>(p => p.Id == productWithImagesDTO.Id, p=>p.ProductImages);
                    IQueryable<ProductImage> currentProductImages = await _baseReadRepository.GetByCondition<ProductImage>(pi => pi.IdProduct == product.Id); //ProductImages actuales del producto
                    List<ProductImage> currentProductImagesDown = currentProductImages.ToList().Where(pi => pi.FechaBaja == null).Where(i => productWithImagesDTO.ProductImages.Where(pi2 => pi2.FechaBaja != null).Select(pi => pi.Id).Contains(i.Id)).ToList(); //ProductImages a dar de baja
                    List<ProductImage> currentProductImagesUp = currentProductImages.ToList().Where(pi => pi.FechaBaja != null).Where(i => productWithImagesDTO.ProductImages.Where(pi2 => pi2.FechaBaja == null).Select(pi => pi.Id).Contains(i.Id)).ToList(); //ProductImages a dar de alta
                    List<ProductImageRequestDTO> productImagesDTOToCreate = productWithImagesDTO.ProductImages.Where(i => i.Id == null).ToList(); //ProductImages a crear

                    var taskList = new List<Task>();
                    foreach (ProductImage productImageToDown in currentProductImagesDown)
                    {
                        taskList.Add(_productImageWriteRepository.Update(productImageToDown));
                    }

                    foreach (ProductImage productImageToUp in currentProductImagesUp)
                    {
                        productImageToUp.FechaBaja = null;
                        taskList.Add(_productImageWriteRepository.Update(productImageToUp));
                    }

                    foreach (ProductImageRequestDTO productImageDTOToCreate in productImagesDTOToCreate)
                    {
                        ProductImage productImageToCreate = _mapper.Map<ProductImageRequestDTO, ProductImage>(productImageDTOToCreate);
                        taskList.Add(_productImageWriteRepository.Create(productImageToCreate));
                    }
                    
                    Task.WaitAll(taskList.ToArray());
                    result.AddInfoMessage($"{currentProductImagesDown.Count()} Associations to Down completed");
                    result.AddInfoMessage($"{currentProductImagesUp.Count()} Associations to Up completed");
                    result.AddInfoMessage($"{productImagesDTOToCreate.Count()} Associations to Create completed");

                    //Product productToModify = _mapper.Map<ProductWithImagesRequestDTO, Product>(productWithImagesDTO);
                    product.ProductImages = null;
                    await _productWriteRepository.Update(product);
                    result.AddInfoMessage($"Product with Id [{product.Id}] Updated");

                    await _productWriteRepository.Save();
                    await _productWriteRepository.Detached(product);
                    currentProductImages.ToList().ForEach(x=> _productImageWriteRepository.Detached(x));
                    transaction.Commit();
                    result.AddInfoMessage($"Commit done");

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return result.Fail(productWithImagesDTO, e.Message);
                }
            }
            return result;
        }

        public async Task<Result<ProductRequestDTO>> SoftDelete(Guid id)
        {
            Product entity = await _baseReadRepository.GetFirstByCondition<Product>(p=>p.Id == id);
            entity.FechaBaja = DateTime.Now;
            await _productWriteRepository.Update(entity);
            await _productWriteRepository.Save();
            await _productWriteRepository.Detached(entity);
            ProductRequestDTO result = _mapper.Map<Product, ProductRequestDTO>(entity);
            return new Result<ProductRequestDTO>().Ok(result);
        }

        public async Task<Result<Guid>> SoftDeleteWithImages(Guid id)
        {
            var result = new Result<Guid>().Ok(id);
            using (IDbContextTransaction transaction = _productWriteRepository.GetUnitOfWork().Result.GetTransaction())
            {
                try
                {
                    var taskList = new List<Task>();
                    Product entity = await _baseReadRepository.GetFirstByCondition<Product>(p => p.Id == id);
                    entity.FechaBaja = DateTime.Now;
                    taskList.Add(_productWriteRepository.Update(entity));

                    List<ProductImage> productImages = await _baseReadRepository.GetByCondition<ProductImage>(i => i.IdProduct == id).Result.ToListAsync();
                    foreach (ProductImage productImage in productImages)
                    {
                        productImage.FechaBaja = DateTime.Now;
                        taskList.Add(_productImageWriteRepository.Update(productImage));
                    }

                    Task.WaitAll(taskList.ToArray());
                    result.AddInfoMessage($"Product With Id [{id}] SoftDeleted");
                    result.AddInfoMessage($"{productImages.Count()} ProductImages SoftDeleted");

                    await _productWriteRepository.Save();
                    transaction.Commit();
                    result.AddInfoMessage($"Commit done");

                    return result;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return result.Fail(id, e.Message);
                }
            }
        }

        public async Task<Result<Guid>> Delete(Guid id)
        {
            Product entity = await _baseReadRepository.GetFirstByCondition<Product>(p => p.Id == id);
            await _productWriteRepository.Delete(entity);
            await _productWriteRepository.Save();
            await _productWriteRepository.Detached(entity);
            return new Result<Guid>().Ok(id);
        }

    }
}