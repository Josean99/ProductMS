using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.WebApiServices.Results
{
    public class Result<T>
    {
        public List<string> ErrorMessages { get; set; } = new();
        public List<string> InfoMessages { get; set; } = new();
        public T Data { get; set; }
        public bool Success { get; set; }

        public Result<T> Ok(T data)
        {
            var result = new Result<T>()
            {
                Data = data,
                Success = true,
            };
            return result;
        }

        public Result<T> Ok(T data, List<string> infos)
        {
            var result = new Result<T>()
            {
                Data = data,
                Success = true,
            };
            result.AddInfoMessages(infos);
            return result;
        }

        public Result<T> Fail(T data, List<string> errors)
        {
            var result = new Result<T>()
            {
                Data = data,
                Success = false,
                ErrorMessages = errors
            };
            return result;
        }

        public Result<T> Fail(T data, string error)
        {
            var result = new Result<T>()
            {
                Data = data,
                Success = false
            };
            result.AddError(error);
            return result;
        }

        public void AddError(string error)
        {
            ErrorMessages.Add(error);
        }

        public void AddErrors(IEnumerable<string> errors)
        {
            ErrorMessages.AddRange(errors);
        }

        public void AddInfoMessage(string info)
        {
            InfoMessages.Add(info);
        }

        public void AddInfoMessages(IEnumerable<string> infos)
        {
            InfoMessages.AddRange(infos);
        }


    }
}
