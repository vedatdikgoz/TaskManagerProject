using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCore.DataAccess;
using TaskManagerEntities.Concrete;

namespace TaskManagerDataAccess.Abstract
{
    public interface IGorevRepository : IEntityRepository<Gorev>
    {
       
    }
}
