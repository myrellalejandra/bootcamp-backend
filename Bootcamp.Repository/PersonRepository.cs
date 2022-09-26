using Bootcamp.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using Bootcamp.ViewModel;

namespace Bootcamp.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _connectionString;

        public PersonRepository(IConfiguration configuration) 
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
            return result;
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
