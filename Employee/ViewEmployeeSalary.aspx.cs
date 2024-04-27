using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class Employee_ViewEmployeeSalary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EmployeeSalary employeeSalary = fetchEmployeeSalary();
            if (employeeSalary != null)
            {
                TextBoxEmpID.Text = employeeSalary.EmployeeID;
                TextBoxEmployeeName.Text = employeeSalary.EmployeeName;
                TextBoxDesignation.Text = employeeSalary.Designation;
                TextBoxDepartmentName.Text = employeeSalary.DepartmentName;
                TextBoxBasicPay.Text = employeeSalary.BasicSalary;
                TextBoxAllowances.Text = employeeSalary.Allowances;
                TextBoxTotalLeaveDays.Text = employeeSalary.TotalLeaveDays;
                TextBoxTotalWorkedDays.Text = employeeSalary.TotalWorkedDays;
                TextBoxDeductions.Text = employeeSalary.Deduction;
                TextBoxNetSalary.Text = employeeSalary.NetSalary;
            }
            else
            {
                // Handle case where employee salary data is not found
            }
        }
    }
    protected EmployeeSalary fetchEmployeeSalary()
    {
        int empId = int.Parse(Session["EmployeeId"].ToString());
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"SELECT e.EmpId as EmpId, CONCAT(e.FirstName,' ',e.LastName) as EmployeeName, 
                        design.DesignationName as Designation, d.DeptName as DepartmentName, 
                        CAST(s.BasicSalary as float) as BasicSalary, CAST(s.Allowances as float) as Allowances, 
                        s.TotalLeaveDays as TotalLeaveDays, s.TotalWorkedDays as TotalWorkedDays, 
                        CAST(s.Deduction as float) as Deduction, CAST(s.NetSalary as float) as NetSalary 
                        FROM EmployeeDetailsTbl e 
                        LEFT JOIN DepartmentDetailsTbl d ON e.DepartmentId = d.DeptId 
                        LEFT JOIN DesignationDetailsTbl design ON e.DepartmentId = design.DesignationId 
                        LEFT JOIN dbo.SalaryDetailsTbl s ON e.EmpId = s.EmpId 
                        WHERE e.EmpId = @EmpId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmpId", empId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        EmployeeSalary employeeSalary = new EmployeeSalary
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
                            NetSalary = reader["NetSalary"].ToString()
                        };

                        return employeeSalary;
                    }
                    else
                    {
                        // No data found for the employee
                        throw new Exception("No salary data found for the employee.");
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as required
                    throw; // Re-throw the exception to propagate it to the caller
                }
            }
        }
    }
    public class EmployeeSalary
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