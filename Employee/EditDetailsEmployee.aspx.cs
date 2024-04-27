using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Employee_EditDetailsEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Employee employee = RetrieveEmployeeDetailsFromDatabase();

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
               
                TextBox6.Enabled = false;
                TextBox5.Enabled = false;
            }
        }
    }


    private Employee RetrieveEmployeeDetailsFromDatabase()
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
                    Employee employee = new Employee
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        Employee updatedEmployee = new Employee
        {
            FirstName = TextBox3.Text,
            LastName = TextBox4.Text,
            DateOfBirth = DateTime.Parse(TextBox5.Text),
            Gender = TextBox6.Text,
            Email = TextBox7.Text,
            ContactNo = TextBox8.Text,
            Address = TextBox9.Text
        };

        UpdateEmployeeDetails(updatedEmployee);
    }

    private void UpdateEmployeeDetails(Employee employee)
    {
        int employeeId = Convert.ToInt32(Session["EmployeeID"]);
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE EmployeeDetailsTbl SET " +
                           "FirstName = @FirstName, " +
                           "LastName = @LastName, " +
                           "Dob = @DateOfBirth, " +
                           "Gender = @Gender, " +
                           "Email = @Email, " +
                           "ContactNumber = @ContactNo, " +
                           "Address = @Address " +
                           "WHERE EmpId = @employeeId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", employee.Gender);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@ContactNo", employee.ContactNo);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@EmpId", TextBox1.Text);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

public class Employee
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
