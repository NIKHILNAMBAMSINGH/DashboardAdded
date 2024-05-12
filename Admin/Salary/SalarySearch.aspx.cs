﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Admin_Salary_SalarySearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindEmployeeId();
            PopulateMonthDropdown();

        }

    }

    private void BindEmployeeId()
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT EmpId FROM dbo.EmployeeDetailsTbl";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            ddlEmpId.DataSource = reader;
            ddlEmpId.DataTextField = "EmpId";
            ddlEmpId.DataValueField = "EmpId";
            ddlEmpId.DataBind();
        }
        ddlEmpId.Items.Insert(0, new ListItem("Select empId", ""));
    }

    protected void GetEmpId(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlEmpId.SelectedValue))
        {
            int selectedEmpId = int.Parse(ddlEmpId.SelectedValue);
            string empName = GetEmployeeName(selectedEmpId);
            txtEmpName.Text = empName;
        }

        else
        {
            lblMessage.Text = "Employee Code is not present";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
    private string GetEmployeeName(int EmpId)
    {
        string employeeName = null;
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "select CONCAT(FirstName, ' ', LastName) as Name from dbo.EmployeeDetailsTbl where EmpId=@EmpId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmpId", EmpId);
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    employeeName = result.ToString();
                }
            }
        }
        return employeeName;
    }
    private void PopulateMonthDropdown()
    {
        for (int i = 1; i <= 12; i++)
        {
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
            ddlMonth.Items.Add(new ListItem(monthName, i.ToString()));
        }
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        btnSearchSalary_Click(sender, e);
    }


    protected void btnSearchSalary_Click(object sender, EventArgs e)
    {
        int EmpId = int.Parse(ddlEmpId.SelectedValue);
        DateTime now = DateTime.Now;
        int month = now.Month;
        string MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        int year = now.Year;
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM dbo.earningDetailsTbl WHERE EmpId = @EmpId AND Month = @Month AND Year = @Year";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@EmpId", EmpId);
                adapter.SelectCommand.Parameters.AddWithValue("@Month", MonthName);
                adapter.SelectCommand.Parameters.AddWithValue("@Year", year);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }
}