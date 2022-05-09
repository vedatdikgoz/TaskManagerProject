
using TaskManagerEntities.Concrete;

namespace TaskManagerBusiness.Abstract
{
    public interface IGorevService
    {
        List<Gorev> GetAll();      
        Gorev GetById(int gorevId);
        void Add(Gorev gorev);
        void Update(Gorev gorev);
        void Delete(Gorev gorev);
    
    }
}
