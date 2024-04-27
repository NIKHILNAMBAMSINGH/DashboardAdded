﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
public partial class Employee_Salary_Deduction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            DeductionDetails deduction = RetrieveSalaryDetailsFromDatabase();

            if (deduction != null)
            {
                txtEmpId.Text = deduction.EmployeeID;
                txtIncomeTax.Text = FormatDecimal(deduction.IncomeTax);
                txtProfessionalTax.Text = FormatDecimal(deduction.ProfessionalTax);
                txtProvidentFund.Text = FormatDecimal(deduction.ProvidentFund);
                txtOtherDeduction.Text = FormatDecimal(deduction.OtherDeduction);
                txtTotalDeduction.Text = FormatDecimal(deduction.TotalDeduction);
                txtMonth.Text = deduction.Month;
                txtYear.Text = deduction.Year;

                DisableTextBox();
            }
        }
    }
    private DeductionDetails RetrieveSalaryDetailsFromDatabase()
    {
        int employeeId = Convert.ToInt32(Session["EmployeeId"]);
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM dbo.DeductionDetailsTbl WHERE EmpId=@employeeId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@employeeId", employeeId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    DeductionDetails employee = new DeductionDetails
                    {
                        EmployeeID = reader["EmpId"].ToString(),
                        IncomeTax = reader["IncomeTax"].ToString(),
                        ProfessionalTax = reader["ProfessionalTax"].ToString(),
                        ProvidentFund = reader["ProvidentFund"].ToString(),
                        OtherDeduction = reader["OtherDeduction"].ToString(),
                        TotalDeduction=reader["TotalDeduction"].ToString(),
                        Month = reader["Month"].ToString(),
                        Year = reader["Year"].ToString(),

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
    public class DeductionDetails
    {
        public string EmployeeID { get; set; }
        public string IncomeTax { get; set; }
        public string ProfessionalTax { get; set; }
        public string ProvidentFund { get; set; }
        public string OtherDeduction { get; set; }
        public string TotalDeduction { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
    }

    private void DisableTextBox()
    {
        txtEmpId.Enabled = false;
        txtMonth.Enabled = false;
        txtYear.Enabled = false;
        txtIncomeTax.Enabled = false;
        txtProfessionalTax.Enabled = false;
        txtProvidentFund.Enabled = false;
        txtOtherDeduction.Enabled = false;
        txtTotalDeduction.Enabled = false;

    }
    private string FormatDecimal(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        decimal decimalValue;
        if (decimal.TryParse(value, out decimalValue))
        {
            return decimalValue.ToString("0.0");
        }
        else
        {
            return value;
        }
    }
}