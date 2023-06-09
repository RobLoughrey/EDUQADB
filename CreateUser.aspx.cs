using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace EDU_QA_DB
{
    public partial class CreateUser : Page
    {
        string myConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null || (bool)Session["LoggedIn"] == false)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            // Get values from form
            string userName = txtUserName.Text;
            string email = txtEmail.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            int userSecurity = int.Parse(ddSecurity.SelectedValue);

            // Add user to database
            using (SqlConnection conn = new SqlConnection(myConnectionString))
            {
                string query = "INSERT INTO tblUser (UserName, Email, FirstName, LastName, UserSecurity) VALUES (@UserName, @Email, @FirstName, @LastName, @UserSecurity)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@UserSecurity", userSecurity);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        // The user is added successfully, redirect to MainPage.aspx
                        Response.Redirect("MainPage.aspx");
                    }
                    else
                    {
                        // The user is not added, display an error message
                        lblContext.Text = "Failed to create user.";
                    }
                    conn.Close();
                }
            }
        }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainPage.aspx");
        }
    }
}