using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Employee_AttendanceReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        DateTime DateFrom, DateTo;

        if (DateTime.TryParse(TextBoxFromDate.Text, out DateFrom) && DateTime.TryParse(TextBoxToDate.Text, out DateTo))
        {
            DataTable dt = FetchDataFromDatabase(DateFrom, DateTo);
            CalculateAndUpdateTotalHoursWorked(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            Response.Write("Please enter valid dates.");
        }
    }

    private DataTable FetchDataFromDatabase(DateTime DateFrom, DateTime DateTo)
    {
        int empId = int.Parse(Session["EmployeeId"].ToString());
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM AttendanceDetailsTbl WHERE EmpId = @EmpId AND Date >= @DateFrom AND Date <= @DateTo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@EmpId", empId);
                adapter.SelectCommand.Parameters.AddWithValue("@DateFrom", DateFrom);
                adapter.SelectCommand.Parameters.AddWithValue("@DateTo", DateTo);

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

    private void CalculateAndUpdateTotalHoursWorked(DataTable dt)
    {
        foreach (DataRow row in dt.Rows)
        {
            if (row["TimeIn"] != DBNull.Value && row["TimeOut"] != DBNull.Value)
            {
                TimeSpan timeIn = TimeSpan.Parse(row["TimeIn"].ToString());
                TimeSpan timeOut = TimeSpan.Parse(row["TimeOut"].ToString());
                TimeSpan totalHoursWorked = timeOut - timeIn;
                row["TotalHoursWorked"] = (int)totalHoursWorked.TotalHours;
            }
        }
        UpdateDatabase(dt);
    }

    private void UpdateDatabase(DataTable dt)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                foreach (DataRow row in dt.Rows)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE AttendanceDetailsTbl SET TotalHoursWorked = @TotalHoursWorked WHERE EmpId = @EmpId", connection);
                    cmd.Parameters.AddWithValue("@TotalHoursWorked", row["TotalHoursWorked"]);
                    cmd.Parameters.AddWithValue("@EmpId", row["EmpId"]);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("An error occurred while updating the database: " + ex.Message);
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        ButtonSearch_Click(sender, e);
    }
}
