<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferConfirmation.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server">
        <asp:Panel ID="PanelTransferee" runat="server" CssClass="LargeDistinct" GroupingText="Review and Complete" Width="500px">
            <p>
                <asp:Label ID="Label1" runat="server" Text="Transferer" Font-Bold="True" Font-Size="X-Large" ForeColor="Black"></asp:Label>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Name: " ForeColor="Black" style="text-align: right" Width="80px"></asp:Label>
                <asp:Label ID="lblTransfererName" runat="server" ForeColor="Black"></asp:Label>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Account: " ForeColor="Black" style="text-align: right" Width="80px"></asp:Label>
                <asp:Label ID="lblTransfererAccount" runat="server" ForeColor="Black"></asp:Label>
                <br />
                <asp:Label ID="Label6" runat="server" Text="Amount: " ForeColor="Black" style="text-align: right" Width="80px"></asp:Label>
                <asp:Label ID="lblTransferAmount" runat="server" ForeColor="Black"></asp:Label>
            </p>
            <p>
                <asp:Label ID="Label8" runat="server" Text="Transferee" Font-Bold="True" Font-Size="X-Large" ForeColor="Black"></asp:Label>
            </p>
            <p>                
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Label ID="Label9" runat="server" Text="Name: " ForeColor="Black" style="text-align: right" Width="80px"></asp:Label>
                <asp:Label ID="lblTransfereeName" runat="server" ForeColor="Black"></asp:Label>
                <br />
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Label ID="Label11" runat="server" Text="Account: " ForeColor="Black" style="text-align: right" Width="80px"></asp:Label>
                <asp:Label ID="lblTransfereeAccount" runat="server" ForeColor="Black"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btnReviewBack" runat="server" CssClass="button" Text="&lt; Back" Width="95px" CausesValidation="False" OnClick="btnReviewBack_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReviewComplete" runat="server" CssClass="button" Text="Complete" Width="95px" OnClick="btnReviewComplete_Click" />
            </p>
        </asp:Panel>
    </form>

</body>
</html>
