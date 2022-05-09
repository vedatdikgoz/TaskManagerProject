using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerBusiness.Abstract;

using TaskManagerDataAccess.Abstract;
using TaskManagerEntities.Concrete;

namespace TaskManagerBusiness.Concrete
{
    public class GorevManager : IGorevService
    {
        private IGorevRepository _gorevRepository;
        public GorevManager(IGorevRepository gorevRepository)
        {
            _gorevRepository= gorevRepository;
        }

        public void Add(Gorev gorev)
        {
            _gorevRepository.Add(gorev);
            
        }

        public void Delete(Gorev gorev)
        {
            _gorevRepository.Delete(gorev);
        }

        public List<Gorev> GetAll()
        {
            return _gorevRepository.GetAll();
        }

       

        public Gorev GetById(int gorevId)
        {
            return _gorevRepository.Get(g=>g.Id==gorevId);
        }

       

        public void Update(Gorev gorev)
        {
            _gorevRepository.Update(gorev);
        }
    }
}
