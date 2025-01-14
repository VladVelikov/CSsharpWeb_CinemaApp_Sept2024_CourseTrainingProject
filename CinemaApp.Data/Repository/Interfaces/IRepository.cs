﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Repository.Interfaces
{
    public interface IRepository<TType, TId>
    {
        TType GetById(TId id);

        Task<TType> GetByIdAsync(TId id);

        IEnumerable<TType> GetAll();    

        Task<IEnumerable<TType>> GetAllAsync();

        IQueryable<TType> GetAllAttached();

        void Add(TType item); 
        
        Task AddSync(TType item);   

        bool Update(TType item);

        Task<bool> UpdateAsync(TType item);

        bool Delete(TId id);    

        Task<bool> DeleteAsync(TId id);


    }


}
