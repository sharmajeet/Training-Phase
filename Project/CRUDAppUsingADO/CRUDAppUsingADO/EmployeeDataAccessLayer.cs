using System.Data.SqlClient;
using System.Security.Policy;
using CRUDAppUsingADO.Models;

namespace CRUDAppUsingADO
{
    public class EmployeeDataAccessLayer
    {
        string cs = ConnectionString.dbcs;

        public  List<Employees> GetAllEmployees()
        {
            List<Employees> empList = new List<Employees>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee" ,con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                    Employees emp = new Employees();
                    emp.Id = Convert.ToInt32(reader["ID"]);
                    emp.Name = reader["Name"].ToString()??"";
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.City = reader["City"].ToString() ?? "";

                    empList.Add(emp);
                }

            }

            return empList;
        }

        //insert new record

        public Employees AddEmployeeById(int? id)
        {
            Employees emp = new Employees();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from Employees where id = @id", con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    emp.Id = Convert.ToInt32(reader["ID"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.City = reader["City"].ToString() ?? "";

                }
            }
            return emp;
        }

        public void AddEmploye(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@designation", emp.Designation);
                cmd.Parameters.AddWithValue("@city", emp.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void UpdateEmploye(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", emp.Id);
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@designation", emp.Designation);
                cmd.Parameters.AddWithValue("@city", emp.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int? id)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
