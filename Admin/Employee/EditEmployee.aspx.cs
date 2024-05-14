﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Admin_Employee_EditEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDepartments();
            BindDesignation();
            DisableTextBoxes();
        }
    }

    private void BindDepartments()
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT DeptId, DeptName FROM dbo.DepartmentDetailsTbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            ddlDepartment.DataSource = reader;
            ddlDepartment.DataTextField = "DeptName";
            ddlDepartment.DataValueField = "DeptId";
            ddlDepartment.DataBind();
        }
    }
    private void DisableTextBoxes()
    {
        txtEmpId.Enabled = false;
        ddlDepartment.Enabled = false;
        txtDob.Enabled = false;
        ddlGender.Enabled = false;
        txtEmail.Enabled = false;
        txtContactNumber.Enabled = false;
        txtAddress.Enabled = false;
        txtFirstName.Enabled = false;
        txtLastName.Enabled = false;
        ddlDesignation.Enabled = false;
    }

    private void EnableTextBoxes()
    {
        txtEmpId.Enabled = true;
        ddlDepartment.Enabled = true;
        txtDob.Enabled = true;
        ddlGender.Enabled = true;
        txtEmail.Enabled = true;
        txtContactNumber.Enabled = true;
        txtAddress.Enabled = true;
        txtFirstName.Enabled = true;
        txtLastName.Enabled = true;
        ddlDesignation.Enabled = true;
    }

    private void BindDesignation()
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT DesignationId, DesignationName FROM dbo.DesignationDetailsTbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            ddlDesignation.DataSource = reader;
            ddlDesignation.DataTextField = "DesignationName";
            ddlDesignation.DataValueField = "DesignationId";
            ddlDesignation.DataBind();
        }
    }


    protected void btnEditEmployee_Click(object sender, EventArgs e)
    {
        
    }

    protected void btnSearchDesignation_Click(object sender, EventArgs e)
    {
        EmployeeEditDetails employee = RetrieveEmployeeDetailsFromDatabase();

        if (employee != null)
        {
            txtEmpId.Text = employee.EmployeeID;
            ddlDepartment.SelectedValue = employee.DepartmentID;
            txtFirstName.Text = employee.EmployeeFirstName;
            txtLastName.Text = employee.EmployeeLastName;
            txtDob.Text = employee.DateOfBirth.ToShortDateString();
            ddlGender.SelectedValue = employee.Gender;
            txtEmail.Text = employee.Email;
            txtContactNumber.Text = employee.ContactNo;
            txtAddress.Text = employee.Address;
            DisableTextBoxes();
        }
        else
        {
           
        }
    }

    private EmployeeEditDetails RetrieveEmployeeDetailsFromDatabase()
    {
        int employeeId = Convert.ToInt32(txtEmployeeCode.Text);
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
                    EmployeeEditDetails employee = new EmployeeEditDetails
                    {
                        EmployeeID = reader["EmpId"].ToString(),
                        DepartmentID = reader["DepartmentId"].ToString(),
                        EmployeeFirstName = reader["FirstName"].ToString(),
                        EmployeeLastName = reader["LastName"].ToString(),
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

    public class EmployeeEditDetails
    {
        public string EmployeeID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        
    }
}