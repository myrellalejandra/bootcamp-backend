using Bootcamp.Model;
using Bootcamp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Queries.DocumentType
{
    public interface IPersonQueries
    {
        Task<int> Create(Person person);
        Task<IEnumerable<Person>> Read();
        Task<int> Update(Person person);
        Task<int> Delete(Person person);

    }
}
