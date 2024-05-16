﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Admin_User_SearchUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void btnSearchDesignation_Click(object sender, EventArgs e)
    {
        BindGridView();
    }

    protected void btnResetDesignation_Click(object sender, EventArgs e)
    {
        txtDeptId.Text = "";
        GridView2.DataSource = null;
        GridView2.DataBind();
    }

    private void BindGridView()
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string DeptId = txtDeptId.Text;
            string ActiveOrNot = ddlStatus.SelectedValue;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT U.UserId, U.Username, U.Password, CONCAT(E.FirstName, ' ', E.LastName) AS EmployeeName, U.AddedDate " +
                               "FROM dbo.EmployeeDetailsTbl E " +
                               "LEFT JOIN dbo.UserDetailsTbl U ON U.EmpId = E.EmpId " +
                               "WHERE U.Username = @DeptId AND U.IsActive = @ActiveOrNot";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@DeptId", DeptId);
                adapter.SelectCommand.Parameters.AddWithValue("@ActiveOrNot", ActiveOrNot);
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
                    GridView2.ShowHeaderWhenEmpty = true;
                    GridView2.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        BindGridView();
    }

    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView2.Rows[e.RowIndex];
        string userId = GridView2.DataKeys[e.RowIndex].Values[0].ToString();
        string username = ((TextBox)row.Cells[1].Controls[0]).Text;
        string password = ((TextBox)row.Cells[2].Controls[0]).Text;

        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE dbo.UserDetailsTbl SET Username = @Username, Password = @Password WHERE UserId = @UserId";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        GridView2.EditIndex = -1;
        BindGridView();
    }

    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        BindGridView();
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
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@DeptId", deptId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            BindGridView();
        }
        catch (Exception ex)
        {

        }
    }
}