using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IService<T>
    {
        List<T> GetAll();
        string Output();
        T Get(int i);
    }
}
