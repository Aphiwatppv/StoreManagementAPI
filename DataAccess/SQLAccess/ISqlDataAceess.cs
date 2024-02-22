
namespace DataAccess.SQLAccess;

public interface ISqlDataAceess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedprocedures, U Parameters, string connectionString = "Default");
    Task Savedata<T>(string storedprocedures, T Parameters, string connectionString = "Default");
}