﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Globalization;


public partial class Employee_Leave_ApplyLeave : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CalendarFrom.StartDate = DateTime.Now.AddYears(-11);
            CalendarTo.EndDate = DateTime.Now.AddYears(+11);

            if (Session["EmployeeId"] != null)
            {
                EmployeeDetails employee = RetrieveEmployeeDetailsFromDatabase();
                txtEmpCode.Text = employee.EmployeeID;
                txtEmpName.Text = employee.EmployeeName;
                DisableTextBoxes();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }

    protected void TextBoxLeaveFrom_TextChanged(object sender, EventArgs e)
    {
        UpdateNoOfDays();
    }

    protected void TextBoxLeaveTo_TextChanged(object sender, EventArgs e)
    {
        UpdateNoOfDays();
    }
    private void DisableTextBoxes()
    {
        txtEmpCode.Enabled = false;
        txtEmpName.Enabled = false;
        txtBoxNoOfDays.Enabled = false;
      
    }


    private void UpdateNoOfDays()
    {
        if (!string.IsNullOrEmpty(TextBoxLeaveFrom.Text) && !string.IsNullOrEmpty(TextBoxLeaveTo.Text))
        {
            DateTime FromDate = DateTime.ParseExact(TextBoxLeaveFrom.Text, "dd/MM/yyyy", null);
            DateTime ToDate = DateTime.ParseExact(TextBoxLeaveTo.Text, "dd/MM/yyyy", null);
            TimeSpan TimeDiff = ToDate.AddDays(1).Subtract(FromDate);

            if (TimeDiff.TotalDays <= 0)
            {
                txtBoxNoOfDays.Text = "0";
            }
            else
            {
                int numberOfDays = TimeDiff.Days;
                txtBoxNoOfDays.Text = numberOfDays.ToString();
                DisableTextBoxes();
            }
        }
    }
    protected void BtnSubmitLeave_Click(object sender, EventArgs e)
    {
        int empId = int.Parse(Session["EmployeeId"].ToString());
        DateTime FromDate = DateTime.ParseExact(TextBoxLeaveFrom.Text, "dd/MM/yyyy", null);
        DateTime ToDate = DateTime.ParseExact(TextBoxLeaveTo.Text, "dd/MM/yyyy", null);
        TimeSpan TimeDiff = ToDate.AddDays(1).Subtract(FromDate);
        int numberOfDays = TimeDiff.Days;
       
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO LeaveDetailsTbl(EmpId,LeaveType, StartDate, EndDate, LeaveStatus, Reason, NoOfDays) VALUES (@EmpId,@LeaveType, @LeaveFrom, @LeaveTo, @Status, @Reason, @NoOfDays)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmpId", empId);
                command.Parameters.AddWithValue("@LeaveType", DropDownListLeaveType.SelectedValue);
                command.Parameters.AddWithValue("@LeaveFrom", FromDate);
                command.Parameters.AddWithValue("@LeaveTo", ToDate);
                command.Parameters.AddWithValue("@Status", "Pending");
                command.Parameters.AddWithValue("@Reason", txtLeaveReason.Text);
                
                command.Parameters.AddWithValue("@NoOfDays", numberOfDays);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        TextBoxLeaveFrom.Text = "";
                        TextBoxLeaveTo.Text = "";
                        txtLeaveReason.Text = "";
                        txtBoxNoOfDays.Text = "";
                        lblMessage.ForeColor = System.Drawing.Color.Red;

                        lblMessage.Text = "Leave Applied Successfully";
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    Response.Write("An error occurred: " + ex.Message);
                }
            }
        }
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
    
}
public class EmployeeDetails
{
    public string EmployeeName { get; set; }
    public string EmployeeID { get; set; }
    
}

