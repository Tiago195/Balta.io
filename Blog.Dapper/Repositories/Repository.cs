using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class Repository<T> where T : class
{
  readonly protected SqlConnection _connection;

  public Repository(SqlConnection connection)
  {
    _connection = connection;
  }

  public IEnumerable<T> Get() => _connection.GetAll<T>();

  public T Get(int id) => _connection.Get<T>(id);

  public void Create(T entity) => _connection.Insert(entity);

  public void Update(T entity)
  {
    if (entity is not null) _connection.Update<T>(entity);
  }

  public void Delete(T entity)
  {
    if (entity is not null) _connection.Delete(entity);
  }
  public void Delete(int id)
  {
    if (id is 0) return;

    var entity = _connection.Get<T>(id);
    _connection.Delete(entity);
  }
}