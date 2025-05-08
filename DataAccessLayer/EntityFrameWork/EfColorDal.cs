using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstruct;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concrate;
using Color = EntityLayer.Concrate.Color;

namespace DataAccessLayer.EntityFrameWork
{
    public class EfColorDal : GenericRepositoryDal<Color>, IColorDal
    {
        public EfColorDal(GaziFurContext context) : base(context)
        {
        }
    }
}
