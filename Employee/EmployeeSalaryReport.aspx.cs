using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class Employee_EmployeeSalaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            for (int year = DateTime.Now.Year - 3; year <= DateTime.Now.Year; year++)
            {
                DropDownListForYears.Items.Add(new ListItem(year.ToString(), year.ToString()));
            }

          
           
            DropDownListForYears.SelectedValue = DateTime.Now.Year.ToString();
        }
    }

    protected void ButtonView_Click(object sender, EventArgs e)
    {
        string selectedYear = DropDownListForYears.SelectedValue;
        FetchEmployeeSalary(selectedYear);
    }


    protected void FetchEmployeeSalary(string selectedYear)
    {

        int empId = int.Parse(Session["EmployeeId"].ToString());
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        DateTime dt = DateTime.Now;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT e.EmpId as EmpId,CONCAT(e.FirstName,' ',e.LastName) as EmployeeName, design.DesignationName as Designation , d.DeptName as DepartmentName,CAST(s.BasicSalary as float) as BasicSalary,CAST(s.Allowances as float) as Allowances, s.TotalLeaveDays as TotalLeaveDays,s.TotalWorkedDays as TotalWorkedDays, cast(s.Deduction as float) as Deduction ,CAST(s.NetSalary as float) as NetSalary  FROM EmployeeDetailsTbl e left join DepartmentDetailsTbl d on e. DepartmentId=d.DeptId left join DesignationDetailsTbl design on e.DepartmentId=design.DesignationId left join dbo.SalaryDetailsTbl s on e.EmpId=s.EmpId where e.EmpId=@EmpId AND s.Month=@Month AND s.Year=@Year";

            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@EmpId",empId );
                command.Parameters.AddWithValue("@Month", DropDownListForMonths.SelectedValue);
                command.Parameters.AddWithValue("@Year", selectedYear);



                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    EmployeeSalaryReport employee = new EmployeeSalaryReport
                    {
                        EmployeeID = reader["EmpId"].ToString(),
                        EmployeeName = reader["EmployeeName"].ToString(),
                        Designation = reader["Designation"].ToString(),
                        DepartmentName = reader["DepartmentName"].ToString(),
                        BasicSalary = reader["BasicSalary"].ToString(),
                        Allowances = reader["Allowances"].ToString(),
                        TotalLeaveDays = reader["TotalLeaveDays"].ToString(),
                        TotalWorkedDays = reader["TotalWorkedDays"].ToString(),
                        Deduction = reader["Deduction"].ToString(),
                        NetSalary = reader["NetSalary"].ToString(),

                    };


                    TextBoxEmpID.Text = employee.EmployeeID;
                    TextBoxEmployeeName.Text = employee.EmployeeName;
                    TextBoxDesignation.Text = employee.Designation;
                    TextBoxDepartmentName.Text = employee.DepartmentName;
                    TextBoxBasicPay.Text = employee.BasicSalary;
                    TextBoxAllowances.Text = employee.Allowances;
                    TextBoxTotalLeaveDays.Text = employee.TotalLeaveDays;
                    TextBoxTotalWorkedDays.Text = employee.TotalWorkedDays;
                    TextBoxDeductions.Text = employee.Deduction;
                    TextBoxNetSalary.Text = employee.NetSalary;

                }
                else
                {

                }
            }
        }
    }

    public class EmployeeSalaryReport
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string DepartmentName { get; set; }
        public string BasicSalary { get; set; }
        public string Allowances { get; set; }
        public string TotalLeaveDays { get; set; }
        public string TotalWorkedDays { get; set; }
        public string Deduction { get; set; }
        public string NetSalary { get; set; }
    }
}

