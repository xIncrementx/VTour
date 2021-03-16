using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTourAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace VTourAPI.Repositories
{
    public class UserRepository
    {
        string server = "THESPANISHINQUI";
        string database = "TourDB";

        string connectionString;

        public UserRepository ()
        {
            connectionString = "Server=" + server + "; Database=" + database + "; Trusted_Connection=True;";
        }

        public void CreateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                using (SqlCommand cmd = new SqlCommand("Createuser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
                    cmd.Parameters.Add("@Phonenumber", SqlDbType.VarChar).Value = user.PhoneNumber;
                    cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar).Value = user.Password;
                    cmd.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = user.FirstName;
                    cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = user.Surname;
                    cmd.Parameters.Add("@PostalCode", SqlDbType.Int).Value = user.PostalCode;
                    cmd.Parameters.Add("@StreetAddress", SqlDbType.VarChar).Value = user.StreetAddress;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public User ReadUser(string mail)
        {
            User userToReturn = new User();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                using (SqlCommand cmd = new SqlCommand("ReadUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = mail;

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
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
                                    case "Phonenumber":
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
                                    case "Streetaddress":
                                        userToReturn.StreetAddress = reader.GetString(i);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            
                        }
                    }
                    
                }
            }

            return userToReturn;
        }
        public void UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                using (SqlCommand cmd = new SqlCommand("UpdateUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
                    cmd.Parameters.Add("@Phonenumber", SqlDbType.VarChar).Value = user.PhoneNumber;
                    cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar).Value = user.Password;
                    cmd.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = user.FirstName;
                    cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = user.Surname;
                    cmd.Parameters.Add("@PostalCode", SqlDbType.Int).Value = user.PostalCode;
                    cmd.Parameters.Add("@StreetAddress", SqlDbType.VarChar).Value = user.StreetAddress;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteUser(User user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                using (SqlCommand cmd = new SqlCommand("Createuser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
                    cmd.Parameters.Add("@Phonenumber", SqlDbType.VarChar).Value = user.PhoneNumber;
                    cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar).Value = user.Password;
                    cmd.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = user.FirstName;
                    cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = user.Surname;
                    cmd.Parameters.Add("@PostalCode", SqlDbType.Int).Value = user.PostalCode;
                    cmd.Parameters.Add("@StreetAddress", SqlDbType.VarChar).Value = user.StreetAddress;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
