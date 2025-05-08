using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstruct;
using DataAccessLayer.Context;

namespace DataAccessLayer.Repository
{
    public class GenericRepositoryDal<T> : IGenericDal<T> where T : class
    {
        private readonly GaziFurContext _context;

        public GenericRepositoryDal(GaziFurContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(int id)
        {
            var values = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(values);   
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
