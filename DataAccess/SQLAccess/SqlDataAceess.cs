using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace DataAccess.SQLAccess;

public class SqlDataAceess : ISqlDataAceess
{

    private readonly IConfiguration _configuration;
    public SqlDataAceess(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// Create a method loading data and saving data 
    /// 
    public async Task<IEnumerable<T>> LoadData<T, U>(string storedprocedures, U Parameters, string connectionString = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionString));
        return await connection.QueryAsync<T>(storedprocedures, Parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task Savedata<T>(string storedprocedures, T Parameters, string connectionString = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionString));
        await connection.ExecuteAsync(storedprocedures, Parameters, commandType: CommandType.StoredProcedure);
    }
}
