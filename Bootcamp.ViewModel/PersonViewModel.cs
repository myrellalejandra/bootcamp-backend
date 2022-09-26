using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.ViewModel
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public String LastName { get; set; }
        public int DocumentTypeId { get; set; }
        public String DocumentNumber { get; set; }

    }
}
