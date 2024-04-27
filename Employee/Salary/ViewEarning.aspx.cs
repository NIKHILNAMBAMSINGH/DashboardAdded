﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class Employee_Salary_ViewEarning : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

     if (!IsPostBack)
        {
            SalaryDetails salary =  RetrieveSalaryDetailsFromDatabase();

            if (salary != null)
            {
                txtBasicSalary.Text=salary.BasicSalary;
                txtEmpId.Text = salary.EmployeeID;
                txtEmpName.Text = salary.EmployeeName;
                txtAllowances.Text = salary.BasicSalary;
                txtBonus.Text = salary.Bonus;
                txtMiscellaneous.Text = salary.Miscellaneous;
                txtTotalEarning.Text = salary.TotalEarning;
                txtMonth.Text = salary.Month;
                txtYear.Text = salary.Year;

                DisableTextBoxes();
  
            }
        }
    }
     private SalaryDetails RetrieveSalaryDetailsFromDatabase()
    {
        int employeeId = Convert.ToInt32(Session["EmployeeId"]);
        string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query ="SELECT e.BasicSalary as BasicSalary,e.Allowances as Allowances,e.Miscellaneous as Miscellaneous,e.TotalEarning as TotalEarning, e.Month as Month,e.Year as Year, emp.EmpId as EmpId,CONCAT(emp.FirstName,' ',emp.LastName) as EmpName FROM EarningDetailsTbl e LEFT JOIN EmployeeDetailsTbl emp ON e.EmpId = emp.EmpId WHERE e.EmpId = @employeeId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@employeeId", employeeId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    SalaryDetails employee = new SalaryDetails
                    {
                        EmployeeID = reader["EmpId"].ToString(),
                        EmployeeName=reader["EmpName"].ToString(),
                         BasicSalary = reader["BasicSalary"].ToString(),
                        Allowances = reader["Allowances"].ToString(),
                         Miscellaneous = reader["Miscellaneous"].ToString(),
                       TotalEarning = reader["TotalEarning"].ToString(),
                        Month=reader["Month"].ToString(),
                        Year=reader["Year"].ToString(),
                        
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


    public class SalaryDetails
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string BasicSalary { get; set; }
        public string Allowances { get; set; }
        public string Bonus { get; set; }
        public string Miscellaneous { get; set; }
        public string TotalEarning { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
    }
    private void DisableTextBoxes()
    {
        txtEmpId.Enabled = false;
        txtEmpName.Enabled = false;
        txtBasicSalary.Enabled = false;
        txtBonus.Enabled = false;
        txtAllowances.Enabled = false;
        txtMiscellaneous.Enabled = false;
        txtTotalEarning.Enabled = false;
        txtMonth.Enabled = false;
        txtYear.Enabled = false;

    }
}
 