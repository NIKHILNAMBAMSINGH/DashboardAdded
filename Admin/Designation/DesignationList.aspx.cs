<<<<<<< HEAD
﻿﻿using System;
=======
﻿﻿﻿using System;
>>>>>>> cb92eb5b2e9038612fdacf5d98757c880099271b
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Admin_Designation_DesignationList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
<<<<<<< HEAD
           
=======

>>>>>>> cb92eb5b2e9038612fdacf5d98757c880099271b
            BindGridView();
        }
    }
    protected void BindGridView()
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM dbo.DesignationDetailsTbl";
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
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        BindGridView();
    }

}