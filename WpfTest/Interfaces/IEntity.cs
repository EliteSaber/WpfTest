﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfTest.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }
    }
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Items { get; }
        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken cancel = default);
        T Add(T item);
        Task<T> AddAsync(T item, CancellationToken cancel = default);
        void Update(T item);
        Task UpdateAsync(T item, CancellationToken cancel = default);
        void Remove(int id);
        Task RemoveAsync(int id, CancellationToken cancel = default);
        int SaveChanges();
    }
}
