﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class adminEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtEmpId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDob.Text = "";
            ddlGender.SelectedIndex = 0;
            txtContactNumber.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtDepartmentId.Text = "";
            BindGridView();
        }
    }

    protected void btnResetEmployee_Click(object sender, EventArgs e)
    {
        ClearInputFields();
    }

    protected void BindGridView()
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM dbo.EmployeeDetailsTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            int empId = Convert.ToInt32(txtEmpId.Text);
            
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string dob = txtDob.Text;
            string gender = ddlGender.SelectedValue;
            string contactNumber = txtContactNumber.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            int departmentId = Convert.ToInt32(txtDepartmentId.Text);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO dbo.EmployeeDetailsTbl (empId, FirstName, LastName, Dob, Gender, ContactNumber, Email, Address, DepartmentId) " +
                               "VALUES (@EmpId, @FirstName, @LastName, @Dob, @Gender, @ContactNumber, @Email, @Address, @DepartmentId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmpId", empId);
                
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Dob", dob);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@ContactNumber", contactNumber);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@DepartmentId", departmentId);

                connection.Open();
                command.ExecuteNonQuery();
            }

            BindGridView();

            ClearInputFields();
        }
        catch (Exception ex)
        {
            // Handle exception
        }
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGridView();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGridView();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int rowIndex = e.RowIndex;
        GridViewRow row = GridView1.Rows[rowIndex];

        int empId = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values["empId"]);
        int newEmpId = Convert.ToInt32(((TextBox)row.Cells[0].Controls[0]).Text); // Assuming the empId textbox is in the first column
        string firstName = ((TextBox)row.Cells[2].Controls[0]).Text;
        string lastName = ((TextBox)row.Cells[3].Controls[0]).Text;
        string dob = ((TextBox)row.Cells[4].Controls[0]).Text;
        string gender = ((DropDownList)row.Cells[5].Controls[1]).SelectedValue;
        string contactNumber = ((TextBox)row.Cells[6].Controls[0]).Text;
        string email = ((TextBox)row.Cells[7].Controls[0]).Text;
        string address = ((TextBox)row.Cells[8].Controls[0]).Text;
        int departmentId = Convert.ToInt32(((TextBox)row.Cells[9].Controls[0]).Text);

        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE dbo.EmployeeDetailsTbl SET empId = @NewEmpId,FirstName = @FirstName, " +
                               "LastName = @LastName, Dob = @Dob, Gender = @Gender, ContactNumber = @ContactNumber, Email = @Email, " +
                               "Address = @Address, DepartmentId = @DepartmentId WHERE empId = @EmpId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmpId", empId);
                command.Parameters.AddWithValue("@NewEmpId", newEmpId);
               
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Dob", dob);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@ContactNumber", contactNumber);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@DepartmentId", departmentId);

                connection.Open();
                command.ExecuteNonQuery();
            }

            GridView1.EditIndex = -1;
            BindGridView();
        }
        catch (Exception ex)
        {
            // Handle exception
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowIndex = e.RowIndex;
        int empId = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values["empId"]);

        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM dbo.EmployeeDetailslTbl WHERE empId=@EmpId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmpId", empId);

                connection.Open();
                command.ExecuteNonQuery();
            }

            BindGridView();
        }
        catch (Exception ex)
        {
            // Handle exception
        }
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGridView();
    }

    private void ClearInputFields()
    {
        txtEmpId.Text = "";
       
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtDob.Text = "";
        ddlGender.SelectedIndex = 0;
        txtContactNumber.Text = "";
        txtEmail.Text = "";
        txtAddress.Text = "";
        txtDepartmentId.Text = "";
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnSearchEmployee_Click(object sender, EventArgs e)
    {

        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            int searchEmpId = Convert.ToInt32(txtEmpId.Text);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "select * from dbo.EmployeeDetailsTbl WHERE EmpId = @EmpId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@EmpId", searchEmpId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}