using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Employee_ApplyForLeave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CalendarFrom.StartDate = DateTime.Now.AddYears(-11);
            CalendarTo.EndDate = DateTime.Now.AddYears(+11);
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

    private void UpdateNoOfDays()
    {
        if (!string.IsNullOrEmpty(TextBoxLeaveFrom.Text) && !string.IsNullOrEmpty(TextBoxLeaveTo.Text))
        {
            DateTime FromDate = DateTime.ParseExact(TextBoxLeaveFrom.Text, "dd/MM/yyyy", null);
            DateTime ToDate = DateTime.ParseExact(TextBoxLeaveTo.Text, "dd/MM/yyyy", null);
            TimeSpan TimeDiff = ToDate - FromDate;
           
            if (TimeDiff.TotalDays <= 0)
            {
                TextBoxNoOfLeave.Text = "0";
            }
            else
            {
                int numberOfDays = TimeDiff.Days;
                TextBoxNoOfLeave.Text = numberOfDays.ToString();
            }
        }
    }
    protected void BtnSubmitLeave_Click(object sender, EventArgs e)
    {
        int empId = int.Parse(Session["EmployeeId"].ToString());
        DateTime FromDate = DateTime.ParseExact(TextBoxLeaveFrom.Text, "dd/MM/yyyy", null);
        DateTime ToDate = DateTime.ParseExact(TextBoxLeaveTo.Text, "dd/MM/yyyy", null);
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
                command.Parameters.AddWithValue("@Reason", TextBoxLeaveReason.Text);
                command.Parameters.AddWithValue("@NoOfDays", TextBoxNoOfLeave.Text);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        TextBoxLeaveFrom.Text = "";
                        TextBoxLeaveTo.Text = "";
                        TextBoxLeaveReason.Text = "";
                        TextBoxNoOfLeave.Text = "";
                       LabelForConfirm.ForeColor=System.Drawing.Color.Red;
                        
                        LabelForConfirm.Text= "Leave Applied Successfully";
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

}