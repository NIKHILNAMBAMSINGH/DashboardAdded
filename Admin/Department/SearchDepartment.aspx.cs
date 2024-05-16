﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Admin_Department_SearchDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSearchDesignation_Click(object sender, EventArgs e)
    {
        string status = ddlStatus.SelectedValue;
        string deptId = txtDeptId.Text.Trim();
        string deptName = txtDeptName.Text.Trim();

        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM dbo.DepartmentDetailsTbl WHERE 1 = 1";


                if (!string.IsNullOrEmpty(deptId))
                {
                    query += " AND DeptId = @DeptId";
                }


                if (!string.IsNullOrEmpty(deptName))
                {
                    query += " AND DeptName LIKE '%' + @DeptName + '%'";
                }

                if (!string.IsNullOrEmpty(status))
                {
                    query += " AND IsActive = @Active";
                }

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


                adapter.SelectCommand.Parameters.AddWithValue("@DeptId", deptId);
                adapter.SelectCommand.Parameters.AddWithValue("@DeptName", deptName);
                if (!string.IsNullOrEmpty(status))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@Active", status);
                }

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    GridView2.EmptyDataText = "No Records Found";
                    GridView2.ShowHeaderWhenEmpty = true;
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

    private void BindGridView()
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM dbo.DepartmentDetailsTbl where IsActive=1";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }



    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string deptId = GridView2.DataKeys[e.RowIndex].Values["DeptId"].ToString();
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE dbo.DepartmentDetailsTbl SET IsActive = 0 WHERE DeptId = @DeptId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DeptId", deptId);

                connection.Open();
                command.ExecuteNonQuery();
            }


            BindGridView();
        }
        catch (Exception ex)
        {

        }
    }
}