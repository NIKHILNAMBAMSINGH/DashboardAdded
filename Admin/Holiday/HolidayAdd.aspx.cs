using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Admin_Holiday_HolidayAdd : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtHolidayName.Text = "";
            txtHolidayDate.Text = "";
            lblMessage.Text = "";
        }
    }
    protected void btnAddDesignation_Click(object sender, EventArgs e)
    {
        try
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string HolidayName = txtHolidayName.Text;
            DateTime Date = DateTime.ParseExact(txtHolidayDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string HolidayDate = Date.ToString("yyyy-MM-dd");
            int monthNumber = Date.Month;
            string HolidayMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber);
            int HolidayDay = Date.Day;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO dbo.HolidayDetailsTbl (HolidayName, HolidayDate, HolidayMonth, HolidayDay) VALUES (@HolidayName, @HolidayDate, @HolidayMonth, @HolidayDay)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@HolidayName", SqlDbType.VarChar).Value = HolidayName;
                command.Parameters.Add("@HolidayDate", SqlDbType.Date).Value = HolidayDate;
                command.Parameters.Add("@HolidayMonth", SqlDbType.VarChar).Value = HolidayMonthName;
                command.Parameters.Add("@HolidayDay", SqlDbType.Int).Value = HolidayDay;

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    lblMessage.Text = "Added Holiday successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Failed to add designation";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

            txtHolidayName.Text = "";
            txtHolidayDate.Text = "";
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnResetDesignation_Click(object sender, EventArgs e)
    {
        txtHolidayName.Text = "";
        txtHolidayDate.Text = "";
    }
}