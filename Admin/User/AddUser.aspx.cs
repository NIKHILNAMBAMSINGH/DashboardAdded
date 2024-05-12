﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Admin_User_AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            BindDesignation();

        }
    }
    private void BindDesignation()
    {

        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {

            string query = "SELECT EmpId, CONCAT(FirstName, ' ', LastName) AS EmpName FROM dbo.EmployeeDetailsTbl";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            ddlDesignation.DataSource = reader;
            ddlDesignation.DataTextField = "EmpName";
            ddlDesignation.DataValueField = "EmpId";
            ddlDesignation.DataBind();
        }
        ddlDesignation.Items.Insert(0, new ListItem("Select employee Name", ""));
    }
    protected void btnAddEmployee_Click(object sender, EventArgs e)
    {

        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO dbo.UserDetailsTbl(Username,Password,EmpId,RoleId) " +
                           "VALUES (@Username,@Password,@EmpId,2)";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
            command.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
            command.Parameters.AddWithValue("@EmpId", ddlDesignation.SelectedValue);
            command.Parameters.AddWithValue("@RoleId", 2);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    lblMessage.Text = "Added successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    BindDesignation();

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
}