﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Admin_Department_AddDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDeptId.Text = "";
            txtDeptName.Text = "";
            lblMessage.Text = "";
        }
    }
    protected void btnAddDesignation_Click(object sender, EventArgs e)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            int departmentId = Convert.ToInt32(txtDeptId.Text);
            string departmentName = txtDeptName.Text;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO dbo.DepartmentDetailsTbl (DeptId, DeptName) VALUES (@DeptId, @DeptName)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@DeptId", SqlDbType.Int).Value = departmentId;
                    command.Parameters.Add("@DeptName", SqlDbType.VarChar).Value = departmentName;

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Added successfully";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Failed to add designation";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }


            txtDeptId.Text = "";
            txtDeptName.Text = "";

        }
        catch (Exception ex)
        {

            lblMessage.Text = "";

        }
    }

    protected void btnResetDesignation_Click(object sender, EventArgs e)
    {
        txtDeptId.Text = "";
        txtDeptName.Text = "";
    }
}