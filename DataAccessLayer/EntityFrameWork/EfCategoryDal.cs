using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstruct;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concrate;

namespace DataAccessLayer.EntityFrameWork
{
    public class EfCategoryDal : GenericRepositoryDal<Category>, ICategoryDal
    {
        public EfCategoryDal(GaziFurContext context) : base(context)
        {
        }
    }
}
