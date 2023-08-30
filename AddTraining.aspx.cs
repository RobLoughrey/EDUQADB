using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace EDU_QA_DB
{
    public partial class AddTraining : System.Web.UI.Page
    {
        string myConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            //Redirect to Login if user is not logged in.
            {
                if (Session["LoggedIn"] == null || (bool)Session["LoggedIn"] == false)
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }

        protected void ddlTitles_SelectedIndexChanged(object sender, EventArgs e)
            //Pull the default values for a training event based on the selected title. 
        {
            if (!string.IsNullOrEmpty(ddlTitles.SelectedValue))
            {
                int selectedTitleID = Convert.ToInt32(ddlTitles.SelectedValue);

                string query = "SELECT * FROM tblTrainingEventTitles WHERE ID = @TitleID";

                using (SqlConnection conn = new SqlConnection(myConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TitleID", selectedTitleID);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            txtDateOfTraining.Text = DateTime.Today.ToString("MM/dd/yyyy");
                            txtPDH.Text = reader["PDHHours"].ToString();
                            txtContactHours.Text = reader["ContactHours"].ToString();
                            txtDescription.Text = reader["Description"].ToString();
                            txtType.Text = reader["TrainingType"].ToString();
                            AuthCertRef.Checked = (bool)reader["AuthCertRef"];
                            CreditsRefunds.Checked = (bool)reader["CreditsRefunds"];
                            EOB.Checked = (bool)reader["EOB"];
                            GAM.Checked = (bool)reader["GAM"];
                            Registration.Checked = (bool)reader["Registration"];
                            ChargeCorrection.Checked = (bool)reader["ChargeCorrection"];
                            CustServ.Checked = (bool)reader["CustServ"];
                            EscChurn.Checked = (bool)reader["EscChurn"];
                            Guarantors.Checked = (bool)reader["Guarantors"];
                            Software.Checked = (bool)reader["Software"];
                            Coding.Checked = (bool)reader["Coding"];
                            Denials.Checked = (bool)reader["Denials"];
                            FinAssist.Checked = (bool)reader["FinAssist"];
                            MDMC.Checked = (bool)reader["MDMC"];
                            Workqueues.Checked = (bool)reader["Workqueues"];
                            Communications.Checked = (bool)reader["Communications"];
                            DocsScanning.Checked = (bool)reader["DocsScanning"];
                            HAM.Checked = (bool)reader["HAM"];
                            Notes.Checked = (bool)reader["Notes"];
                            Coverage.Checked = (bool)reader["Coverage"];
                            ELMSProductivity.Checked = (bool)reader["ELMSProductivity"];
                            HIPAA.Checked = (bool)reader["HIPAA"];
                            PaymentPostProc.Checked = (bool)reader["PaymentPostProc"];

                            // Store the tblTrainingEventsTitle ID to use as the Title of the class
                            Session["SelectedTitleID"] = selectedTitleID;
                        }
                        reader.Close();
                    }
                }
            }
        }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            // Redirect to MainPage.aspx without updating the user data
            Response.Redirect("MainPage.aspx");
        }
        protected void btnSaveTraining_Click(object sender, EventArgs e)
        //Save the Training and Move to View Training to add users
        {
            int titleID = Convert.ToInt32(Session["SelectedTitleID"]);
            string recorder = Session["UserName"].ToString();
            string connString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string insertQuery = "INSERT INTO tblTrainings (Title, DateOfTraining, PDH, ContactHours, Description, " +
                    "AuthCertRef, CreditsRefunds, EOB, GAM, Registration, ChargeCorrection, CustServ, EscChurn, " +
                    "Guarantors, Software, Coding, Denials, FinAssist, MDMC, Workqueues, Communications, " +
                    "DocsScanning, HAM, Notes, Coverage, ELMSProductivity, HIPAA, PaymentPostProc, Type, Recorder) " +
                    "OUTPUT INSERTED.ID " +
                    "VALUES (@TitleID, @DateOfTraining, @PDH, @ContactHours, @Description, @AuthCertsRef, " +
                    "@CreditsRefunds, @EOB, @GuarantorAcctMaint, @Registration, @ChargeCorrection, " +
                    "@CustomerService, @EscalationAndChurn, @Guarantors, @Software, @Coding, @Denials, " +
                    "@FinancialAssistance, @MediareMedicaid, @Workqueues, @Communications, @DocumentsScanning, " +
                    "@HospitalAcctMaint, @Notes, @Coverage, @ELMSProductivity, @HIPAA, @PaymentPostProc, @Type, @Recorder)";

                SqlCommand command = new SqlCommand(insertQuery, conn);

                // Set the parameters for the insert query based on the form values
                command.Parameters.AddWithValue("@TitleID", titleID);
                command.Parameters.AddWithValue("@DateOfTraining", DateTime.ParseExact(txtDateOfTraining.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@PDH", Math.Round(float.Parse(txtPDH.Text), 2));
                command.Parameters.AddWithValue("@ContactHours", Math.Round(float.Parse(txtContactHours.Text), 2));
                command.Parameters.AddWithValue("@Description", txtDescription.Text);
                command.Parameters.AddWithValue("@Type", txtType.Text);
                command.Parameters.AddWithValue("@AuthCertRef", AuthCertRef.Checked);
                command.Parameters.AddWithValue("@CreditsRefunds", CreditsRefunds.Checked);
                command.Parameters.AddWithValue("@EOB", EOB.Checked);
                command.Parameters.AddWithValue("@GAM", GAM.Checked);
                command.Parameters.AddWithValue("@Registration", Registration.Checked);
                command.Parameters.AddWithValue("@ChargeCorrection", ChargeCorrection.Checked);
                command.Parameters.AddWithValue("@CustServ", CustServ.Checked);
                command.Parameters.AddWithValue("@EscChurn", EscChurn.Checked);
                command.Parameters.AddWithValue("@Guarantors", Guarantors.Checked);
                command.Parameters.AddWithValue("@Software", Software.Checked);
                command.Parameters.AddWithValue("@Coding", Coding.Checked);
                command.Parameters.AddWithValue("@Denials", Denials.Checked);
                command.Parameters.AddWithValue("@FinAssist", FinAssist.Checked);
                command.Parameters.AddWithValue("@MDMC", MDMC.Checked);
                command.Parameters.AddWithValue("@Workqueues", Workqueues.Checked);
                command.Parameters.AddWithValue("@Communications", Communications.Checked);
                command.Parameters.AddWithValue("@DocsScanning", DocsScanning.Checked);
                command.Parameters.AddWithValue("@HAM", HAM.Checked);
                command.Parameters.AddWithValue("@Notes", Notes.Checked);
                command.Parameters.AddWithValue("@Coverage", Coverage.Checked);
                command.Parameters.AddWithValue("@ELMSProductivity", ELMSProductivity.Checked);
                command.Parameters.AddWithValue("@HIPAA", HIPAA.Checked);
                command.Parameters.AddWithValue("@PaymentPostProc", PaymentPostProc.Checked);
                command.Parameters.AddWithValue("@Recorder", recorder);

                try
                {
                    conn.Open();
                    int newRecordID = Convert.ToInt32(command.ExecuteScalar()); // Get the new record ID
                    conn.Close();

                    if (newRecordID > 0)
                    {
                        // Store the new record ID in a session variable
                        Session["NewRecordID"] = newRecordID;
                        lblMessage.Text = "Record has been inserted with ID: " + newRecordID;
                        Response.Redirect("ViewTraining.aspx?ID=" + newRecordID);
                    }
                    else
                    {
                        lblMessage.Text = "No records were inserted.";
                    }
                }
                catch (SqlException ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}




