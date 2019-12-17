using MXGP.Repositories.Contracts;
using System.Collections.Generic;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected List<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll() => this.models.AsReadOnly();

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
