using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace EDU_QA_DB
{
    public partial class EditUser : System.Web.UI.Page
    {
        string myConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null || (bool)Session["LoggedIn"] == false)
            {
                Response.Redirect("Login.aspx");
            }

            // Only populate the form fields with data from the database if it is the initial page load
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    // Retrieve the selected user ID from the postback
                    int userId;
                    if (int.TryParse(Request.QueryString["ID"], out userId))
                    {
                        // Populate the form fields with data from the selected user
                        using (SqlConnection conn = new SqlConnection(myConnectionString))
                        {
                            string query = "SELECT UserName, Password, Email, FirstName, LastName, UserSecurity FROM tblUser WHERE ID = @ID";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@ID", userId);
                                conn.Open();
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        txtUserName.Text = reader["UserName"].ToString();
                                        txtPassword.Text = reader["Password"].ToString();
                                        txtEmail.Text = reader["Email"].ToString();
                                        txtFirstName.Text = reader["FirstName"].ToString();
                                        txtLastName.Text = reader["LastName"].ToString();
                                        txtUserSecurity.Text = reader["UserSecurity"].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                // Retrieve the selected user ID from the postback
                int userId;
                if (int.TryParse(Request.QueryString["ID"], out userId))
                {
                    // Update the user data in the database
                    using (SqlConnection conn = new SqlConnection(myConnectionString))
                    {
                        string query = "UPDATE tblUser SET UserName = @UserName, Password = @Password, Email = @Email, FirstName = @FirstName, LastName = @LastName, UserSecurity = @UserSecurity WHERE ID = @ID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                            cmd.Parameters.AddWithValue("@UserSecurity", Convert.ToInt32(txtUserSecurity.Text));
                            cmd.Parameters.AddWithValue("@ID", userId);
                            conn.Open();
                            int result = cmd.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // The user data is updated successfully, redirect to MainPage.aspx
                                Response.Redirect("MainPage.aspx");
                            }
                            else
                            {
                                // The user data is not updated, display an error message
                                lblContent.Text = "Failed to update user data.";
                            }
                        }
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect to MainPage.aspx without updating the user data
            Response.Redirect("MainPage.aspx");
        }
    }
}