<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="EDU_QA_DB.CreateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create User</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>

<header>
    <h1>Create New User</h1>
</header>

<body>
    <form id="form1" runat="server">
        <fieldset>
            <legend>All Fields are Required</legend>
            <asp:Label ID="lblHealthcareID" runat="server" Text="HealthcareID:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-textbox"></asp:TextBox>
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-textbox"></asp:TextBox>
            <br />
            <asp:Label ID="lblFirstName" runat="server" Text="First Name:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-textbox"></asp:TextBox>
            <br />
            <asp:Label ID="lblLastName" runat="server" Text="LastName:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-textbox"></asp:TextBox>
            <br />
            <asp:Label ID="lblSecLevel" runat="server" Text="Security Level:" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="ddSecurity" runat="server" CssClass="form-textbox">
                <asp:ListItem Value="1">Admin</asp:ListItem>
                <asp:ListItem Value="2">Edu &amp; QA</asp:ListItem>
                <asp:ListItem Value="3">AD</asp:ListItem>
                <asp:ListItem Value="4">Manager</asp:ListItem>
                <asp:ListItem Value="5">Coordinator</asp:ListItem>
                <asp:ListItem Value="6">User</asp:ListItem>
                <asp:ListItem Value="7">Inactive</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnCreateUser" runat="server" Text="Create New User" OnClick="btnCreateUser_Click" />
            <asp:Button ID="btnMainMenu" runat="server" Text="Main Menu" OnClick="btnMainMenu_Click" />
        </fieldset>
     </form>
    <asp:Label ID="lblContext" runat="server" Text="Click Create to Continue or Main menu To Cancel"></asp:Label>
</body>
   
<footer>

   

   
</footer>

</html>
