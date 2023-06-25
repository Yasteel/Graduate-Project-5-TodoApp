namespace Todo.Api.Interfaces
{
    public interface IGenericService<T>
        where T : class
    {
        Task<List<T>> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);

        //T? FindByField(string fieldName, object value);

        //List<T> FindAllByField(string fieldName, object value);
    }
}
