﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
public partial class Admin_Employee_addEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            BindDepartments();
            BindDesignation();
            ClearFormFields();
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

    protected void btnAddEmployee_click(object sender, EventArgs e)
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
         int EmpId = Convert.ToInt32(txtEmpId.Text);
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO dbo.EmployeeDetailsTbl (EmpId,FirstName, LastName, Dob, Gender, ContactNumber, Email, Address, DepartmentId, DesignationId) " +
                           "VALUES (@EmpId,@FirstName, @LastName, @Dob, @Gender, @ContactNumber, @Email, @Address, @DepartmentId, @DesignationId)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmpId", EmpId);
            command.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
            command.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
            command.Parameters.AddWithValue("@Dob", DateTime.Parse(txtDob.Text));
            command.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
            command.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text.Trim());
            command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            command.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            command.Parameters.AddWithValue("@DepartmentId", ddlDepartment.SelectedValue);
            command.Parameters.AddWithValue("@DesignationId", ddlDesignation.SelectedValue);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    lblMessage.Text = "Added successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    ClearFormFields();
                }
                else
                {
                    lblMessage.Text = "Failed to add designation";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
        }
    }
    private void ClearFormFields()
    {
        txtEmpId.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtDob.Text = "";
        txtContactNumber.Text = "";
        txtEmail.Text = "";
        txtAddress.Text = "";

       
        ddlGender.SelectedIndex = 0; 
        ddlDepartment.SelectedIndex = 0;
        ddlDesignation.SelectedIndex = 0;
    }
}
