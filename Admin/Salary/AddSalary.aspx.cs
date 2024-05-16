﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Admin_Salary_AddSalary : System.Web.UI.Page
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
            using (SqlDataReader reader = command.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                ddlEmpId.DataSource = dataTable;
                ddlEmpId.DataTextField = "EmpId";
                ddlEmpId.DataValueField = "EmpId";
                ddlEmpId.DataBind();
            }
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
            string query = "SELECT CONCAT(FirstName, ' ', LastName) AS Name FROM dbo.EmployeeDetailsTbl WHERE EmpId=@EmpId";

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

    protected void btnSaveSalary_Click(object sender, EventArgs e)
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        int EmpId = Convert.ToInt32(ddlEmpId.SelectedValue);
        decimal basicSalary = Convert.ToDecimal(txtBasicSalary.Text.Trim());
        decimal allowances = Convert.ToDecimal(txtAllowances.Text.Trim());
        decimal bonus = Convert.ToDecimal(txtBonus.Text.Trim());
        decimal miscellaneous = Convert.ToDecimal(txtMiscellaneous.Text.Trim());

        decimal totalEarning = basicSalary + allowances + bonus + miscellaneous;
        txtTotalEarning.Text = totalEarning.ToString();

        DateTime now = DateTime.Now;
        int month = now.Month;
        string MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        int year = now.Year;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO EarningDetailsTbl (EmpId, BasicSalary, Allowances, Bonus, Miscellaneous, TotalEarning, Month, Year)" +
                           "VALUES (@EmpId, @BasicSalary, @Allowances, @Bonus, @Miscellaneous, @TotalEarning, @Month, @Year)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmpId", EmpId);
            command.Parameters.AddWithValue("@BasicSalary", basicSalary);
            command.Parameters.AddWithValue("@Allowances", allowances);
            command.Parameters.AddWithValue("@Bonus", bonus);
            command.Parameters.AddWithValue("@Miscellaneous", miscellaneous);
            command.Parameters.AddWithValue("@TotalEarning", totalEarning);
            command.Parameters.AddWithValue("@Month", MonthName);
            command.Parameters.AddWithValue("@Year", year);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    lblMessage.Text = "Added successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Failed to add designation";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
        }
    }

    protected void txtBasicSalary_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalEarning();
    }

    protected void txtAllowances_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalEarning();
    }

    protected void txtBonus_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalEarning();
    }

    protected void txtMiscellaneous_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalEarning();
    }

    private void CalculateTotalEarning()
    {
        decimal basicSalary = string.IsNullOrEmpty(txtBasicSalary.Text) ? 0 : Convert.ToDecimal(txtBasicSalary.Text.Trim());
        decimal allowances = string.IsNullOrEmpty(txtAllowances.Text) ? 0 : Convert.ToDecimal(txtAllowances.Text.Trim());
        decimal bonus = string.IsNullOrEmpty(txtBonus.Text) ? 0 : Convert.ToDecimal(txtBonus.Text.Trim());
        decimal miscellaneous = string.IsNullOrEmpty(txtMiscellaneous.Text) ? 0 : Convert.ToDecimal(txtMiscellaneous.Text.Trim());

        decimal totalEarning = basicSalary + allowances + bonus + miscellaneous;

        txtTotalEarning.Text = totalEarning.ToString();
    }

    private void ClearTextFields()
    {
        txtEmpName.Text = "";
        txtBasicSalary.Text = "";
        txtBonus.Text = "";
        txtAllowances.Text = "";
        txtMiscellaneous.Text = "";
        txtTotalEarning.Text = "";
    }

    private void EnableTextFields()
    {
        txtBasicSalary.Enabled = true;
        txtBonus.Enabled = true;
        txtAllowances.Enabled = true;
        txtMiscellaneous.Enabled = true;
        txtTotalEarning.Enabled = true;
        btnSaveSalary.Enabled = true;
    }

    private void DisableTextFields()
    {
        txtBasicSalary.Enabled = false;
        txtBonus.Enabled = false;
        txtAllowances.Enabled = false;
        txtMiscellaneous.Enabled = false;
        txtTotalEarning.Enabled = false;
        btnSaveSalary.Enabled = false;
    }

    protected void btnSearchSalary_Click(object sender, EventArgs e)
    {
        int EmpId = int.Parse(ddlEmpId.SelectedValue);
        DateTime now = DateTime.Now;
        int month = now.Month;
        string MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        int year = now.Year;
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT COUNT(*) FROM dbo.earningDetailsTbl WHERE EmpId = @EmpId AND Month = @Month AND Year = @Year";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmpId", EmpId);
            command.Parameters.AddWithValue("@Month", MonthName);
            command.Parameters.AddWithValue("@Year", year);

            connection.Open();
            int count = (int)command.ExecuteScalar();
            if (count > 0)
            {
                lblMessage.Text = "Earning for the selected employee, month, and year already exists!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                DisableTextFields();
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.ForeColor = System.Drawing.Color.Black;
                EnableTextFields();
            }
        }
    }
}