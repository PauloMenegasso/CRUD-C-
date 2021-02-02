using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_De_Series.Interfaces
{
    interface IRepository<T>
    {
        List<T> List();
        T ReturnById(int id);
        void Insert(T entity);
        void Exclude(int id);
        void Update(int id, T entity);
        int NextId();
    }
}
