<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="EDU_QA_DB.EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit User Info</title>
    <style>
        .form-label {
            display: inline-block;
            width: 120px;
            text-align: right;
            padding-right: 10px;
        }
        .form-field {
            display: inline-block;
            width: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblID" runat="server" CssClass="form-label" Text="ID:"></asp:Label>
        <asp:TextBox ID="txtID" runat="server" CssClass="form-field" ReadOnly="true"></asp:TextBox>
        <br />
        <asp:Label ID="lblUserName" runat="server" CssClass="form-label" Text="Username:"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-field"></asp:TextBox>
        <br />
        <asp:Label ID="lblPassword" runat="server" CssClass="form-label" Text="Password:"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-field" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblEmail" runat="server" CssClass="form-label" Text="Email:"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-field"></asp:TextBox>
        <br />
        <asp:Label ID="lblFirstName" runat="server" CssClass="form-label" Text="First Name:"></asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-field"></asp:TextBox>
        <br />
        <asp:Label ID="lblLastName" runat="server" CssClass="form-label" Text="Last Name:"></asp:Label>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-field"></asp:TextBox>
        <br />
        <asp:Label ID="lblUserSecurity" runat="server" CssClass="form-label" Text="User Security:"></asp:Label>
        <asp:TextBox ID="txtUserSecurity" runat="server" CssClass="form-field"></asp:TextBox>
        <br />
        <asp:Button ID="btnUpdateUser" runat="server" Text="Update User" OnClick="btnUpdateUser_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Main Menu" OnClick="btnCancel_Click" />
        <br />
        <asp:Label ID="lblContent" runat="server"></asp:Label>
    </form>
</body>
</html>
