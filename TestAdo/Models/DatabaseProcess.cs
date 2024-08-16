using System.Data.SqlClient;
using TestAdo.Entities;

namespace TestAdo.Models
{
    public class DatabaseProcess
    {
        //CRUD : Create , Read , Update , Delete
        private readonly SqlConnection connection = new SqlConnection("Data Source=(local);Initial Catalog=testdb;Integrated Security=True;Encrypt=False");
        //Create, Update, Delete
       public void AddUser(User user)
        {
            string strInsert = "INSERT INTO [User] (Firstname,Lastname,Mobile) VALUES(@Firstname,@Lastname,@Mobile)";
            SqlCommand command = new SqlCommand(strInsert, connection);
            command.Parameters.AddWithValue("@Firstname",user.Firstname);
            command.Parameters.AddWithValue("@Lastname",user.Lastname);
            command.Parameters.AddWithValue("@Mobile",user.Mobile);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteUser(User user)
        {
            string strDelete = "DELETE FROM [User] WHERE Firstname = @Firstname";
            SqlCommand command = new SqlCommand(strDelete, connection);
            command.Parameters.AddWithValue("@Firstname", user.Firstname);
            //command.Parameters.AddWithValue("@Lastname", user.Lastname);
            //command.Parameters.AddWithValue("@Mobile", user.Mobile);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateUser(User user)
        {
            string strUpdate = "UPDATE [User] SET Firstname=@Firstname,Lastname=@Lastname,Mobile=@Mobile WHERE Id=@Id";
            SqlCommand command = new SqlCommand(strUpdate, connection);
            command.Parameters.AddWithValue("@Firstname", user.Firstname);
            command.Parameters.AddWithValue("@Lastname", user.Lastname);
            command.Parameters.AddWithValue("@Mobile", user.Mobile);
            command.Parameters.AddWithValue("@Id", "84C44C38-61F8-4734-8E36-C0709044158E");
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }





        //Read
        public void GetAll()
        {
            List<User> users = new List<User>();
            SqlCommand command = new SqlCommand("SELECT Id,Firstname,Lastname,Mobile FROM [User]", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                User user = new User();
                user.Id =reader.GetGuid(0);
                user.Firstname = reader.GetString(1);
                user.Lastname = reader.GetString(2);
                try
                {
                    user.Mobile = reader.GetString(3);
                }
                catch
                {
                    user.Mobile = null;
                }
                users.Add(user);
            }


            connection.Close();

        }
        public void GetWithId()
        {
            List<User> users = new List<User>();
            SqlCommand command = new SqlCommand("SELECT Id,Firstname,Lastname,Mobile FROM [User] WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", "B40C902A-E3D2-45E3-BEF2-963104ADD4C1");
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = new User();
                    user.Id = reader.GetGuid(0);
                    user.Firstname = reader.GetString(1);
                    user.Lastname = reader.GetString(2);
                    try
                    {
                        user.Mobile = reader.GetString(3);
                    }
                    catch
                    {
                        user.Mobile = null;
                    }
                    users.Add(user);
                }
            }


            connection.Close();

        }
    }
}
