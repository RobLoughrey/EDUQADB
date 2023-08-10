<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QA.aspx.cs" Inherits="EDU_QA_DB.QA" %>

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
            <% if (Session["sUserSecurity"].ToString() == "1" || Session["sUserSecurity"].ToString() == "2") { %>
                    <asp:RadioButton ID="flgEdOpp" runat="server" Text="Edu Opp Only"/><br />        
                    <asp:RadioButton ID="flgFinalized" runat="server" Text="Not Finalized"/><br />
                    <asp:RadioButton ID="flgApproved" runat="server" Text="Not Approved"/><br />
                    <asp:RadioButton ID="flgSigned" runat="server" Text="Not Signed" /><br />
                    <asp:RadioButton ID="flgFYI" runat="server" Text="FYI Only"/><br />
                    <asp:RadioButton ID="flgOTJ" runat="server" Text="OTJ Only"/><br />
                    <asp:RadioButton ID="flgDD" runat="server" Text="Deep Dive Only"/><br />
                    <asp:RadioButton ID="flgHH" runat="server" Text="Helpful Hints Only"/><br />
                    <asp:RadioButton ID="flgExpUnc" runat="server" Text="Exp Unclear Only"/><br />
                    <asp:RadioButton ID="flgCN" runat="server" Text="Corr. Needed Only"/><br />
                    <asp:RadioButton ID="flgCRD" runat="server" Text="Disscuss with CRD"/><br />
                    <asp:RadioButton ID="flgREQIP" runat="server" Text="REQIP Complete"/><br />
                    <asp:Button ID="btnSearchQA" runat="server" Text="Search QA's" OnClick="btnSearchQA_Click" CssClass="main-button" />
             <% } %>
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
