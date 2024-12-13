using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        //step - 1
        SqlConnection connect = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog=student;");
        connect.Open();
        Console.WriteLine("Connction Established....!!!");

        //step - 2
        String query = "select * from stu";
        SqlCommand cmd  = new SqlCommand(query, connect);

        Console.WriteLine("Data Fetched");

        //step - 3
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read()) {
            for (int i = 0; i < reader.FieldCount; i++) {
                string value = reader[i].ToString();
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }

        connect.Close();
        Console.WriteLine("Connection is Closed");
    }
}