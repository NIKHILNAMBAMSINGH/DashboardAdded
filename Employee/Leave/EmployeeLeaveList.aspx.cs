﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Employee_Leave_EmployeeLeaveList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["EmployeeId"] != null)
            {
                EmployeeDetails employee = RetrieveEmployeeDetailsFromDatabase();
                txtEmpCode.Text = employee.EmployeeID;
                txtEmpName.Text = employee.EmployeeName;
                DisableTextBoxes();

                dddlLeaveStatus.Items.Insert(0, new ListItem("Select Leave Status", ""));
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }

    private void DisableTextBoxes()
    {
        txtEmpCode.Enabled = false;
        txtEmpName.Enabled = false;
    }

    private EmployeeDetails RetrieveEmployeeDetailsFromDatabase()
    {
        int employeeId = Convert.ToInt32(Session["EmployeeId"]);
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM EmployeeDetailsTbl WHERE EmpId=@employeeId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@employeeId", employeeId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    EmployeeDetails employee = new EmployeeDetails
                    {
                        EmployeeName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString(),
                        EmployeeID = reader["EmpId"].ToString(),
                    };

                    return employee;
                }
                else
                {
                    return null;
                }
            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        ShowAllLeaves_Click(sender, e);
       

    }

    public class EmployeeDetails
    {
        public string EmployeeName { get; set; }
        public string EmployeeID { get; set; }
    }

    protected void ShowLeaveByCode_Click(object sender, EventArgs e)
    {
        int empId = int.Parse(Session["EmployeeId"].ToString());

        DateTime DateFrom, DateTo;
        if (DateTime.TryParseExact(TextBoxLeaveFrom.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateFrom) &&
            DateTime.TryParseExact(TextBoxLeaveTo.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTo))
        {
            string leaveStatus = dddlLeaveStatus.SelectedValue;
            lblMessage.Text = leaveStatus;
            try
            {
                string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {

                    string query = "SELECT e.EmpId as EmpId, l.LeaveId as LeaveId, CONCAT(e.FirstName, ' ', e.LastName) AS EmpName, l.LeaveType, l.StartDate, l.EndDate, l.NoOfDays, l.LeaveStatus, l.Reason, l.AddedDate as AddedDate FROM dbo.LeaveDetailsTbl l LEFT JOIN dbo.EmployeeDetailsTbl e ON l.EmpId = e.EmpId WHERE l.EmpId = @EmpId AND l.LeaveStatus = @LeaveStatus AND l.StartDate >= @DateFrom AND l.EndDate <= @DateTo";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@EmpId", empId);
                    adapter.SelectCommand.Parameters.AddWithValue("@DateFrom", DateFrom);
                    adapter.SelectCommand.Parameters.AddWithValue("@DateTo", DateTo);
                    adapter.SelectCommand.Parameters.AddWithValue("@LeaveStatus", leaveStatus);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
                throw;
            }
        }
        else
        {

            Response.Write("Invalid date format. Please enter dates in the format dd/MM/yyyy.");
        }
    }
    protected void ShowAllLeaves_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "All Leaves";
        int empId = int.Parse(Session["EmployeeId"].ToString());

        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                string query = "SELECT e.EmpId as EmpId, l.LeaveId as LeaveId, CONCAT(e.FirstName, ' ', e.LastName) AS EmpName, l.LeaveType, l.StartDate, l.EndDate, l.NoOfDays, l.LeaveStatus, l.Reason, l.AddedDate as AddedDate FROM dbo.LeaveDetailsTbl l LEFT JOIN dbo.EmployeeDetailsTbl e ON l.EmpId = e.EmpId ";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write("An error occurred: " + ex.Message);
            throw;
        }
    }

}