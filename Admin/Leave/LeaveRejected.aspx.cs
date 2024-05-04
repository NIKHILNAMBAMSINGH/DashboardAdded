﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
public partial class Admin_Leave_LeaveRejected : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnSearchLeave_Click(object sender, EventArgs e)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            int EmpId = Convert.ToInt32(txtDeptId.Text);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT e.EmpId as EmpId, l.LeaveId as LeaveId, CONCAT(e.FirstName, ' ', e.LastName) AS EmpName, l.LeaveType, l.StartDate, l.EndDate, l.NoOfDays, l.LeaveStatus, l.Reason, l.AddedDate as AddedDate FROM dbo.LeaveDetailsTbl l LEFT JOIN dbo.EmployeeDetailsTbl e ON l.EmpId = e.EmpId WHERE l.LeaveStatus = 'Rejected' AND l.EmpId = @EmpId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@EmpId", EmpId);
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
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        BtnSearchLeave_Click(sender, e);
    }

   
    protected void BtnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            int EmpId = Convert.ToInt32(txtDeptId.Text);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT e.EmpId as EmpId, l.LeaveId as LeaveId, CONCAT(e.FirstName, ' ', e.LastName) AS EmpName, l.LeaveType, l.StartDate, l.EndDate, l.NoOfDays, l.LeaveStatus, l.Reason, l.AddedDate as AddedDate FROM dbo.LeaveDetailsTbl l LEFT JOIN dbo.EmployeeDetailsTbl e ON l.EmpId = e.EmpId WHERE l.LeaveStatus = 'Rejected'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@EmpId", EmpId);
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
}