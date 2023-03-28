using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aca_Marcinelle_Backend.DAL.Interfaces
{
    public interface IGenericRepository<T>
        where T: class
    {
        public IEnumerable<T> GetAll();
        public T? GetById(int id);
        public bool Create(T form);
        public bool Update(T form);
        public bool Delete(int id);
    }
}
