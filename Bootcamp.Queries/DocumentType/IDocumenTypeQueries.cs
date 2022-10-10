using Bootcamp.ViewModel;

namespace Bootcamp.Queries.DocumentType
{
    public interface IDocumenTypeQueries
    {
        Task<IEnumerable<DocumentTypeViewModel>> GetAll();
    }
}
