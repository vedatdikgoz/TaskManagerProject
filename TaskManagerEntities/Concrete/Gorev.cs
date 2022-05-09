
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCore.Entities;

namespace TaskManagerEntities.Concrete
{
    public class Gorev:IEntity
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }      
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ExpiredDate { get; set; }
    }
}
