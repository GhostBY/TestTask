﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IService<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);

        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
