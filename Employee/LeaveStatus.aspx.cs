using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class Employee_LeaveStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        DateTime DateFrom, DateTo;

        if (DateTime.TryParse(TextBoxLeaveFrom.Text, out DateFrom) && DateTime.TryParse(TextBoxLeaveTo.Text, out DateTo))
        {
            DataTable dt = FetchDataFromDatabase(DateFrom, DateTo);
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
                string query = "SELECT * FROM dbo.LeaveDetailsTbl WHERE EmpId = @EmpId AND StartDate >= @DateFrom AND EndDate <= @DateTo";
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

    private void DeleteLeave(int leaveId)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM dbo.LeaveDetailsTbl WHERE LeaveId = @LeaveId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LeaveId", leaveId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Response.Write("An error occurred while deleting the leave: " + ex.Message);
            throw;
        }
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BtnSearch_Click(sender, e);
       
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowIndex = e.RowIndex;
        int leaveId = Convert.ToInt32(GridView1.DataKeys[rowIndex].Value);
        DeleteLeave(leaveId);
        BtnSearch_Click(sender, e); 
    }
}

   


