using VTourAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace VTourAPI.Repositories
{
    public class UserRepository
    {
        private const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=TourDb;Trusted_Connection=True;User Id=VtourAdmin;Password=1234;";

        public void CreateUser(UserInfo userInfo)
        {
            using var connection = new SqlConnection {ConnectionString = ConnectionString};
            using var cmd = new SqlCommand("CreateUser", connection) {CommandType = CommandType.StoredProcedure};

            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = userInfo.FirstName;
            cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = userInfo.Surname;
            cmd.Parameters.Add("@StreetAddress", SqlDbType.VarChar).Value = userInfo.Address;
            cmd.Parameters.Add("@PostalCode", SqlDbType.Int).Value = userInfo.PostalCode;
            cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = userInfo.PhoneNumber;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = userInfo.Country;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = userInfo.Email;
            cmd.Parameters.Add("@HashedPassword", SqlDbType.VarChar).Value = userInfo.HashedPassword;

            connection.Open();
            cmd.ExecuteNonQuery();
        }
        public UserInfo ReadUser(string mail)
        {
            var userToReturn = new UserInfo();
            using var connection = new SqlConnection {ConnectionString = ConnectionString};
            using var cmd = new SqlCommand("ReadUser", connection) {CommandType = CommandType.StoredProcedure};

            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = mail;
            connection.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    switch (reader.GetName(i))
                    {
                        case "FirstName":
                            userToReturn.FirstName = reader.GetString(i);
                            break;
                        case "Email":
                            userToReturn.Email = reader.GetString(i);
                            break;
                        case "PhoneNumber":
                            userToReturn.PhoneNumber = reader.GetString(i);
                            break;
                        case "HashedPassword":
                            userToReturn.HashedPassword = reader.GetString(i);
                            break;
                        case "Surname":
                            userToReturn.Surname = reader.GetString(i);
                            break;
                        case "PostalCode":
                            userToReturn.PostalCode = reader.GetInt32(i);
                            break;
                        case "StreetAddress":
                            userToReturn.Address = reader.GetString(i);
                            break;
                        default:
                            break;
                    }
                }
                            
            }

            return userToReturn;
        }
        public void UpdateUser(UserInfo userInfo)
        {
            using var connection = new SqlConnection {ConnectionString = ConnectionString};

            using var cmd = new SqlCommand("UpdateUser", connection) {CommandType = CommandType.StoredProcedure};

            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = userInfo.Email;
            cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = userInfo.PhoneNumber;
            cmd.Parameters.Add("@HashedPassword", SqlDbType.VarChar).Value = userInfo.HashedPassword;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = userInfo.FirstName;
            cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = userInfo.Surname;
            cmd.Parameters.Add("@PostalCode", SqlDbType.Int).Value = userInfo.PostalCode;
            cmd.Parameters.Add("@StreetAddress", SqlDbType.VarChar).Value = userInfo.Address;

            connection.Open();
            cmd.ExecuteNonQuery();
        }
        public void DeleteUser(UserInfo userInfo)
        {
            using var connection = new SqlConnection {ConnectionString = ConnectionString};
            using var cmd = new SqlCommand("DeleteUser", connection) {CommandType = CommandType.StoredProcedure};


            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
