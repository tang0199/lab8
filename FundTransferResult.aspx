<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferResult.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server">
       <p>
            Thank you for using Online fund transfer service.
        </p>
        <asp:Panel ID="PanelSuccess" runat="server">
            <p>
                Amount: 
                <asp:Label ID="lblTransferAmount" runat="server"></asp:Label>
                &nbsp;has been transferred
            </p>
            <p>
                <asp:Label ID="lblFrom" runat="server" Text="From" Font-Bold="True"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblFromName" runat="server" Text="Name: " style="text-align: right" Width="80px"></asp:Label>
                <asp:Label ID="lblTransfererName" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblFromAccount" runat="server" Text="Account: " style="text-align: right" Width="80px"></asp:Label>
                <asp:Label ID="lblTransfererAccount" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblTo" runat="server" Text="To" Font-Bold="True"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblToName" runat="server" Text="Name: " style="text-align: right" Width="80px"></asp:Label>
                <asp:Label ID="lblTransfereeName" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblToAccount" runat="server" Text="Account: " style="text-align: right" Width="80px"></asp:Label>
                <asp:Label ID="lblTransfereeAccount" runat="server"></asp:Label>
            </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReviewComplete" runat="server" CssClass="button" Text="Start A New Transfer" Width="245px" OnClick="btnReviewComplete_Click" />
            </p>
        </asp:Panel>
        <asp:Panel ID="PanelFailed" runat="server" Visible="False">
            <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>
        </asp:Panel>
 
    </form>
</body>
</html>
