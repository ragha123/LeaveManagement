using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement
{
    public interface IRepositoryBase<T> where T : class
    {
        ICollection<T> FindAll();
       
    }
}
