using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDU_QA_DB
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string myConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null || (bool)Session["LoggedIn"] == false)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    string query = "SELECT T.DateofTraining, T.PDH, T.ContactHours, TT.Title, TT.Description, T.AuthCertRef, T.CreditsRefunds, T.EOB, T.GAM, T.Registration, T.ChargeCorrection, T.CustServ, T.EscChurn, T.Guarantors, T.Software, T.Coding, T.Denials, T.FinAssist, T.MDMC, T.Workqueues, T.Communications, T.DocsScanning, T.HAM, T.Notes, T.Coverage, T.ELMSProductivity, T.HIPAA, T.PaymentPostProc, T.Type " +
                                    "FROM tblTrainings T " +
                                    "INNER JOIN tblAttendance A ON T.ID = A.TrainingAttended " +
                                    "INNER JOIN tblTrainingEventTitles TT ON T.Title = TT.ID " +
                                    "WHERE T.ID = @ID";


                    using (SqlConnection conn = new SqlConnection(myConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID", id);
                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                txtTitle.Text = reader["Title"].ToString();
                                txtDateOfTraining.Text = ((DateTime)reader["DateOfTraining"]).ToString("MM/dd/yyyy");
                                txtPDH.Text = reader["PDH"].ToString();
                                txtContactHours.Text = reader["ContactHours"].ToString();
                                txtDescription.Text = reader["Description"].ToString();
                                txtType.Text = reader["Type"].ToString();
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
                            }
                            // Get the list of attendees
                            query = "SELECT U.LastName + ', ' + U.FirstName AS Name, A.Role " +
                                    "FROM tblAttendance A " +
                                    "INNER JOIN tblUser U ON A.UserName = U.ID " +
                                    "WHERE A.TrainingAttended = @ID";
                            reader.Close(); // Close the first SqlDataReader before executing the second query
                            using (SqlCommand cmdAttendees = new SqlCommand(query, conn))
                            {
                                cmdAttendees.Parameters.AddWithValue("@ID", id);
                                SqlDataReader readerAttendees = cmdAttendees.ExecuteReader();

                                // Create a table to display the attendees
                                LiteralControl literal = new LiteralControl();
                                literal.Text = "<table><thead><tr><th>Name</th><th>Role</th></tr></thead><tbody>";

                                while (readerAttendees.Read())
                                {
                                    string name = readerAttendees["Name"].ToString();
                                    string role = readerAttendees["Role"].ToString();
                                    literal.Text += "<tr><td>" + name + "</td><td>" + role + "</td></tr>";
                                }

                                literal.Text += "</tbody></table>";
                                phAttendees.Controls.Add(literal);

                                readerAttendees.Close();
                            }
                        reader.Close();
                        }
                    }
                }
                    
                {
                    // Check the value of SessionSecurity and conditionally render the button
                    int securityLevel = Convert.ToInt32(Session["sUserSecurity"]);
                    if (securityLevel == 1 || securityLevel == 2)
                        {
                            Button btnUpdate = new Button();
                            btnUpdate.ID = "btnUpdate";
                            btnUpdate.Text = "Update Training";
                            btnUpdate.Click += new EventHandler(btnUpdate_Click);
                            form1.Controls.Add(btnUpdate);
                        }
                }
               
            }
        }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            // Redirect to MainPage.aspx without updating the user data
            Response.Redirect("MainPage.aspx");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Check security level before allowing update
            int securityLevel = Convert.ToInt32(Session["sUserSecurity"]);

            if (securityLevel == 1 || securityLevel == 2)
            {
                string connString = ConfigurationManager.ConnectionStrings["EDU-QA DBConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string updateQuery = "UPDATE tblTrainings SET Title=@Title, " +
                    "DateOfTraining=@DateOfTraining, PDH=@PDHValue, ContactHours=@ContactHours, " +
                    "Description=@Description, AuthCertRef=@AuthCertsReferrals, CreditsRefunds=@CreditsRefunds, " +
                    "EOB=@EOB, GAM=@GuarantorAcctMaint, Registration=@Registration, " +
                    "ChargeCorrection=@ChargeCorrection, CustServ=@CustomerService, EscChurn=@EscalationAndChurn, " +
                    "Guarantors=@Guarantors, Software=@Software, Coding=@Coding, Denials=@Denials, " +
                    "FinAssist=@FinancialAssistance, MDMC=@MediareMedicaid, Workqueues=@Workqueues, " +
                    "Communications=@Communications, DocsScanning=@DocumentsScanning, HAM=@HospitalAcctMaint, " +
                    "Notes=@Notes, Coverage=@Coverage, ELMSProductivity=@ELMSProductivity, HIPAA=@HIPAA, " +
                    "PaymentPostProc=@PaymentPostProc WHERE ID=@TrainingID";
                    SqlCommand command = new SqlCommand(updateQuery, conn);

                    // Set the parameters for the update query
                    command.Parameters.AddWithValue("@DateOfTraining", txtDateOfTraining.Text);
                    command.Parameters.AddWithValue("@PDH", txtPDH.Text);
                    command.Parameters.AddWithValue("@ContactHours", txtContactHours.Text);
                    command.Parameters.AddWithValue("@Description", txtDescription.Text);
                    command.Parameters.AddWithValue("@TrainingID", Request.QueryString["ID"]);

                    command.Parameters.AddWithValue("@AuthCertsReferrals", AuthCertRef.Checked);
                    command.Parameters.AddWithValue("@CreditsRefunds", CreditsRefunds.Checked);
                    command.Parameters.AddWithValue("@EOB", EOB.Checked);
                    command.Parameters.AddWithValue("@GuarantorAcctMaint", GAM.Checked);
                    command.Parameters.AddWithValue("@Registration", Registration.Checked);

                    command.Parameters.AddWithValue("@ChargeCorrection", ChargeCorrection.Checked);
                    command.Parameters.AddWithValue("@CustomerService", CustServ.Checked);
                    command.Parameters.AddWithValue("@EscalationAndChurn", EscChurn.Checked);
                    command.Parameters.AddWithValue("@Guarantors", Guarantors.Checked);
                    command.Parameters.AddWithValue("@Software", Software.Checked);

                    command.Parameters.AddWithValue("@Coding", Coding.Checked);
                    command.Parameters.AddWithValue("@Denials", Denials.Checked);
                    command.Parameters.AddWithValue("@FinancialAssistance", FinAssist.Checked);
                    command.Parameters.AddWithValue("@MediareMedicaid", MDMC.Checked);
                    command.Parameters.AddWithValue("@Workqueues", Workqueues.Checked);

                    command.Parameters.AddWithValue("@Communications", Communications.Checked);
                    command.Parameters.AddWithValue("@DocumentsScanning", DocsScanning.Checked);
                    command.Parameters.AddWithValue("@HospitalAcctMaint", HAM.Checked);
                    command.Parameters.AddWithValue("@Notes", Notes.Checked);

                    command.Parameters.AddWithValue("@Coverage", Coverage.Checked);
                    command.Parameters.AddWithValue("@ELMSProductivity", ELMSProductivity.Checked);
                    command.Parameters.AddWithValue("@HIPAA", HIPAA.Checked);
                    command.Parameters.AddWithValue("@PaymentPostProc", PaymentPostProc.Checked);

                    conn.Open();
                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Close the connection
                    conn.Close();

                    // Redirect back to the view page
                    Response.Redirect("ViewTraining.aspx?TrainingID=" + Request.QueryString["TrainingID"]);
                }
            }
            else
            {
                // Display an error message if the user does not have sufficient security level
                lblMessage.Text = "You do not have sufficient permissions to update this record.";
            }
        }
    }
}