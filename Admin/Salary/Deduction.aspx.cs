using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Admin_Salary_Deduction : System.Web.UI.Page{

protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEmployeeId();
            PopulateMonthDropdown();
        }
    }
protected void txtBasicSalary_TextChanged(object sender, EventArgs e)
{
    CalculateTotalDeduction();
}

    private void BindEmployeeId()
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT EmpId FROM dbo.EarningDetailsTbl";
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
        decimal IncomeTax = Convert.ToDecimal(txtIncomeTax.Text.Trim());
        decimal ProvidentFund = Convert.ToDecimal(txtProvidentFund.Text.Trim());
        decimal ProfessionalTax = Convert.ToDecimal(txtProfessionalTax.Text.Trim());
        decimal OtherDeduction = Convert.ToDecimal(txtOtherDeduction.Text.Trim());
        decimal AttendanceDeduction = Convert.ToDecimal(txtAttendanceDeduction.Text.Trim());
        decimal LeaveDeduction = Convert.ToDecimal(txtLeaveDeduction.Text.Trim());

        decimal totalDeduction = IncomeTax + ProvidentFund + ProfessionalTax + OtherDeduction + AttendanceDeduction + LeaveDeduction;
        txtTotalEarning.Text = totalDeduction.ToString();

        DateTime now = DateTime.Now;
        int month = now.Month;
        string MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        int year = now.Year;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO dbo.DeductionDetailsTbl (EmpId, IncomeTax, ProvidentFund, ProfessionalTax, OtherDeduction, TotalDeduction, Month, Year, AttendanceDeduction, LeaveDeduction)" +
                           "VALUES (@EmpId, @IncomeTax, @ProvidentFund, @ProfessionalTax, @OtherDeduction, @TotalDeduction, @Month, @Year, @AttendanceDeduction, @LeaveDeduction)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmpId", EmpId);
            command.Parameters.AddWithValue("@IncomeTax", IncomeTax);
            command.Parameters.AddWithValue("@ProvidentFund", ProvidentFund);
            command.Parameters.AddWithValue("@ProfessionalTax", ProfessionalTax);
            command.Parameters.AddWithValue("@OtherDeduction", OtherDeduction);
            command.Parameters.AddWithValue("@TotalDeduction", totalDeduction);
            command.Parameters.AddWithValue("@LeaveDeduction", LeaveDeduction);
            command.Parameters.AddWithValue("@AttendanceDeduction", AttendanceDeduction);
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
                lblMessage.Text = "An error occurred: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void txtIncomeTax_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalDeduction();
    }

    protected void txtProvidentFund_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalDeduction();
    }

    protected void txtProfessionalTax_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalDeduction();
    }

    protected void txtOtherDeduction_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalDeduction();
    }

    protected void txtAttendanceDeduction_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalDeduction();
    }

    protected void txtLeaveDeduction_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalDeduction();
    }
    protected void txtAllowances_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalDeduction();
    }



    private void CalculateTotalDeduction()
    {
        decimal IncomeTax = string.IsNullOrEmpty(txtIncomeTax.Text) ? 0 : Convert.ToDecimal(txtIncomeTax.Text.Trim());
        decimal ProvidentFund = string.IsNullOrEmpty(txtProvidentFund.Text) ? 0 : Convert.ToDecimal(txtProvidentFund.Text.Trim());
        decimal ProfessionalTax = string.IsNullOrEmpty(txtProfessionalTax.Text) ? 0 : Convert.ToDecimal(txtProfessionalTax.Text.Trim());
        decimal OtherDeduction = string.IsNullOrEmpty(txtOtherDeduction.Text) ? 0 : Convert.ToDecimal(txtOtherDeduction.Text.Trim());
        decimal AttendanceDeduction = string.IsNullOrEmpty(txtAttendanceDeduction.Text) ? 0 : Convert.ToDecimal(txtAttendanceDeduction.Text.Trim());
        decimal LeaveDeduction = string.IsNullOrEmpty(txtLeaveDeduction.Text) ? 0 : Convert.ToDecimal(txtLeaveDeduction.Text.Trim());

        decimal totalDeduction = IncomeTax + ProvidentFund + ProfessionalTax + OtherDeduction + AttendanceDeduction + LeaveDeduction;

        txtTotalEarning.Text = totalDeduction.ToString();
    }

    private void ClearTextFields()
    {
        txtEmpName.Text = "";
        txtIncomeTax.Text = "";
        txtLeaveDeduction.Text = "";
        txtOtherDeduction.Text = "";
        txtProfessionalTax.Text = "";
        txtProvidentFund.Text = "";
        txtTotalEarning.Text = "";
        txtAttendanceDeduction.Text = "";
    }

    private void EnableTextFields()
    {
        txtIncomeTax.Enabled = true;
        txtLeaveDeduction.Enabled = true;
        txtOtherDeduction.Enabled = true;
        txtProfessionalTax.Enabled = true;
        txtProvidentFund.Enabled = true;
        txtAttendanceDeduction.Enabled = true;
        txtTotalEarning.Enabled = true;
        btnSaveSalary.Enabled = true;
    }

    private void DisableTextFields()
    {
        txtIncomeTax.Enabled = false;
        txtLeaveDeduction.Enabled = false;
        txtOtherDeduction.Enabled = false;
        txtProfessionalTax.Enabled = false;
        txtProvidentFund.Enabled = false;
        txtAttendanceDeduction.Enabled = false;
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
            string query = "SELECT COUNT(*) FROM dbo.DeductionDetailsTbl WHERE EmpId = @EmpId AND Month = @Month AND Year = @Year";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmpId", EmpId);
            command.Parameters.AddWithValue("@Month", MonthName);
            command.Parameters.AddWithValue("@Year", year);
             try
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    lblMessage.Text = "Deduction for the selected employee, month, and year already exists!";
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
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
