﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class Employee_Profile_ViewProfile : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["EmployeeId"] != null)
            {
                EmployeeDetails employee = RetrieveEmployeeDetailsFromDatabase();

                if (employee != null)
                {
                    txtEmpId.Text = employee.EmployeeID;
                    txtDepartment.Text = employee.DepartmentID;
                    txtEmployeeName.Text = employee.EmployeeName;

                    txtDob.Text = employee.DateOfBirth.ToShortDateString();
                    txtGender.Text = employee.Gender;
                    txtEmail.Text = employee.Email;
                    txtContactNumber.Text = employee.ContactNo;
                    txtAddress.Text = employee.Address;

                    DisableTextBoxes();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
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
                        EmployeeName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString(),
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

    protected void btnSearchDesignation_Click(object sender, EventArgs e)
    {
        EnableTextBoxes();
    }

    protected void btnUpdateEmployee_Click(object sender, EventArgs e)
    {
        EmployeeDetails updatedEmployee = new EmployeeDetails
        {
            EmployeeID = txtEmpId.Text,
            DepartmentID = txtDepartment.Text,
            DateOfBirth = DateTime.Parse(txtDob.Text),
            Gender = txtGender.Text,
            Email = txtEmail.Text,
            ContactNo = txtContactNumber.Text,
            Address = txtAddress.Text,
            Designation = txtDesignation.Text
        };

        UpdateEmployeeDetails(updatedEmployee);
    }

    private void UpdateEmployeeDetails(EmployeeDetails employee)
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE EmployeeDetailsTbl SET " +
                           "Dob = @DateOfBirth, " +
                           "Gender = @Gender, " +
                           "Email = @Email, " +
                           "ContactNumber = @ContactNo, " +
                           "Address = @Address " + 
                           "WHERE EmpId = @EmployeeID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
               
                command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", employee.Gender);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@ContactNo", employee.ContactNo);
                command.Parameters.AddWithValue("@Address", employee.Address);
               
                command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    private void DisableTextBoxes()
    {
        txtEmpId.Enabled = false;
        txtDepartment.Enabled = false;
        txtDob.Enabled = false;
        txtGender.Enabled = false;
        txtEmail.Enabled = false;
        txtContactNumber.Enabled = false;
        txtAddress.Enabled = false;
        txtEmployeeName.Enabled = false;
        txtDesignation.Enabled = false;
    }

    private void EnableTextBoxes()
    {
        txtEmpId.Enabled = true;
        txtDepartment.Enabled = true;
        txtDob.Enabled = true;
        txtGender.Enabled = true;
        txtEmail.Enabled = true;
        txtContactNumber.Enabled = true;
        txtAddress.Enabled = true;
        txtEmployeeName.Enabled = true;
        txtDesignation.Enabled = true;
    }
}

public class EmployeeDetails
{
    public string EmployeeID { get; set; }
    public string DepartmentID { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string ContactNo { get; set; }
    public string Address { get; set; }
    public string EmployeeName { get; set; }
    public string Designation { get; set; }
}