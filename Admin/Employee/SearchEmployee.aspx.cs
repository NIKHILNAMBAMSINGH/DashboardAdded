<<<<<<< HEAD
﻿﻿using System;
=======
﻿﻿﻿using System;
>>>>>>> cb92eb5b2e9038612fdacf5d98757c880099271b
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
<<<<<<< HEAD
=======


>>>>>>> cb92eb5b2e9038612fdacf5d98757c880099271b
public partial class Admin_Employee_SearchEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearchDesignation_Click(object sender, EventArgs e)
    {
<<<<<<< HEAD

=======
>>>>>>> cb92eb5b2e9038612fdacf5d98757c880099271b
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            int EmpId = Convert.ToInt32(txtDeptId.Text);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
<<<<<<< HEAD
                string query = "SELECT E.*,  D.DeptName as Department, DD.DesignationName as Designation FROM dbo.EmployeeDetailsTbl AS E LEFT JOIN dbo.DepartmentDetailsTbl AS D ON E.DepartmentId = D.DeptId LEFT JOIN dbo.DesignationDetailsTbl AS DD ON E.DesignationId = DD.DesignationId WHERE EmpId = @EmpId";
=======
                string query = "SELECT * FROM dbo.EmployeeDetailsTbl where EmpId=@EmpId";
>>>>>>> cb92eb5b2e9038612fdacf5d98757c880099271b
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@EmpId", EmpId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.EmptyDataText = "No Records Found";
                    GridView2.ShowHeaderWhenEmpty = true;
                }
            }
        }
        catch (Exception ex)
        {
<<<<<<< HEAD
            
        }
    }

   
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM dbo.EmployeeDetailsTbl";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }


=======

        }
    }

>>>>>>> cb92eb5b2e9038612fdacf5d98757c880099271b
    protected void btnResetDesignation_Click(object sender, EventArgs e)
    {
        txtDeptId.Text = "";
        txtDeptName.Text = "";
        GridView2.DataSource = null;
<<<<<<< HEAD
        GridView2.DataBind(); 
    }


}
=======
        GridView2.DataBind();
    }
}
>>>>>>> cb92eb5b2e9038612fdacf5d98757c880099271b
