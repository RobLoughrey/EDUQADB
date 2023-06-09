using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace EDU_QA_DB.Helpers
    {
        public class GridViewHelper
        {
            public static void AddSorting(GridView gv)
            {
                if (gv == null)
                {
                    throw new ArgumentNullException(nameof(gv));
                }

                gv.AllowSorting = true;
                gv.Sorting += Gv_Sorting;
            }

            private static void Gv_Sorting(object sender, GridViewSortEventArgs e)
            {
                GridView gv = (GridView)sender;

                // Retrieve the data source.
                DataView dataView = (DataView)gv.DataSource;

                // Set the sort expression based on the column clicked.
                dataView.Sort = e.SortExpression + (e.SortDirection == SortDirection.Ascending ? " ASC" : " DESC");

                // Re-bind the data source and set the sort direction.
                gv.DataSource = dataView;
                gv.DataBind();

                // Set the sort direction arrow for the sorted column
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    if (cell.Text.Trim() == e.SortExpression)
                    {
                        Label arrow = new Label();
                        arrow.Text = e.SortDirection == SortDirection.Ascending ? " &#9650;" : " &#9660;";
                        cell.Controls.Add(arrow);
                        Debug.WriteLine("Added sort arrow to header cell: " + cell.Text);
                        break;
                    }
                }
            }

            public GridView CreateMyTrainingGridView(DataTable dt)
        {
            // Create a new GridView
            GridView gvMyTrainings = new GridView();
            gvMyTrainings.ID = "gvMyTrainings";
            gvMyTrainings.AutoGenerateColumns = false;
            gvMyTrainings.ShowFooter = true;

            // Add sorting functionality
            AddSorting(gvMyTrainings);

            // Add columns to the GridView
            BoundField bfTitle = new BoundField();
            bfTitle.DataField = "Title";
            bfTitle.HeaderText = "Title";
            bfTitle.ItemStyle.Width = Unit.Pixel(350);
            bfTitle.ItemStyle.CssClass = "title-cell";
            bfTitle.SortExpression = "Title";
            gvMyTrainings.Columns.Add(bfTitle);

            BoundField bfDateOfTraining = new BoundField();
            bfDateOfTraining.DataField = "DateOfTraining";
            bfDateOfTraining.HeaderText = "Date of Training";
            bfDateOfTraining.DataFormatString = "{0:MM/dd/yyyy}";
            bfDateOfTraining.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bfDateOfTraining.ItemStyle.Width = Unit.Pixel(200);
            bfDateOfTraining.SortExpression = "DateOfTraining";
            gvMyTrainings.Columns.Add(bfDateOfTraining);

            BoundField bfPDH = new BoundField();
            bfPDH.DataField = "PDH";
            bfPDH.HeaderText = "PDH";
            bfPDH.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bfPDH.ItemStyle.Width = Unit.Pixel(100);
            bfPDH.SortExpression = "PDH";
            gvMyTrainings.Columns.Add(bfPDH);

            BoundField bfContactHours = new BoundField();
            bfContactHours.DataField = "ContactHours";
            bfContactHours.HeaderText = "Contact Hours";
            bfContactHours.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bfContactHours.ItemStyle.Width = Unit.Pixel(100);
            bfContactHours.SortExpression = "ContactHours";
            gvMyTrainings.Columns.Add(bfContactHours);

            BoundField bfDescription = new BoundField();
            bfDescription.DataField = "Description";
            bfDescription.HeaderText = "Description";
            bfDescription.ItemStyle.Width = Unit.Pixel(680);
            bfDescription.ItemStyle.CssClass = "title-cell";
            bfDescription.SortExpression = "Description";
            gvMyTrainings.Columns.Add(bfDescription);

            HyperLinkField viewField = new HyperLinkField();
            viewField.HeaderText = "View";
            viewField.Text = "View";
            viewField.ItemStyle.Width = Unit.Pixel(50);
            viewField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            viewField.DataNavigateUrlFormatString = "ViewTraining.aspx?ID={0}";
            viewField.DataNavigateUrlFields = new string[] { "ID" };
            gvMyTrainings.Columns.Add(viewField);


            // Set the HeaderStyle to shade the header with #BBBCBC
            gvMyTrainings.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#BBBCBC");
            gvMyTrainings.HeaderStyle.ForeColor = System.Drawing.Color.Black;

            gvMyTrainings.DataSource = dt;
            gvMyTrainings.DataBind();

            // Check if there are any rows in the DataTable
            if (dt.Rows.Count > 0)
            {
                // Add a footer row with the total PDH
                GridViewRow footerRow = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal);
                TableCell footerCell = new TableCell();
                footerCell.ColumnSpan = 2;
                footerCell.Text = "Total PDH";
                footerRow.Cells.Add(footerCell);
                footerCell = new TableCell();
                footerCell.Text = dt.Compute("SUM(PDH)", "").ToString();
                footerRow.Cells.Add(footerCell);

                footerCell = new TableCell();
                footerCell.ColumnSpan = 3;
                footerRow.Cells.Add(footerCell);

                gvMyTrainings.Controls[0].Controls.Add(footerRow);
            }

            return gvMyTrainings;
        }
        public GridView CreateUserGridView(DataTable dt)
        {
            GridView gvUsers = new GridView();
            gvUsers.DataSource = dt;
            gvUsers.AutoGenerateColumns = false;

            // Add sorting functionality
            AddSorting(gvUsers);

            // Add the edit column to the GridView
            HyperLinkField editField = new HyperLinkField();
            editField.HeaderText = "Edit";
            editField.Text = "Edit";
            editField.DataNavigateUrlFormatString = "EditUser.aspx?ID={0}";
            editField.DataNavigateUrlFields = new string[] { "ID" };
            gvUsers.Columns.Add(editField);

            // Add the columns to the GridView
            BoundField bfID = new BoundField();
            bfID.DataField = "ID";
            bfID.HeaderText = "ID";
            bfID.SortExpression = "ID";
            gvUsers.Columns.Add(bfID);

            BoundField bfLastName = new BoundField();
            bfLastName.DataField = "LastName";
            bfLastName.HeaderText = "Last Name";
            bfLastName.SortExpression = "LastName";
            gvUsers.Columns.Add(bfLastName);

            BoundField bfFirstName = new BoundField();
            bfFirstName.DataField = "FirstName";
            bfFirstName.HeaderText = "First Name";
            bfFirstName.SortExpression = "FirstName";
            gvUsers.Columns.Add(bfFirstName);

            BoundField bfUserName = new BoundField();
            bfUserName.DataField = "UserName";
            bfUserName.HeaderText = "UserName";
            bfUserName.SortExpression = "UserName";
            gvUsers.Columns.Add(bfUserName);

            BoundField bfTeam = new BoundField();
            bfTeam.DataField = "Team";
            bfTeam.HeaderText = "Team";
            bfTeam.SortExpression = "Team";
            gvUsers.Columns.Add(bfTeam);

            BoundField bfEmail = new BoundField();
            bfEmail.DataField = "Email";
            bfEmail.HeaderText = "Email";
            bfEmail.SortExpression = "Email";
            gvUsers.Columns.Add(bfEmail);

            BoundField bfUserSecurity = new BoundField();
            bfUserSecurity.DataField = "UserSecurity";
            bfUserSecurity.HeaderText = "User Security";
            bfUserSecurity.SortExpression = "UserSecurity";
            gvUsers.Columns.Add(bfUserSecurity);

            // Bind the data to the GridView
            gvUsers.DataBind();

            return gvUsers;
        }

        public GridView ReportingTrainingGV(DataTable dt)
        {
            // Create a new GridView
            GridView gvMyTrainings = new GridView();
            gvMyTrainings.ID = "gvMyTrainings";
            gvMyTrainings.AutoGenerateColumns = false;
            gvMyTrainings.ShowFooter = true;
            gvMyTrainings.EnableViewState = true;

            // Add sorting functionality
            AddSorting(gvMyTrainings);

            // Add columns to the GridView
            BoundField bfTitle = new BoundField();
            bfTitle.DataField = "Title";
            bfTitle.HeaderText = "Title";
            bfTitle.ItemStyle.Width = Unit.Pixel(350);
            bfTitle.ItemStyle.CssClass = "title-cell";
            bfTitle.SortExpression = "Title";
            gvMyTrainings.Columns.Add(bfTitle);

            BoundField bfDateOfTraining = new BoundField();
            bfDateOfTraining.DataField = "DateOfTraining";
            bfDateOfTraining.HeaderText = "Date of Training";
            bfDateOfTraining.DataFormatString = "{0:MM/dd/yyyy}";
            bfDateOfTraining.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bfDateOfTraining.ItemStyle.Width = Unit.Pixel(200);
            bfDateOfTraining.SortExpression = "DateOfTraining";
            gvMyTrainings.Columns.Add(bfDateOfTraining);

            BoundField bfPDH = new BoundField();
            bfPDH.DataField = "PDH";
            bfPDH.HeaderText = "PDH";
            bfPDH.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bfPDH.ItemStyle.Width = Unit.Pixel(100);
            bfPDH.SortExpression = "PDH";
            gvMyTrainings.Columns.Add(bfPDH);

            BoundField bfUserName = new BoundField();
            bfUserName.DataField = "UserName";
            bfUserName.HeaderText = "User Name";
            bfUserName.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bfUserName.ItemStyle.Width = Unit.Pixel(100);
            bfUserName.SortExpression = "UserName";
            gvMyTrainings.Columns.Add(bfUserName);

            BoundField bfDescription = new BoundField();
            bfDescription.DataField = "Description";
            bfDescription.HeaderText = "Description";
            bfDescription.ItemStyle.Width = Unit.Pixel(680);
            bfDescription.ItemStyle.CssClass = "title-cell";
            bfDescription.SortExpression = "Description";
            gvMyTrainings.Columns.Add(bfDescription);

            HyperLinkField viewField = new HyperLinkField();
            viewField.HeaderText = "View";
            viewField.Text = "View";
            viewField.ItemStyle.Width = Unit.Pixel(50);
            viewField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            viewField.DataNavigateUrlFormatString = "ViewTraining.aspx?ID={0}";
            viewField.DataNavigateUrlFields = new string[] { "ID" };
            gvMyTrainings.Columns.Add(viewField);


            // Set the HeaderStyle to shade the header with #BBBCBC
            gvMyTrainings.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#BBBCBC");
            gvMyTrainings.HeaderStyle.ForeColor = System.Drawing.Color.Black;

            gvMyTrainings.DataSource = dt;
            gvMyTrainings.DataBind();

            // Check if there are any rows in the DataTable
            if (dt.Rows.Count > 0)
            {
                // Add a footer row with the total PDH
                GridViewRow footerRow = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal);
                TableCell footerCell = new TableCell();
                footerCell.ColumnSpan = 2;
                footerCell.Text = "Total PDH";
                footerRow.Cells.Add(footerCell);
                footerCell = new TableCell();
                footerCell.Text = dt.Compute("SUM(PDH)", "").ToString();
                footerRow.Cells.Add(footerCell);

                footerCell = new TableCell();
                footerCell.ColumnSpan = 3;
                footerRow.Cells.Add(footerCell);

                gvMyTrainings.Controls[0].Controls.Add(footerRow);
            }

            return gvMyTrainings;
        }
    }
}