namespace RefitDemo.API.Models
{
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /* ******************************************************************************************* 
    * ORIGINAL SOURCE: 
    * https://github.com/reactiveui/refit
    * 
    * USAGE:
    * var api = RestService.For<IGenericCrudApi<User, string>>("http://api.example.com/users");
    * 
    * NOTE:
    * Since constant string interpolation is not possible at this time (Mayb in C# 10),
    * we can do something like this -> [Get("{nameof(T)}s/\{key\}")]
    * *******************************************************************************************/
    public interface IGenericCrudApi<T, in TKey> where T : class
    {        
        [Get("")]
        Task<List<T>> GetAll();

        [Get("/{id}")]
        Task<T> GetById(TKey id);

        [Post("")]
        Task<T> Create([Body] T payload);

        [Put("/{id}")]
        Task Update(TKey id, [Body] T payload);

        [Delete("/{id}")]
        Task Delete(TKey id);
    }
}
