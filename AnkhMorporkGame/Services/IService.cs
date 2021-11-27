using System.Collections.Generic;

namespace AnkhMorporkGame.Services
{
    public interface IService<T>
    {
        List<T> GetAll();
        string Output();
        T Get(int i);
    }
}
