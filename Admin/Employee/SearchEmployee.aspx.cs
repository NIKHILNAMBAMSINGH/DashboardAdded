﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class Admin_Employee_SearchEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    protected void btnSearchDesignation_Click(object sender, EventArgs e)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            int EmpId = Convert.ToInt32(txtDeptId.Text);
            String IsActiveOrNot = ddlStatus.SelectedValue;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Concat(FirstName, ' ', LastName) as EmpName, EmpId, Dob, Gender, ContactNumber, Email, Address, AddedDate FROM dbo.EmployeeDetailsTbl WHERE EmpId = @EmpId AND IsActive=@IsActive";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@EmpId", EmpId);
                adapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActiveOrNot);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.EmptyDataText = "No Records Found";
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    
                }
            }
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void btnResetDesignation_Click(object sender, EventArgs e)
    {
        txtDeptId.Text = "";
        txtDeptName.Text = "";
        GridView2.DataSource = null;
        GridView2.DataBind();
    }

    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            int EmpId = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string updateQuery = "UPDATE dbo.EmployeeDetailsTbl SET IsActive = 0 WHERE EmpId = @EmpId";
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@EmpId", EmpId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

           
            btnSearchDesignation_Click(sender, e);
        }
        catch (Exception ex)
        {
            
            
        }
    }
}