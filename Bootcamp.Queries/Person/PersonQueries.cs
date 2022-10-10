using Bootcamp.Model;
using Bootcamp.ViewModel;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Queries.Person
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

        public async Task<PersonByIdViewModel> GetById(int id)
        {
            var result = new PersonByIdViewModel();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryFirstOrDefaultAsync<PersonByIdViewModel>("[dbo].[Usp_Read_Person_Id]", parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
            return result;

        }

        public async Task<IEnumerable<PersonViewModel>> Read()
        {
            IEnumerable<PersonViewModel> result = new List<PersonViewModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<PersonViewModel>("[dbo].[Usp_Read_Person]", commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }



    }
}
