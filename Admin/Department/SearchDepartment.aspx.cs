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
public partial class Admin_Department_SearchDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnSearchDesignation_Click(object sender, EventArgs e)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            int DeptId = Convert.ToInt32(txtDeptId.Text);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM dbo.DepartmentDetailsTbl WHERE DeptId = @DeptId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@DeptId", DeptId);
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
<<<<<<< HEAD
                    GridView2.ShowHeaderWhenEmpty=true;
=======
                    GridView2.ShowHeaderWhenEmpty = true;
>>>>>>> cb92eb5b2e9038612fdacf5d98757c880099271b
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnResetDesignation_Click(object sender, EventArgs e)
    {
        txtDeptId.Text = "";
        txtDeptName.Text = "";
<<<<<<< HEAD
        GridView2.DataSource = null; 
        GridView2.DataBind(); 
    }
}
=======
        GridView2.DataSource = null;
        GridView2.DataBind();
    }
}
>>>>>>> cb92eb5b2e9038612fdacf5d98757c880099271b
