﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class adminDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDeptId.Text = "";
            txtDeptName.Text = "";
            BindGridView();
        }
    }

    protected void btnResetDepartment_Click(object sender, EventArgs e)
    {
        txtDeptId.Text = "";
        txtDeptName.Text = "";
    }

    protected void BindGridView()
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM dbo.DepartmentDetailsTbl";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnAddDepartment_Click(object sender, EventArgs e)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            int deptId = Convert.ToInt32(txtDeptId.Text);
            string deptName = txtDeptName.Text;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO dbo.DepartmentDetailsTbl (deptId, deptName) VALUES (@DeptId, @DeptName)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DeptId", deptId);
                command.Parameters.AddWithValue("@DeptName", deptName);

                connection.Open();
                command.ExecuteNonQuery();
            }

            BindGridView();

            txtDeptId.Text = "";
            txtDeptName.Text = "";
        }
        catch (Exception ex)
        {

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

        int deptId = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values["deptId"]);
        string deptName = ((TextBox)row.Cells[1].Controls[0]).Text;
        int newDeptId = Convert.ToInt32(((TextBox)row.Cells[0].Controls[0]).Text);

        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE dbo.DepartmentDetailsTbl SET deptId = @NewDeptId, deptName = @DeptName WHERE deptId = @DeptId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DeptId", deptId);
                command.Parameters.AddWithValue("@DeptName", deptName);
                command.Parameters.AddWithValue("@NewDeptId", newDeptId);

                connection.Open();
                command.ExecuteNonQuery();
            }

            GridView1.EditIndex = -1;
            BindGridView();
        }
        catch (Exception ex)
        {

        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowIndex = e.RowIndex;
        int deptId = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values["deptId"]);

        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM dbo.DepartmentDetailsTbl WHERE deptId = " + deptId;
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

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGridView();
    }
}