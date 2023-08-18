<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="EDU_QA_DB.MainPage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edu & QA DB</title>
    <link rel="stylesheet" href="/StyleSheet.css">

</head>

<body>
    <form id="form1" runat="server">
        <div id="header">
            <asp:Image ID="imgUIHCLogo" runat="server" ImageUrl="~/images/UIHCLogo.png" />
            User Data Dx:, <%=Session["UserName"]%>!
            <asp:Label ID="lblUserInfo" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="logout-button" />
        </div>
        <div id="side-panel">
                <h2><asp:Label ID="lblCriteria" runat="server" Text="Criteria"></asp:Label></h2>
                <asp:Label ID="lblSelUser" runat="server" Text="Select User"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlUsers" runat="server" DataTextField="FullName" DataValueField="ID" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged" AutoPostBack="true"  DataSourceID="sqlUsers" AppendDataBoundItems="True" CssClass="main-dd">
                            <asp:ListItem Text="Select User" Value=""></asp:ListItem></asp:DropDownList>       
                <asp:DropDownList ID="ddlTeams" runat="server" DataTextField="Team" DataValueField="ID" OnSelectedIndexChanged="ddlTeams_SelectedIndexChanged" AutoPostBack="true"  DataSourceID="sqlTeams" AppendDataBoundItems="True" CssClass="main-dd">
                            <asp:ListItem Text="Select Team/Group" Value=""></asp:ListItem></asp:DropDownList>
                <asp:DropDownList ID="ddlUnits" runat="server" DataTextField="Unit" DataValueField="Unit" OnSelectedIndexChanged="ddlUnits_SelectedIndexChanged" AutoPostBack="true"  DataSourceID="sqlUnits" AppendDataBoundItems="True" CssClass="main-dd">
                            <asp:ListItem Text="Select Manager" Value=""></asp:ListItem></asp:DropDownList>
                <asp:Label ID="lblsdate" runat="server" Text="Start Date:"></asp:Label>
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="main-text"></asp:TextBox>
                <asp:Label ID="lbledate" runat="server" Text="End Date:"></asp:Label>
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="main-text"></asp:TextBox>
                <br />
                    <asp:Button ID="btnSetDateYTD" runat="server" Text="YTD" OnClick="btnSetDateYTD_Click" CssClass="main-mini-button" />
                    <asp:Button ID="btnSetDatePA" runat="server" Text="PA" OnClick="btnSetDatePA_Click" CssClass="main-mini-button" />
                    <asp:Button ID="btnSetDateM0" runat="server" Text="M-0" OnClick="btnSetDateM0_Click" CssClass="main-mini-button" />
                    <asp:Button ID="btnSetDateM1" runat="server" Text="M-1" OnClick="btnSetDateM1_Click" CssClass="main-mini-button" />
                <br />
                
                    <asp:Button ID="btnMyTraining" runat="server" Text="My Training" CssClass="main-button" OnClick="btnMyTraining_Click" />
                    <asp:Button ID="btnMyQA" runat="server" Text="My QA's" CssClass="main-button" OnClick="btnMyTraining_Click" />
                 <% if (Session["sUserSecurity"].ToString() == "1"|| Session["sUserSecurity"].ToString() == "2") { %>   
                    <h2><asp:Label ID="lblReportingButtons" runat="server" Text="Reporting"></asp:Label></h2>
                    <asp:Button ID="btnSearchTrainings" runat="server" Text="Search Trainings" OnClick="btnSearchTrainings_Click" CssClass="main-button" />
                    <asp:Button ID="btnSearchQA" runat="server" Text="Search QA's" OnClick="btnSearchQA_Click" CssClass="main-button" />
                   <% } %>         
                <% if (Session["sUserSecurity"].ToString() == "1"|| Session["sUserSecurity"].ToString() == "2") { %>
                    <h2><asp:Label ID="lblEDQAButtons" runat="server" Text="Edu & QA"></asp:Label></h2>
                        <asp:Button ID="btnAddTrain" runat="server" Text="New Training Event" OnClick="btnAddTrain_Click" CssClass="main-button" />
                        <asp:Button ID="btnAddQA" runat="server" Text="New QA" OnClick="btnAddQA_Click" CssClass="main-button" />
                        <asp:Button ID="btnAddDocScan" runat="server" Text="New Doc Scan QA" OnClick="btnAddDocScan_Click" CssClass="main-button" />
                    <% } %>
                <% if (Session["sUserSecurity"].ToString() == "1"|| Session["sUserSecurity"].ToString() == "2") { %>
                    <h2><asp:Label ID="lblAdmin" runat="server" Text="Admin"></asp:Label></h2>
                        <asp:Button ID="btnQAProd" runat="server" Text="QA Productivity" OnClick="btnQAProd_Click" CssClass="main-button" />
                        <asp:Button ID="btnEduProd" runat="server" Text="Edu Productivity" OnClick="btnEduProd_Click" CssClass="main-button" />
                        <asp:Button ID="Button1" runat="server" Text="User List" OnClick="btnGetUsers_Click" CssClass="main-button" />
                        <asp:Button ID="Button3" runat="server" Text="Add User" OnClick="btnAddUser_Click" CssClass="main-button" />
                    <% } %>
                <br />
        </div>
        <div id="main-content">
            <asp:Label ID="lblContent" runat="server"></asp:Label>
            <asp:PlaceHolder ID="phContent" runat="server"></asp:PlaceHolder>
        </div>
    </form>
    <asp:SqlDataSource ID="sqlTeams" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>" 
            SelectCommand="SELECT ID, Team, Unit, Coordinator, Division FROM tblTeams ORDER BY Team ASC"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlUsers" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>" 
            SelectCommand="SELECT ID, CONCAT(LastName, ', ', FirstName) AS FullName FROM tblUser WHERE UserSecurity <> 7 ORDER BY LastName ASC"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlUnits" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>" 
            SelectCommand="SELECT Distinct Unit FROM tblTeams ORDER BY Unit ASC"></asp:SqlDataSource>

</body>
</html>
