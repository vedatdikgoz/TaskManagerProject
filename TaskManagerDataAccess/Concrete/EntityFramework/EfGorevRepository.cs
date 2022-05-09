

using TaskManagerCore.DataAccess.EntityFramework;
using TaskManagerDataAccess.Abstract;
using TaskManagerDataAccess.Concrete.Context;
using TaskManagerEntities.Concrete;

namespace TaskManagerDataAccess.Concrete.EntityFramework
{
    public class EfGorevRepository : EfEntityRepositoryBase<Gorev, DataContext>, IGorevRepository
    {
       
    }
}
