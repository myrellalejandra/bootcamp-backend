using Bootcamp.Model;
using Bootcamp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Queries.Person
{
    public interface IPersonQueries
    {
        Task<IEnumerable<PersonViewModel>> Read();
        Task<PersonByIdViewModel> GetById(int id);
        /*Task<int> Create(Model.Person person);
        Task<int> Update(Model.Person person);
        Task<int> Delete(Model.Person person);*/

    }
}
