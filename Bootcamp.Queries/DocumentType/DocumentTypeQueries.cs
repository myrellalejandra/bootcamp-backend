using Bootcamp.ViewModel;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Queries.DocumentType{
    public class DocumentTypeQueries : IDocumentTypeQueries{
        /*
        snippet ctor para crear el constructor
        IConfiguration , es una interfaz para las variables?
        obtiene la configuration de la web
        using , termina de ejecutarse y se elimina de la memoria para mejorar el performance         
        */

        private readonly string _connectionString;    
        // inyectando la interface
        public DocumentTypeQueries(IConfiguration configuration)
        {
           
            _connectionString = configuration["ConnectionStrings:SQL"];
        }
        public async Task<IEnumerable<DocumentTypeViewModel>> GetAll()
        {

            IEnumerable<DocumentTypeViewModel> result = new List<DocumentTypeViewModel>();
            
            using (var connection = new SqlConnection(_connectionString)) 
            {
                result = await connection.QueryAsync<DocumentTypeViewModel>("[dbo].[Usp_Sel_DocumentType]", commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
