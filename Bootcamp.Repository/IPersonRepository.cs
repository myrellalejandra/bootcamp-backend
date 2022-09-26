using Bootcamp.Model;

namespace Bootcamp.Repository
{
    public interface IPersonRepository
    {   
        /*Retorna una lista*/
        Task<int> Create(Person person);
        Task<IEnumerable<Person>> Read();
        Task<int> Update(Person person);
        Task<int> Delete(Person person);
    }
}