<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PharmQAEdit.aspx.cs" Inherits="EDU_QA_DB.PharmQAEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View PHARM QA</title>
    <style>

        .container {
            max-width: 1900px;
            margin: 0 auto;
            padding: 0 10px;
            display: flex;
            flex-wrap: nowrap; 
        }

        body {
            background-color: #00558C;
            color: #FFCD00;
        }

        .formbody {
            font-family: Calibri, Arial, sans-serif;
            background-color: #00558C;
            color: #FFCD00;
              
        }
        .right-side-panel {
            
            background-color: #00558C;
            color: #FFCD00;
            padding: 10px;
            margin-left: 20px;
            margin-right: 20px;
        }

        footer {
            clear: both;
            width: 100%; /* optional, if you want it to take up full width */
        }

        /* Add more styles here */
    </style>
</head>
<body>
    <form id="PHARMQA_Form" runat="server">
        <div class="container">
        <div class="formbody">
        <asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>&nbsp;
        <asp:TextBox ID="txtUserName" runat="server" Width="215px"></asp:TextBox>&nbsp;&nbsp;
        <asp:Label ID="lblDateQA" runat="server" Text="Date of QA:"></asp:Label>&nbsp;
        <asp:TextBox ID="DateQA" runat="server" Width="215px"></asp:TextBox>
        <br />
        <asp:CheckBox ID="EduOpp" runat="server" Text="Educational Opportunity?" />&nbsp;&nbsp;
        <asp:Label ID="lblHAR" runat="server" Text="HAR/Invoice:"></asp:Label>&nbsp;
        <asp:TextBox ID="HAR" runat="server" Width="150px"></asp:TextBox>&nbsp;
        <asp:Label ID="lblQACRD" runat="server" Text="QA Author:"></asp:Label>&nbsp;
        <asp:TextBox ID="Author" runat="server" Width="150px"></asp:TextBox>
        <br />
        <asp:CheckBox ID="CorrectNeeded" runat="server" Text="Correction Needed?" />&nbsp;&nbsp;
        <asp:CheckBox ID="REQIPPass" runat="server" Text="REQIP Complete" />&nbsp;&nbsp;
        <asp:Label ID="lblAcctType" runat="server" Text="Account Type:"></asp:Label>&nbsp;
        <asp:DropDownList ID="AcctType" runat="server">
                    <asp:ListItem Text="HB" Value="1" />
                    <asp:ListItem Text="PB" Value="2" />
                    <asp:ListItem Text="CB" Value="3" />
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblQATeamComment" runat="server" Text="QA Team Comment:"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="86px" Width="698px"></asp:TextBox>
        <br />
        <asp:Label ID="lblEpicNote" runat="server" Text="The Epic Note:"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Height="72px" Width="698px"></asp:TextBox>
        <br />
        <asp:Label ID="lblQAtoRCC" runat="server" Text="QA Comment To Coordiantor"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblRCCtoQA" runat="server" Text="Coordiantor Comment to QA:"></asp:Label>
        <br />
        <asp:TextBox ID="CommenttoCRD" runat="server" Height="64px" Width="335px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="CommenttoQA" runat="server" Height="64px" Width="335px"></asp:TextBox>
        <br />
        <asp:Label ID="lblCoordCommentToStaff" runat="server" Text="Coordinator Comment to Staff Member:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Label ID="lblRCRNote" runat="server" Text="Staff Member Note:"></asp:Label>
        <br />
        <asp:TextBox ID="CoordComment" runat="server" Height="64px" Width="335px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="RCRNote" runat="server" Height="64px" Width="335px"></asp:TextBox>
        <table>
          <tr>
            <th>PHARM Trends</th>
            <th></th>
            <th>Credits Trends</th>
            <th>CDFT Team Trends</th>
          </tr>
          <tr>
            <td><input type="checkbox" id="Appeal" runat="server" /><label for="Appeal">Appeal</label></td>
            <td><input type="checkbox" id="Disribution" runat="server" /><label for="Disribution">Disribution</label></td>
            <td><input type="checkbox" id="Disribute" runat="server" /><label for="Distribute">Disribute</label></td>
            <td><input type="checkbox" id="Dx" runat="server" /><label for="Dx">Diagnosis</label></td>
          </tr>
          <tr>
            <td><input type="checkbox" id="NRP" runat="server" /><label for="NRP">NRP</label></td>
            <td><input type="checkbox" id="Adjustment" runat="server" /><label for="Adjustment">Adjustment</label></td>
            <td><input type="checkbox" id="CreditAdjustment" runat="server" /><label for="CreditAdjustment">Credit Adjustment</label></td>
            <td><input type="checkbox" id="CPT" runat="server" /><label for="CPT">CPT</label></td>
          </tr>
          <tr>
            <td><input type="checkbox" id="ChurnEscalation" runat="server" /><label for="ChurnEscalation">Churn/Escalation</label></td>
            <td><input type="checkbox" id="PayorUpdate" runat="server" /><label for="PayorUpdate">Payor Update</label></td>
            <td><input type="checkbox" id="Documentation" runat="server" /><label for="Documentation">Documentation</label></td>
            <td><input type="checkbox" id="Modifier" runat="server" /><label for="Modifier">Modifier</label></td>
          </tr>
          <tr>
            <td><input type="checkbox" id="ProtocolNotFollowed" runat="server" /><label for="ProtocolNotFollowed">Protocol Not Followed</label></td>
            <td><input type="checkbox" id="TOBPOS" runat="server" /><label for="TOBPOS">TOB/POS</label></td>
            <td><input type="checkbox" id="MoveForward" runat="server" /><label for="MoveForward">Did Not Move Invoice Forward</label></td>
          </tr>
          <tr>
            <td><input type="checkbox" id="Resubmission" runat="server" /><label for="Resubmission">Resubmission</label></td>
            <td><input type="checkbox" id="CaseBilledUntimely" runat="server" /><label for="CaseBilledUntimely">Case Billed Untimely</label></td>
            <td><input type="checkbox" id="PaymentNotRefunded" runat="server" /><label for="PaymentNotRefunded">Payment Not Refunded</label></td>
           
          </tr>
            <tr>
            <td><input type="checkbox" id="Transfer" runat="server" /><label for="Transfer">Transfer</label></td>
            <td><input type="checkbox" id="Noting" runat="server" /><label for="Noting">Noting</label></td>
            <td><input type="checkbox" id="ProcessNotFollowed" runat="server" /><label for="ProcessNotFollowed">ProcessNotFollowed</label></td>
           
          </tr>
            <tr>
            <td><input type="checkbox" id="ChargeCorrection" runat="server" /><label for="ChargeCorrection">Charge Correction</label></td>
            <td><input type="checkbox" id="MovedChargesIncorrectly" runat="server" /><label for="MovedChargesIncorrectly">Moved Charges Incorrectly</label></td>
            <td><input type="checkbox" id="RefundedInError" runat="server" /><label for="RefundedInError">Refunded In Error</label></td>
            
          </tr>
            <tr>
            <td><input type="checkbox" id="Checkbox9" runat="server" /><label for="Coverage">Coverage</label></td>
            <td><input type="checkbox" id="Checkbox10" runat="server" /><label for="ELMSProductivity">ELMS/Productivity</label></td>
            <td><input type="checkbox" id="Checkbox11" runat="server" /><label for="HIPAA">HIPAA</label></td>
            
          </tr>
        </table>
            <br />
        </div>
        <div class="right-side-panel">
            <table>
                <tr>
                    <td><input type="checkbox" id="ExpUnclear" runat="server" /><label for="ExpUnclear">Expectations Unclear</label></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td><input type="checkbox" id="Finalized" runat="server" /><label for="Finalized">Finalized</label></td>
                </tr>
                <tr>
                    <td><input type="checkbox" id="DeepDive" runat="server" /><label for="DeepDive">Deep Dive</label></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td><input type="checkbox" id="CoordApp" runat="server" /><label for="CoordApp">Coordiantor Approved</label></td>
                </tr>
                <tr>
                    <td><input type="checkbox" id="OTJ" runat="server" /><label for="OTH">OTJ</label></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td><input type="checkbox" id="Signed" runat="server" /><label for="Signed">Viewed by Staff</label></td>
                </tr>
                <tr>
                    <td><input type="checkbox" id="Overturned" runat="server" /><label for="Overturned">Overturned</label></td>
                </tr>
                <tr>
                    <td><input type="checkbox" id="Kudos" runat="server" /><label for="Kudos">Kudos</label></td>
                </tr>
                <tr>
                    <td><input type="checkbox" id="CorrMade" runat="server" /><label for="CorrMade">Correction Made</label></td>
                </tr>
                <tr>
                    <td><input type="checkbox" id="TalktoCRD" runat="server" /><label for="TalktoCRD">Talk To CRD</label></td>
                </tr>
                <tr>
                    <td><input type="checkbox" id="REQIPUnavailable" runat="server" /><label for="REQIPUnavailable">REQIP Unavailable</label></td>
                </tr>
                <tr>
                    <td><input type="checkbox" id="CRDReviewed" runat="server" /><label for="CRDReviewed">Coordiantor Reviewed</label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:Label ID="lblQAPrivNote" runat="server" Text="QA Private Note"></asp:Label>
            <br />
            <asp:TextBox ID="QAPrivNote" runat="server" Height="89px" Width="343px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="MainMenu" runat="server" Text="Main Menu" />
            <asp:Button ID="btnUpdateQA" runat="server" Text="Update QA" />
            <br />

        </div>
    </div>
        <footer>
                <asp:Label ID="lblLinkJA" runat="server" Text="Links to Relevant Job Aids"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblRLA" runat="server" Text="Remote Learning Activities"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Label ID="lblREQIPAssign" runat="server" Text="Assign"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblE2EAssign" runat="server" Text="E2E"></asp:Label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblREQIPComplete" runat="server" Text="Complete"></asp:Label>
                <br />
                <asp:TextBox ID="JA1" Width="250px" runat="server"></asp:TextBox>&nbsp;
                <asp:TextBox ID="TextBox4" Width="250px" runat="server"></asp:TextBox>&nbsp;
                <asp:Button ID="btnSendEmail1" runat="server" Text="Send RLA" />&nbsp;
                <asp:TextBox ID="TextBox5" Width="50px" runat="server"></asp:TextBox>&nbsp;
                <asp:TextBox ID="TextBox6" Width="50px" runat="server"></asp:TextBox>&nbsp;
                <asp:TextBox ID="TextBox7" Width="50px" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="JA2" Width="250px" runat="server"></asp:TextBox>&nbsp;
                <asp:TextBox ID="RLA2" Width="250px" runat="server"></asp:TextBox>&nbsp;
                <asp:Button ID="btnSendEmail2" runat="server" Text="Send RLA" />&nbsp;
                <asp:TextBox ID="RA2" Width="50px" runat="server"></asp:TextBox>&nbsp;
                <asp:TextBox ID="E2E2" Width="50px" runat="server"></asp:TextBox>&nbsp;
                <asp:TextBox ID="RC2" Width="50px" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="JA3" Width="250px" runat="server"></asp:TextBox>&nbsp;
                <asp:TextBox ID="RLA3" Width="250px" runat="server"></asp:TextBox>&nbsp;
                <asp:Button ID="btnSendEmail3" runat="server" Text="Send RLA" />&nbsp;
                <asp:TextBox ID="RA3" Width="50px" runat="server"></asp:TextBox>&nbsp;
                <asp:TextBox ID="E2E3" Width="50px" runat="server"></asp:TextBox>&nbsp;
                <asp:TextBox ID="RC3" Width="50px" runat="server"></asp:TextBox>
                <br />
        </footer>

    </form>
</body>
</html>
