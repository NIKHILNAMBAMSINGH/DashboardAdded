using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class LeaveRejectedAdmin : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

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
                string query = "SELECT * FROM dbo.LeaveDetailsTbl WHERE StartDate >= @FromDate AND EndDate <= @ToDate AND LeaveStatus = 'Rejected'";
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
}