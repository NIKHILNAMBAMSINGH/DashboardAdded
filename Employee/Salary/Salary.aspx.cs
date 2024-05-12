﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Employee_Salary_Salary : System.Web.UI.Page
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
                dddType.Items.Insert(0, new ListItem("Select Type", ""));
                PopulateMonthDropdown();

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }

    public class EmployeeDetails
    {
        public string EmployeeName { get; set; }
        public string EmployeeID { get; set; }
    }

    private void PopulateMonthDropdown()
    {
        for (int i = 1; i <= 12; i++)
        {
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
            ddlMonth.Items.Add(new ListItem(monthName, i.ToString()));
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
    protected void btnSearchSalary_Click(object sender, EventArgs e)
    {
        int empId = int.Parse(Session["EmployeeId"].ToString());

        string leaveStatus = dddType.SelectedValue;
       
        string Month = ddlMonth.SelectedValue;

        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "";
                if (leaveStatus == "EarningDetailsTbl")
                {
                    lblMessage.Text = "Earning List";
                    query = "SELECT * FROM " + leaveStatus + " WHERE EmpId = @EmpId AND Month=@Month";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@EmpId", empId);
                    adapter.SelectCommand.Parameters.AddWithValue("@Month", Month);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    GridViewEarning.DataSource = dt;
                    GridViewEarning.DataBind();

                    GridViewEarning.Visible = true;
                    GridViewDeduction.Visible = false;
                }
                else if (leaveStatus == "DeductionDetailsTbl")
                {
                    lblMessage.Text = "Deduction List";
                    query = "SELECT * FROM " + leaveStatus + " WHERE EmpId = @EmpId AND Month=@Month";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@EmpId", empId);
                    adapter.SelectCommand.Parameters.AddWithValue("@Month", Month);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    GridViewDeduction.DataSource = dt;
                    GridViewDeduction.DataBind();

                   
                    GridViewEarning.Visible = false;
                    GridViewDeduction.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Invalid leave status.";
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("An error occurred: " + ex.Message);
            throw;
        }
    }
}