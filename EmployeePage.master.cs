using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeePage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
   if (!IsPostBack)
            {

                if (Session["EmployeeName"] != null)
                {
                   
                    Page.DataBind();
                }
                else
                {
                    
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
    }