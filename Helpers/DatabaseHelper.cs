using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EDU_QA_DB.Helpers
{
    public class DatabaseHelper
    {
        public static DataTable GetMyTrainings(int userID, DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT t.Id, T.DateofTraining, T.PDH, T.ContactHours, TT.Title, TT.Description FROM tblTrainings T INNER JOIN tblAttendance A ON T.ID = A.TrainingAttended INNER JOIN tblTrainingEventTitles TT ON T.Title = TT.ID WHERE A.Username = @UserID AND T.DateOfTraining BETWEEN @StartDate AND @EndDate AND A.Role = 3";
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }

            return dt;
        }
        public static DataTable GetAllUsers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = "SELECT tblUser.ID, tblUser.UserName, tblUser.Email, tblUser.FirstName, tblUser.LastName, tblUser.UserSecurity, tblTeams.Team FROM tblUser INNER JOIN tblTeams ON tblUser.Team = tblTeams.ID ORDER BY tblUser.LastName, tblUser.FirstName ASC";
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public static DataTable GetTrainingsByUserOrTeamOrUnit(string selectedUserId, string selectedTeamId, string selectedUnitId, DateTime startDate, DateTime endDate)
        {
            string myConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(myConnectionString))
            {
                connection.Open();

                string query = "SELECT tblTrainingEventTitles.Title, tblUser.Username, tblTrainingEventTitles.Description, tblTrainings.PDH, tblTrainings.ContactHours, tblTrainings.DateofTraining, tblTrainings.Id FROM tblTrainings " +
                                "INNER JOIN tblAttendance ON tblTrainings.Id = tblAttendance.TrainingAttended " +
                                "INNER JOIN tblUser ON tblAttendance.UserName = tblUser.ID " +
                                "INNER JOIN tblTeams ON tblUser.Team = tblTeams.ID " +
                                "INNER JOIN tblTrainingEventTitles ON tblTrainingEventTitles.ID = tblTrainings.Title " +
                                "WHERE (tblUser.Id = @UserId OR @UserId IS NULL) " +
                                "AND (tblTeams.Id = @TeamId OR @TeamId IS NULL) " +
                                "AND (tblTeams.Unit = @UnitId OR @UnitId IS NULL) " +
                                "AND (tblTrainings.DateofTraining >= @StartDate AND tblTrainings.DateofTraining <= @EndDate) " +
                                "AND tblAttendance.Role = 3";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", (string.IsNullOrEmpty(selectedUserId) ? (object)DBNull.Value : selectedUserId));
                    command.Parameters.AddWithValue("@TeamId", (string.IsNullOrEmpty(selectedTeamId) ? (object)DBNull.Value : selectedTeamId));
                    command.Parameters.AddWithValue("@UnitId", (string.IsNullOrEmpty(selectedUnitId) ? (object)DBNull.Value : selectedUnitId));
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

    }
}

