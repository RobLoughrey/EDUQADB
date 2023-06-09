using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using EDU_QA_DB.Helpers;

namespace EDU_QA_DB
{
    public partial class MainPage : System.Web.UI.Page
    {
        string myConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null || (bool)Session["LoggedIn"] == false)
            {
                Response.Redirect("Login.aspx");
            }

            PageResetter.ResetPage(phContent);

            if (!IsPostBack)
            {
                txtStartDate.Text = DateTime.Today.AddMonths(-1).ToShortDateString();
                txtEndDate.Text = DateTime.Today.ToShortDateString();
            }

            int sUserId = Convert.ToInt32(Session["sUserId"]);
            int sUserSecurity = Convert.ToInt32(Session["sUserSecurity"]);

            // Add label to display sUserID and sUserSecurity
            lblUserInfo.Text = "UserID: " + sUserId.ToString() + ", UserSecurity: " + sUserSecurity.ToString();


        }

        protected void btnSetDateYTD_Click(object sender, EventArgs e)
        {
            // Set txtStartDate to Jan 1 of the current year
            txtStartDate.Text = new DateTime(DateTime.Now.Year, 1, 1).ToString("MM/dd/yyyy");

            // Set txtEndDate to Dec 31 of the current year
            txtEndDate.Text = new DateTime(DateTime.Now.Year, 12, 31).ToString("MM/dd/yyyy");
        }

        protected void btnSetDatePA_Click(object sender, EventArgs e)
        {
            // Set txtStartDate to Jan 1 of the current year
            txtStartDate.Text = new DateTime(DateTime.Now.Year-1, 1, 1).ToString("MM/dd/yyyy");

            // Set txtEndDate to Dec 31 of the current year
            txtEndDate.Text = new DateTime(DateTime.Now.Year-1, 12, 31).ToString("MM/dd/yyyy");
        }
        protected void btnSetDateM0_Click(object sender, EventArgs e)
        {
            // Set the Start Date to the first day of the current month
            txtStartDate.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("MM/dd/yyyy");

            // Set the End Date to the last day of the current month
            txtEndDate.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).ToString("MM/dd/yyyy");
        }
        protected void btnSetDateM1_Click(object sender, EventArgs e)
        {
            // Set the start date to the first day of the previous month
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 1);

            // Set the end date to the last day of the previous month
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            // Set the text boxes to display the dates
            txtStartDate.Text = startDate.ToString("MM/dd/yyyy");
            txtEndDate.Text = endDate.ToString("MM/dd/yyyy");
        }


        protected void btnMyTraining_Click(object sender, EventArgs e)
        {
            PageResetter.ResetPage(phContent);
            int sUserID = Convert.ToInt32(Session["sUserId"]);
            DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
            DateTime endDate = Convert.ToDateTime(txtEndDate.Text);

            DataTable dt = DatabaseHelper.GetMyTrainings(sUserID, startDate, endDate); // Use your existing method to get the DataTable

            // Create the GridView using the helper method
            GridViewHelper myTrainingHelper = new GridViewHelper();
            GridView gvMyTrainings = myTrainingHelper.CreateMyTrainingGridView(dt);
            // Add sorting to the GridView
            GridViewHelper.AddSorting(gvMyTrainings);

            // Add the GridView to the PlaceHolder
            phContent.Controls.Clear();
            if (gvMyTrainings.Rows.Count == 0)
            {
                Literal litNoRecords = new Literal();
                litNoRecords.Text = "No records to display.";
                phContent.Controls.Add(litNoRecords);
            }
            else
            {
                phContent.Controls.Add(gvMyTrainings);
            }
        }

        protected void btnGetUsers_Click(object sender, EventArgs e)
        {
            DataTable dt = DatabaseHelper.GetAllUsers(); // Use your existing method to get the DataTable

            // Create the GridView using the helper method
            GridViewHelper gridViewHelper = new GridViewHelper();
            GridView gvUsers = gridViewHelper.CreateUserGridView(dt);
            // Add sorting to the GridView
            GridViewHelper.AddSorting(gvUsers);

            // Add the GridView to the phContent control
            phContent.Controls.Clear();
            phContent.Controls.Add(gvUsers);

        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected user ID and save it to session
            string userId = ddlUsers.SelectedValue;
            Session["SelectedUserID"] = userId;
            ddlTeams.SelectedIndex = -1;
            ddlUnits.SelectedIndex = -1;
        }

        protected void ddlUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected user ID and save it to session
            string unitId = ddlUsers.SelectedValue;
            Session["SelectedUnitID"] = unitId;
            ddlTeams.SelectedIndex = -1;
            ddlUsers.SelectedIndex = -1;
        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            // Get the selected user ID
            int userId;
            if (int.TryParse(ddlUsers.SelectedValue, out userId))
            {
                // Store the selected user ID in the session variable
                Session["SelectedUserId"] = userId;
                Response.Redirect("EditUser.aspx");
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateUser.aspx");
        }

        protected void ddlTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TeamId = ddlTeams.SelectedValue;
            Session["SelectedTeamID"] = ddlTeams.SelectedValue;
            ddlUsers.SelectedIndex = -1;
            ddlUnits.SelectedIndex = -1;
        }
        protected void btnSearchTrainings_Click(object sender, EventArgs e)
        {
            PageResetter.ResetPage(phContent);
            DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
            DateTime endDate = Convert.ToDateTime(txtEndDate.Text);

            DataTable dt = DatabaseHelper.GetTrainingsByUserOrTeamOrUnit(ddlUsers.SelectedValue, ddlTeams.SelectedValue, ddlUnits.SelectedValue, startDate, endDate);

            // Create the GridView using the helper method
            GridViewHelper gridViewHelper = new GridViewHelper();
            GridView gvTrainings = gridViewHelper.ReportingTrainingGV(dt);

            // Add sorting to the GridView
            GridViewHelper.AddSorting(gvTrainings);

            // Add the GridView to the phContent control
            phContent.Controls.Clear();
            if (gvTrainings.Rows.Count == 0)
            {
                Literal litNoRecords = new Literal();
                litNoRecords.Text = "No records to display.";
                phContent.Controls.Add(litNoRecords);
            }
            else
            {
                phContent.Controls.Add(gvTrainings);
            }
        }

    }
}
