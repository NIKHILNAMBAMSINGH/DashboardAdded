using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employee_Employee : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["EmployeeId"] != null)
            {
                int employeeId;
                if (int.TryParse(Session["EmployeeId"].ToString(), out employeeId) && employeeId != 0)
                {
                    LabelForEmpId.Text = Session["EmployeeName"].ToString();
                    //LabelForEmpId.Text = "Employee ID: " + employeeId;
                }
                else
                {
                    LabelForEmpId.Text = "Employee ID is not in a valid format.";
                }
            }
            else
            {
                LabelForEmpId.Text = "Employee ID not found in session.";
            }
        }
    }
}
