using VTourAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace VTourAPI.Repositories
{
    public class UserRepository
    {
        private const string ConnectionString = "Server=localhost/SQLEXPRESS;Database=master;Trusted_Connection=True;";

        public void CreateUser(User user)
        {
            using var connection = new SqlConnection {ConnectionString = ConnectionString};
            using var cmd = new SqlCommand("CreateUser", connection) {CommandType = CommandType.StoredProcedure};

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
            cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = user.PhoneNumber;
            cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar).Value = user.Password;
            cmd.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = user.FirstName;
            cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = user.Surname;
            cmd.Parameters.Add("@PostalCode", SqlDbType.Int).Value = user.PostalCode;
            cmd.Parameters.Add("@StreetAddress", SqlDbType.VarChar).Value = user.StreetAddress;

            connection.Open();
            cmd.ExecuteNonQuery();
        }
        public User ReadUser(string mail)
        {
            var userToReturn = new User();
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
                        case "Id":
                            userToReturn.Id = reader.GetInt32(i);
                            break;
                        case "Email":
                            userToReturn.Email = reader.GetString(i);
                            break;
                        case "PhoneNumber":
                            userToReturn.PhoneNumber = reader.GetString(i);
                            break;
                        case "UserPassword":
                            userToReturn.Password = reader.GetString(i);
                            break;
                        case "Firstname":
                            userToReturn.FirstName = reader.GetString(i);
                            break;
                        case "Surname":
                            userToReturn.Surname = reader.GetString(i);
                            break;
                        case "PostalCode":
                            userToReturn.PostalCode = reader.GetInt32(i);
                            break;
                        case "StreetAddress":
                            userToReturn.StreetAddress = reader.GetString(i);
                            break;
                        default:
                            break;
                    }
                }
                            
            }

            return userToReturn;
        }
        public void UpdateUser(User user)
        {
            using var connection = new SqlConnection {ConnectionString = ConnectionString};

            using var cmd = new SqlCommand("UpdateUser", connection) {CommandType = CommandType.StoredProcedure};

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
            cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = user.PhoneNumber;
            cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar).Value = user.Password;
            cmd.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = user.FirstName;
            cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = user.Surname;
            cmd.Parameters.Add("@PostalCode", SqlDbType.Int).Value = user.PostalCode;
            cmd.Parameters.Add("@StreetAddress", SqlDbType.VarChar).Value = user.StreetAddress;

            connection.Open();
            cmd.ExecuteNonQuery();
        }
        public void DeleteUser(User user)
        {
            using var connection = new SqlConnection {ConnectionString = ConnectionString};
            using var cmd = new SqlCommand("DeleteUser", connection) {CommandType = CommandType.StoredProcedure};

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;

            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
