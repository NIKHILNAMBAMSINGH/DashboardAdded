using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class LeavePendingAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (IsValidDateRange(TextBoxLeaveFrom.Text, TextBoxLeaveTo.Text))
        {
            DateTime fromDate = DateTime.Parse(TextBoxLeaveFrom.Text);
            DateTime toDate = DateTime.Parse(TextBoxLeaveTo.Text);
            DataTable dt = FetchDataFromDatabase(fromDate, toDate);
            BindGridView(dt);
        }
        else
        {
            Response.Write("Please enter valid dates.");
        }
    }

    private bool IsValidDateRange(string fromDate, string toDate)
    {
        DateTime fromDateValue, toDateValue;
        return DateTime.TryParse(fromDate, out fromDateValue) && DateTime.TryParse(toDate, out toDateValue);
    }

    private DataTable FetchDataFromDatabase(DateTime fromDate, DateTime toDate)
    {
        try
        {
            string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT e.EmpId as EmpId,l.LeaveId as LeaveId, CONCAT(e.FirstName, ' ', e.LastName) AS EmpName, l.LeaveType, l.StartDate, l.EndDate, l.NoOfDays, l.LeaveStatus, l.Reason, l.AddedDate as AddedDate FROM dbo.LeaveDetailsTbl l LEFT JOIN dbo.EmployeeDetailsTbl e ON l.EmpId = e.EmpId WHERE l.StartDate >= @FromDate AND l.EndDate <= @ToDate AND l.LeaveStatus = 'Pending'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", fromDate);
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", toDate);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
        catch (Exception ex)
        {
            Response.Write("An error occurred: " + ex.Message);
            throw;
        }
    }

    private void BindGridView(DataTable dt)
    {
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        RefreshGridView();
    }

    private void RefreshGridView()
    {
        DateTime fromDate, toDate;
        if (DateTime.TryParse(TextBoxLeaveFrom.Text, out fromDate) && DateTime.TryParse(TextBoxLeaveTo.Text, out toDate))
        {
            DataTable dt = FetchDataFromDatabase(fromDate, toDate);
            BindGridView(dt);
        }
        else
        {
            Response.Write("Please enter valid dates.");
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = -1;
        int pageRowIndex = -1;

        if (int.TryParse(e.CommandArgument.ToString(), out pageRowIndex))
        {
            rowIndex = (GridView1.PageIndex * GridView1.PageSize) + pageRowIndex;
        }

        if (rowIndex >= 0 && rowIndex < GridView1.Rows.Count)
        {
            CheckBox chkApprove = (CheckBox)GridView1.Rows[rowIndex].FindControl("CheckBoxApprove");

            if (chkApprove != null)
            {
                int leaveId = Convert.ToInt32(GridView1.DataKeys[rowIndex].Value);

                if (e.CommandName == "ApproveLeave" && chkApprove.Checked)
                {
                    UpdateLeaveStatus(leaveId, "Approved");
                }
                else if (e.CommandName == "RejectLeave" && chkApprove.Checked)
                {
                    UpdateLeaveStatus(leaveId, "Rejected");
                }

                RefreshGridView();
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
}
