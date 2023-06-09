using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace EDU_QA_DB // Update the namespace to match your project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            // Update the connection string name to match your web.config

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, UserSecurity FROM tblUser WHERE Username = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Session["sUserId"] = reader["ID"];
                            Session["sUserSecurity"] = reader["UserSecurity"];
                        }
                        lblMessage.Text = "Login successful";
                        Session["UserName"] = txtUserName.Text;
                        Session["LoggedIn"] = true;
                        Response.Redirect("MainPage.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Invalid username or password";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
