using EntityService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IReadBusinessLayer.Base
{
    public interface IBaseWriteService
    {
        Task<TT> Create<T, TT>(TT dto) where T : class where TT : class;
        Task<TT> SoftDelete<T, TT>(TT dto) where T : class where TT : class;
        Task<TT> Update<T, TT>(TT dto) where T : BaseEntity where TT : class;
        Task<TT> Delete<T, TT>(TT dto) where T : BaseEntity where TT : class;
    }
}
