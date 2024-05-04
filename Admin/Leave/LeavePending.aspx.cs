﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Admin_Leave_LeavePending : System.Web.UI.Page
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
                string query = "SELECT e.EmpId as EmpId, l.LeaveId as LeaveId, CONCAT(e.FirstName, ' ', e.LastName) AS EmpName, l.LeaveType, l.StartDate, l.EndDate, l.NoOfDays, l.LeaveStatus, l.Reason, l.AddedDate as AddedDate FROM dbo.LeaveDetailsTbl l LEFT JOIN dbo.EmployeeDetailsTbl e ON l.EmpId = e.EmpId WHERE l.LeaveStatus = 'Pending' AND l.EmpId = @EmpId";
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

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = -1;
        int pageRowIndex = -1;

        if (int.TryParse(e.CommandArgument.ToString(), out pageRowIndex))
        {
            rowIndex = (GridView2.PageIndex * GridView2.PageSize) + pageRowIndex;
        }

        if (rowIndex >= 0 && rowIndex < GridView2.Rows.Count)
        {
            CheckBox chkApprove = (CheckBox)GridView2.Rows[rowIndex].FindControl("CheckBoxApprove");

            if (chkApprove != null)
            {
                int leaveId = Convert.ToInt32(GridView2.DataKeys[rowIndex].Value);

                if (e.CommandName == "ApproveLeave" && chkApprove.Checked)
                {
                    UpdateLeaveStatus(leaveId, "Approved");
                }
                else if (e.CommandName == "RejectLeave" && chkApprove.Checked)
                {
                    UpdateLeaveStatus(leaveId, "Rejected");
                }

                BtnSearchLeave_Click(sender, e);
            }
        }
    }


    private void UpdateLeaveStatus(int leaveId, string status)
    {
        try
        {
            string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE dbo.LeaveDetailsTbl SET LeaveStatus = @Status,ApprovedDate=GETDATE() WHERE LeaveId = @LeaveId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@LeaveId", leaveId);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Response.Write("An error occurred while updating leave status: " + ex.Message);
            throw;
        }
    }

    protected void BtnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            int EmpId = Convert.ToInt32(txtDeptId.Text);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT e.EmpId as EmpId, l.LeaveId as LeaveId, CONCAT(e.FirstName, ' ', e.LastName) AS EmpName, l.LeaveType, l.StartDate, l.EndDate, l.NoOfDays, l.LeaveStatus, l.Reason, l.AddedDate as AddedDate FROM dbo.LeaveDetailsTbl l LEFT JOIN dbo.EmployeeDetailsTbl e ON l.EmpId = e.EmpId WHERE l.LeaveStatus = 'Pending'";
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