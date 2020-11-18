using System.Collections.Generic;

namespace Logic.DAL
{
    public interface IDataAccess<T>
    {
        public List<T> Load();

        public void Save(T entity);

        public void Save(List<T> entities);
    }
}
