﻿﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Admin_Salary_NetSalary : System.Web.UI.Page
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

    protected void btnSearchSalary_Click(object sender, EventArgs e)
    {
        int empId = int.Parse(ddlEmpId.SelectedValue);
        DateTime now = DateTime.Now;
        int year = now.Year;
        string month = ddlMonth.SelectedValue;

        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT e.TotalEarning as TotalEarning, d.TotalDeduction as TotalDeduction FROM dbo.EarningDetailsTbl e LEFT JOIN dbo.DeductionDetailsTbl d ON e.EmpId = d.DeductionId WHERE e.Month = @Month AND d.Month = @Month AND e.EmpId = @employeeId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@employeeId", empId);
                command.Parameters.AddWithValue("@Month", month);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    EmployeeSalary salary = new EmployeeSalary();

                    salary.TotalEarning = Convert.ToInt32(reader["TotalEarning"]);
                    salary.TotalDeduction = Convert.ToInt32(reader["TotalDeduction"]);
                    salary.NetPayable = salary.TotalEarning - salary.TotalDeduction;

                    txtNetTotalEarning.Text = salary.TotalEarning.ToString();
                    txtNetTotalDeduction.Text = salary.TotalDeduction.ToString();
                    txtNetPayable.Text = salary.NetPayable.ToString();

                }


                else
                {
                    txtNetTotalEarning.Text = "0";
                    txtNetTotalDeduction.Text = "0";
                    txtNetPayable.Text = "0";
                }
            }
        }
    }


    protected class EmployeeSalary
    {
        public int TotalEarning { get; set; }
        public int TotalDeduction { get; set; }
        public int NetPayable { get; set; }
    }

    protected void btnSaveNetSalary_Click(object sender, EventArgs e)
    {

        int empId = int.Parse(ddlEmpId.SelectedValue);
        string month = ddlMonth.SelectedValue;
        int year = DateTime.Now.Year;
        int netPayable = int.Parse(txtNetPayable.Text);

        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        string queryCheckExists = "SELECT COUNT(*) FROM NetSalaryDetailsTbl WHERE EmpId = @EmpId AND Month = @Month AND Year = @Year";
        string queryInsert = "INSERT INTO NetSalaryDetailsTbl (EmpId, Month, Year, NetSalary) VALUES (@EmpId, @Month, @Year, @NetSalary)";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            using (SqlCommand commandCheckExists = new SqlCommand(queryCheckExists, connection))
            using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
            {
                commandCheckExists.Parameters.AddWithValue("@EmpId", empId);
                commandCheckExists.Parameters.AddWithValue("@Month", month);
                commandCheckExists.Parameters.AddWithValue("@Year", year);

                try
                {
                    connection.Open();
                    int existingRecordsCount = (int)commandCheckExists.ExecuteScalar();

                    if (existingRecordsCount > 0)
                    {
                        lblMessage.Text = "Net salary for the selected employee and month already exists.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    commandInsert.Parameters.AddWithValue("@EmpId", empId);
                    commandInsert.Parameters.AddWithValue("@Month", month);
                    commandInsert.Parameters.AddWithValue("@Year", year);
                    commandInsert.Parameters.AddWithValue("@NetSalary", netPayable);

                    int rowsAffected = commandInsert.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Net salary saved successfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Failed to save net salary.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An error occurred while saving net salary: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}