﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Admin_Salary_AddSalary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindEmployeeId();

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
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;
            if (DeductionExists(selectedEmpId, month, year))
            {
                lblMessage.Text = "Earning for the selected employee, month, and year already exists!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                btnSaveSalary.Enabled = false;
                DisableTextFields();

            }
            else
            {
                btnSaveSalary.Enabled = true;
                lblMessage.Text = "";
                EnableTextFields();
                string empName = GetEmployeeName(selectedEmpId);
                txtEmpName.Text = empName;
                txtMonth.Text = month.ToString();
                txtYear.Text = year.ToString();
            }
        }
        else
        {
            btnSaveSalary.Enabled = false;
            DisableTextFields();
            txtEmpName.Text = "";
            lblMessage.Text = "";
            txtMonth.Text = "";
            txtYear.Text = "";
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
            command.Parameters.AddWithValue("@Month", month);
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

    private bool DeductionExists(int empId, int month, int year)
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT COUNT(*) FROM dbo.earningDetailsTbl WHERE EmpId = @EmpId AND Month = @Month AND Year = @Year";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmpId", empId);
            command.Parameters.AddWithValue("@Month", month);
            command.Parameters.AddWithValue("@Year", year);

            connection.Open();
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }
    }
    private void ClearTextFields()
    {
        txtEmpName.Text = "";
        txtBasicSalary.Text = "";
        txtBonus.Text = "";
        txtAllowances.Text = "";
        txtMiscellaneous.Text = "";
        txtTotalEarning.Text = "";
        txtMonth.Text = "";
        txtYear.Text = "";
       
    }

    private void EnableTextFields()
    {
        txtBasicSalary.Enabled = true;
        txtBonus.Enabled = true;
        txtAllowances.Enabled = true;
        txtMiscellaneous.Enabled = true;
        txtTotalEarning.Enabled = true;
    }

    private void DisableTextFields()
    {
        txtBasicSalary.Enabled = false;
        txtBonus.Enabled = false;
        txtAllowances.Enabled = false;
        txtMiscellaneous.Enabled = false;
        txtTotalEarning.Enabled = false;
    }
}