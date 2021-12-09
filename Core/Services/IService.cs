using System.Collections.Generic;

namespace Core.Services
{
    public interface IService<T>
    {
        List<T> GetAll();
        string Output();
        T Get(int i);
    }
}
