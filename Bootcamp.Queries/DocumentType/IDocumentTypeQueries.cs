using Bootcamp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Queries.DocumentType
{
    public interface IDocumentTypeQueries
    {
        //metodo asincrono que va devolver una lista del objeto DocumentTypeViewModel
        Task<IEnumerable<DocumentTypeViewModel>> GetAll();
    }
}
