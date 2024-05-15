﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class Employee_User_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["EmployeeId"] != null)
            {
                getUserData();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

        }
    }

    protected void btnSearchDesignation_Click(object sender, EventArgs e)
    {
        string newPassword = txtPassword.Text.Trim();

       
        if (!string.IsNullOrEmpty(newPassword))
        {
           
            int employeeId = Convert.ToInt32(Session["EmployeeId"]);

          
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

           
            string query = "UPDATE UserDetailsTbl SET Password = @newPassword WHERE EmpId = @employeeId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@newPassword", newPassword);
                    command.Parameters.AddWithValue("@employeeId", employeeId);

                    try
                    {
                      
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                     
                        if (rowsAffected > 0)
                        {

                            lblMessage.Text = "Password update Successfully";
                        }
                        else
                        {
                           
                            Response.Write("Failed to update password. Please try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        
                        Response.Write("An error occurred while updating password: " + ex.Message);
                    }
                }
            }
        }
        else
        {
           
            Response.Write("Please enter a new password.");
        }
    }
    private void getUserData()
    {
        int employeeId = Convert.ToInt32(Session["EmployeeId"]);
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM UserDetailsTbl WHERE EmpId=@employeeId AND IsActive=1";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@employeeId", employeeId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtUsername.Text = reader["Username"].ToString();
                    txtPassword.Text = reader["Password"].ToString();
                    txtUsername.Enabled = false;
                }
                else
                {

                }
            }
        }
    }
}
