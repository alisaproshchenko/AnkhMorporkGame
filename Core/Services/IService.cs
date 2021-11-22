using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IService<T>
    {
        public List<T> GetAll();
        public string Output();
    }
}
