<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTraining.aspx.cs" Inherits="EDU_QA_DB.ViewTraining"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Training</title>
    <style>
        body {
            background-color: #00664F;
        }
        .formbody {
            font-family: Calibri, Arial, sans-serif;
            background-color: #00664F;
            color: #FFCD00;
            float: left;
        }
        .right-side-panel {
            width: 250px;
            background-color: #00664F;
            color: #FFCD00;
            padding: 10px;
            margin-left: 20px;
            float: right;
            border: 1px solid #FFCD00;
        }

        /* Add more styles here */
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right-side-panel">
            <h3>Attendees</h3>
            <asp:PlaceHolder ID="phAttendees" runat="server"></asp:PlaceHolder>
        </div>
        <div class="formbody">
        <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label>
        <asp:TextBox ID="txtTitle" runat="server" Width="600px"></asp:TextBox>
        <br />
        <asp:Label ID="lblDateofTraining" runat="server" Text="Date of Training:"></asp:Label>
        <asp:TextBox ID="txtDateOfTraining" runat="server" Width="80px"></asp:TextBox>
&nbsp;
        <asp:Label ID="lblPDH" runat="server" Text="PDH Value:"></asp:Label>
        <asp:TextBox ID="txtPDH" runat="server" Width="39px"></asp:TextBox>
        <asp:Label ID="lblContactHours" runat="server" Text="Contact Hours:"></asp:Label>
        <asp:TextBox ID="txtContactHours" runat="server" Width="35px"></asp:TextBox>
        <asp:Label ID="lblType" runat="server" Text="Type: "></asp:Label>
        <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
        <br />
        Description:<br />
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height= "200px" Width="747px"></asp:TextBox>
        <br />
        <table>
          <tr>
            <td><input type="checkbox" id="AuthCertRef" runat="server" /><label for="AuthCertRef">Auth, Certs, Referrals</label></td>
            <td><input type="checkbox" id="CreditsRefunds" runat="server" /><label for="CreditsRefunds">Credits & Refunds</label></td>
            <td><input type="checkbox" id="EOB" runat="server" /><label for="EOB">EOB</label></td>
            <td><input type="checkbox" id="GAM" runat="server" /><label for="GAM">Guarantor Acct Maint</label></td>
            <td><input type="checkbox" id="Registration" runat="server" /><label for="Registration">Registration</label></td>
          </tr>
          <tr>
            <td><input type="checkbox" id="ChargeCorrection" runat="server" /><label for="ChargeCorrection">Charge Correction</label></td>
            <td><input type="checkbox" id="CustServ" runat="server" /><label for="CustServ">Customer Service</label></td>
            <td><input type="checkbox" id="EscChurn" runat="server" /><label for="EscChurn">Escalation and Churn</label></td>
            <td><input type="checkbox" id="Guarantors" runat="server" /><label for="Guarantors">Guarantors</label></td>
            <td><input type="checkbox" id="Software" runat="server" /><label for="Software">Software</label></td>
          </tr>
          <tr>
            <td><input type="checkbox" id="Coding" runat="server" /><label for="Coding">Coding</label></td>
            <td><input type="checkbox" id="Denials" runat="server" /><label for="Denials">Denials</label></td>
            <td><input type="checkbox" id="FinAssist" runat="server" /><label for="FinAssist">Financial Assistance</label></td>
            <td><input type="checkbox" id="MDMC" runat="server" /><label for="MDMC">Mediare / Medicaid</label></td>
            <td><input type="checkbox" id="Workqueues" runat="server" /><label for="Workqueues">Workqueues</label></td>
          </tr>
          <tr>
            <td><input type="checkbox" id="Communications" runat="server" /><label for="Communications">Communications</label></td>
            <td><input type="checkbox" id="DocsScanning" runat="server" /><label for="DocsScanning">Documents/Scanning</label></td>
            <td><input type="checkbox" id="HAM" runat="server" /><label for="HAM">Hospital Acct Maint</label></td>
            <td><input type="checkbox" id="Notes" runat="server" /><label for="Notes">Notes</label></td>
          </tr>
          <tr>
            <td><input type="checkbox" id="Coverage" runat="server" /><label for="Coverage">Coverage</label></td>
            <td><input type="checkbox" id="ELMSProductivity" runat="server" /><label for="ELMSProductivity">ELMS/Productivity</label></td>
            <td><input type="checkbox" id="HIPAA" runat="server" /><label for="HIPAA">HIPAA</label></td>
            <td><input type="checkbox" id="PaymentPostProc" runat="server" /><label for="PaymentPostProc">Payment Post/Proc</label></td>
          </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnMainMenu" runat="server" Text="Main Menu" OnClick="btnMainMenu_Click" />
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update Event" />
        </div>
    </form>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</body>
</html>
