using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoisonIvy.CatalogApi.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> Get();
        Task<string> Upsert(T data);
    }
}
