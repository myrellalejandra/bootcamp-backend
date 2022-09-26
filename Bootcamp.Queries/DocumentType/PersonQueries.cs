using Bootcamp.Model;
using Bootcamp.ViewModel;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Queries.DocumentType
{
    public class PersonQueries : IPersonQueries
    {
        /*
        snippet ctor para crear el constructor
        IConfiguration , es una interfaz para las variables?
        obtiene la configuration de la web
        using , termina de ejecutarse y se elimina de la memoria para mejorar el performance         
        */

        private readonly string _connectionString;
        // inyectando la interface
        public PersonQueries(IConfiguration configuration)
        {

            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<int> Create(Person person)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Name", person.Name);
            parameters.Add("@LastName", person.LastName);
            parameters.Add("@DocumentTypeId", person.DocumentTypeId);
            parameters.Add("@DocumentNumber", person.DocumentNumber);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Ins_Person]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;

        }

        public async Task<IEnumerable<Person>> Read()
        {
            IEnumerable<PersonViewModel> result = new List<PersonViewModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<PersonViewModel>("[dbo].[Usp_Read_Person]", commandType: System.Data.CommandType.StoredProcedure);
            }
            return (IEnumerable<Person>)result;
        }

        public async Task<int> Update(Person person)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", person.Id);
            parameters.Add("@Name", person.Name);
            parameters.Add("@LastName", person.LastName);
            parameters.Add("@DocumentTypeId", person.DocumentTypeId);
            parameters.Add("@DocumentNumber", person.DocumentNumber);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Upd_Person]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;

        }

        public async Task<int> Delete(Person person)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", person.Id);
            
            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Dlt_Person]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }
      
    }
}
