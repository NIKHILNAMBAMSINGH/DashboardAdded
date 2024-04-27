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
                string query = "INSERT INTO dbo.DepartmentDetailsTbl (DeptId, DeptName) VALUES (@DeptId, @DeptName)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@DeptId", SqlDbType.Int).Value = deptId;
                    command.Parameters.Add("@DeptName", SqlDbType.VarChar).Value = deptName;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
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


    protected void btnSearchDepartment_Click(object sender, EventArgs e)
    {

        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            int searchDeptId = Convert.ToInt32(TextBoxDepartmentId.Text); 

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM dbo.DepartmentDetailsTbl WHERE DeptId = @DeptId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@DeptId", searchDeptId);
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