﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstruct
{
    public interface IGenericDal<T> where T : class
    {
        void Add(T entity);
        void Remove(int id);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();
    }

}
