using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Employee_ViewEmployeeDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EmployeeDetails employee = RetrieveEmployeeDetailsFromDatabase();

            if (employee != null)
            {
                TextBox1.Text = employee.EmployeeID;
                TextBox2.Text = employee.DepartmentID;
                TextBox3.Text = employee.FirstName;
                TextBox4.Text = employee.LastName;
                TextBox5.Text = employee.DateOfBirth.ToShortDateString();
                TextBox6.Text = employee.Gender;
                TextBox7.Text = employee.Email;
                TextBox8.Text = employee.ContactNo;
                TextBox9.Text = employee.Address;
               

                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                TextBox3.Enabled = false;
                TextBox4.Enabled = false;
                TextBox5.Enabled = false;
                TextBox6.Enabled = false;
                TextBox7.Enabled = false;
                TextBox8.Enabled = false;
                TextBox9.Enabled = false;
              
            }
        }
    }


    private EmployeeDetails RetrieveEmployeeDetailsFromDatabase()
    {
        int employeeId = Convert.ToInt32(Session["EmployeeId"]);
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM EmployeeDetailsTbl WHERE EmpId=@employeeId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@employeeId", employeeId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    EmployeeDetails employee = new EmployeeDetails
                    {
                        EmployeeID = reader["EmpId"].ToString(),
                        DepartmentID = reader["DepartmentId"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["Dob"]),
                        Gender = reader["Gender"].ToString(),
                        Email = reader["Email"].ToString(),
                        ContactNo = reader["ContactNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        
                    };

                    return employee;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

public class EmployeeDetails
{
    public string EmployeeID { get; set; }
    public string DepartmentID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string ContactNo { get; set; }
    public string Address { get; set; }
   
}
