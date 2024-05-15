﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{

    protected void LoginButton_Click(object sender, EventArgs e)
    {
         string username = txtUsername.Text;
        string password = txtPassword.Text;

        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT EmpId, RoleId FROM dbo.UserDetailsTbl WHERE Username = @Username AND Password = @Password AND IsActive=1";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                      
                        int roleId = reader.GetInt32(reader.GetOrdinal("RoleId"));

                       
                        Console.WriteLine("Role ID: " + roleId);

                        if (roleId == 1)
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("EmpId")))
                            {
                                int employeeId = reader.GetInt32(reader.GetOrdinal("EmpId"));
                                Session["Admin"] = GetEmployeeName(employeeId);
                                
                            }
                            else
                            {
                              
                                Session["Admin"] = "Default Admin";
                            }

                            Console.WriteLine("Redirecting to admin page");
                            Response.Redirect("~/Admin/EmptyPage.aspx");
                        }
                        else
                        {
                            int userId = reader.GetInt32(reader.GetOrdinal("EmpId"));
                            int employeeId = GetEmployeeId(userId);
                            if (employeeId != -1)
                            {
                                
                                Session["EmployeeId"] = employeeId;
                                Session["EmployeeName"] = GetEmployeeName(employeeId);

                                Response.Redirect("~/Employee/EmptyPage.aspx");
                            }
                                
                            else
                            {
                              
                                Console.WriteLine("Employee details not found");
                            }
                        }
                    }
                    else
                    {
                        
                        Console.WriteLine("User not found");
                    }

                    reader.Close();
                }
                catch (SqlException ex)
                {
                   
                    Console.WriteLine("SQL Exception: " + ex.Message);
                }
                catch (Exception ex)
                {
                   
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
        }
    }


    private int GetEmployeeId(int userId)
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        int employeeId = -1;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT EmpId FROM dbo.EmployeeDetailsTbl WHERE EmpId = @UserId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    employeeId = Convert.ToInt32(result);
                }
            }
        }

        return employeeId;
    }
    private string GetEmployeeName(int employeeId)
    {
        string employeeName = null;
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "select CONCAT(FirstName, ' ',LastName)as Name from dbo.EmployeeDetailsTbl where EmpId=@EmpId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmpId", employeeId);
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    employeeName = result.ToString();
                }
            }
        }
        return employeeName;
    }
   
}