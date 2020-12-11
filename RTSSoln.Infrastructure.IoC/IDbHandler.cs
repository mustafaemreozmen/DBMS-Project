using RTSSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Infrastructure.IoC
{
    public interface IDbHandler<T> where T: BaseEntity
    {
        List<T> Select();
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid entity);

    }
}
