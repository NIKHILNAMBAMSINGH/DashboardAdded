﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Admin_User_SearchUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnSearchDesignation_Click(object sender, EventArgs e)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string DeptId = txtDeptId.Text;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "Select U.Username as Username,U.AddedDate as AddedDate, U.Password as Password , CONCAT(E.FirstName, ' ', E.LastName) AS EmployeeName FROM dbo.EmployeeDetailsTbl E left join dbo.UserDetailsTbl U on U.EmpId=E.EmpId where U.Username= @DeptId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@DeptId", DeptId);
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
       
        GridView2.DataSource = null;
        GridView2.DataBind();
    }
}