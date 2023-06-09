<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EDU_QA_DB.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
        <style>
        body {
            font-family: Calibri, Arial, sans-serif;
            background-color: #FFCD00;
        }

        /* Add more styles here */
    </style>
</head>
<body>
    <form runat="server">
        <div>
            <h2>Please Login</h2>
            <p>
                <label for="txtUserName">Username:</label>
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            </p>
            <p>
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </p>
            <p>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
