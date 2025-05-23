﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstruct
{
    public interface IGenericService<T> where T : class
    {
        void TAdd(T entity);
        void TRemove(int id);
        void TUpdate(T entity);
        List<T> TGetAll();
        T TGetById(int id);
    }
}
