using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidaSana.API.Application.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {

        Task<T> FindAsync(string objectId);

        void Add(T objectToInsert);

        void Update(T objectToUpdate);

        void Delete(string objectId);

    }
}
