using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using EDU_QA_DB.Helpers;

namespace EDU_QA_DB

{
    public partial class QA : System.Web.UI.Page
    {
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
            txtStartDate.Text = new DateTime(DateTime.Now.Year - 1, 1, 1).ToString("MM/dd/yyyy");

            // Set txtEndDate to Dec 31 of the current year
            txtEndDate.Text = new DateTime(DateTime.Now.Year - 1, 12, 31).ToString("MM/dd/yyyy");
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

        protected void ddlTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TeamId = ddlTeams.SelectedValue;
            Session["SelectedTeamID"] = ddlTeams.SelectedValue;
            ddlUsers.SelectedIndex = -1;
            ddlUnits.SelectedIndex = -1;
        }
        protected void btnSearchQA_Click(object sender, EventArgs e)
        {
            // Your event handling code goes here
            // For example, you can add the message "Query Not built yet" to phContent
            Label lblMessage = new Label();
            lblMessage.Text = "Query Not built yet";
            phContent.Controls.Add(lblMessage);
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear all session states
            Session.Clear();

            // Redirect to the login page
            Response.Redirect("Login.aspx");
        }

    }

}