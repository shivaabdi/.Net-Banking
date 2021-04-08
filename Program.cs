using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Bank_konto
{
    class Program
    {

        public static List<KontoInfo> kontos = new List<KontoInfo>();
        public static KontoInfo current_user;
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings.json", false)
           .Build();

            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();

                    sb.Append("SELECT TOP 20 CardNo, Password ");
                    sb.Append("FROM [dbo].[KontoInfo] ");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }






            //example

            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO dbo.Table_1 (id,username,password,email)");
                    sb.Append("VALUES(@id, @username, @password, @email)");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", "hh667kj");
                        command.Parameters.AddWithValue("@username", ",zcxc");
                        command.Parameters.AddWithValue("@password", "mmmmm");
                        command.Parameters.AddWithValue("@email", "mmmmm");

                        
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }



































            UserIdentification example = new UserIdentification(ref kontos);
            example.CreateAcountList();

            Login(example);

            ChooseTask controller = new ChooseTask();
            while (current_user != null)
            {
                int returnCode = controller.ChooseAnOption(current_user);

                switch (returnCode)
                {
                    case 0:
                        current_user = null;
                        Login(example);
                        break;
                }

            }



            //chooseOption();
            //
        }

        static void Login(UserIdentification example)
        {
            while (current_user == null)
                current_user = example.UserLigitation();
        }

    }
}
