﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
public partial class Admin_Salary_Deductions : System.Web.UI.Page
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
            string query = "SELECT EmpId FROM dbo.EarningDetailsTbl;";
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
                lblMessage.Text = "Deduction for the selected employee, month, and year already exists!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                btnDeductionSave.Enabled = false;
                DisableTextFields();
                
            }
            else
            {
                btnDeductionSave.Enabled = true;
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
            btnDeductionSave.Enabled = false;
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

    protected void btnSaveDeduction_Click(object sender, EventArgs e)
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        int EmpId = Convert.ToInt32(ddlEmpId.SelectedValue);
        decimal IncomeTax = Convert.ToDecimal(txtIncomeTax.Text.Trim());
        decimal ProvidentFund = Convert.ToDecimal(txtProvidentFund.Text.Trim());
        decimal ProfessionalTax = Convert.ToDecimal(txtProfessionalTax.Text.Trim());
        decimal OtherDeduction = Convert.ToDecimal(txtOtherDeduction.Text.Trim());

        decimal totalDeduction = IncomeTax + ProvidentFund + ProfessionalTax + OtherDeduction;
        txtTotalDeduction.Text = totalDeduction.ToString();

        DateTime now = DateTime.Now;
        int month = now.Month;
        int year = now.Year;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO dbo.DeductionDetailsTbl (EmpId, IncomeTax, ProvidentFund,ProfessionalTax, OtherDeduction, TotalDeduction, Month, Year)" +
                           "VALUES (@EmpId, @IncomeTax, @ProvidentFund, @ProfessionalTax, @OtherDeduction, @TotalDeduction, @Month, @Year)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmpId", EmpId);
            command.Parameters.AddWithValue("@IncomeTax", IncomeTax);
            command.Parameters.AddWithValue("@ProvidentFund", ProvidentFund);
            command.Parameters.AddWithValue("@ProfessionalTax", ProfessionalTax);
            command.Parameters.AddWithValue("@OtherDeduction", OtherDeduction);
            command.Parameters.AddWithValue("@TotalDeduction", totalDeduction);
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
                    ClearTextFields();
                }
                else
                {
                    lblMessage.Text = "Failed to add ";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
        }
    }

    private bool DeductionExists(int empId, int month, int year)
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT COUNT(*) FROM dbo.DeductionDetailsTbl WHERE EmpId = @EmpId AND Month = @Month AND Year = @Year";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmpId", empId);
            command.Parameters.AddWithValue("@Month", month);
            command.Parameters.AddWithValue("@Year", year);

            connection.Open();
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }
    }


    protected void txtIncome_TaxChanged(object sender, EventArgs e)
    {
        CalculateTotalEarning();
    }

    protected void txtProvidentFund_TaxChanged(object sender, EventArgs e)
    {
        CalculateTotalEarning();
    }

    protected void txtProfessional_TaxChanged(object sender, EventArgs e)
    {
        CalculateTotalEarning();
    }

    protected void txtOtherDeduction_TaxChanged(object sender, EventArgs e)
    {
        CalculateTotalEarning();
    }


    private void CalculateTotalEarning()
    {
        decimal IncomeTax = string.IsNullOrEmpty(txtIncomeTax.Text) ? 0 : Convert.ToDecimal(txtIncomeTax.Text.Trim());
        decimal ProvidentFund = string.IsNullOrEmpty(txtProvidentFund.Text) ? 0 : Convert.ToDecimal(txtProvidentFund.Text.Trim());
        decimal ProfessionalTax = string.IsNullOrEmpty(txtProfessionalTax.Text) ? 0 : Convert.ToDecimal(txtProfessionalTax.Text.Trim());
        decimal OtherDeduction = string.IsNullOrEmpty(txtOtherDeduction.Text) ? 0 : Convert.ToDecimal(txtOtherDeduction.Text.Trim());

        decimal totalDeduction = IncomeTax + ProvidentFund + ProfessionalTax + OtherDeduction;

        txtTotalDeduction.Text = totalDeduction.ToString();
    }

    private void ClearTextFields()
    {
        txtEmpName.Text = "";
        txtIncomeTax.Text = "";
        txtProvidentFund.Text = "";
        txtProfessionalTax.Text = "";
        txtMonth.Text = "";
        txtYear.Text ="";
        txtOtherDeduction.Text = "";
        txtTotalDeduction.Text = "";
    }

    private void EnableTextFields()
    {
        txtIncomeTax.Enabled = true;
        txtProfessionalTax.Enabled = true;
        txtProvidentFund.Enabled = true;
        txtOtherDeduction.Enabled = true;
        txtTotalDeduction.Enabled = true;
    }

    private void DisableTextFields()
    {
        txtIncomeTax.Enabled = false;
        txtProfessionalTax.Enabled = false;
        txtProvidentFund.Enabled = false;
        txtOtherDeduction.Enabled = false;
        txtTotalDeduction.Enabled = false;
    }
}