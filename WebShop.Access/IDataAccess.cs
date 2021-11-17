using System;
using System.Collections.Generic;

namespace WebShop.Access
{
    public interface IDataAccess<T>
    {
        public IEnumerable<T> LoadAll();
        public T Update(T _object);
        public T LoadById(int i);
        public void Save(T _object);
        public void Delete(T _object);
    }
}
