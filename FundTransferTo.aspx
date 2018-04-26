<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferTo.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server">
        <asp:Panel ID="PanelTransferee" runat="server" CssClass="LargeDistinct" GroupingText="Transferee" Width="500px">
            <p>
                <asp:RequiredFieldValidator ID="rfvTransferee" runat="server" ErrorMessage="Must Select One" ControlToValidate="ddlTransferee" CssClass="error" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                <br />
                <asp:DropDownList ID="ddlTransferee" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlTransferee_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Transferee ...</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="lblToAccount" runat="server" ForeColor="Black" Text="To Amount:"></asp:Label>
            </p>
            <p>
                <asp:RadioButtonList ID="rblToAccount" runat="server" ForeColor="Black" OnSelectedIndexChanged="rblToAccount_SelectedIndexChanged">
                    <asp:ListItem>Checking</asp:ListItem>
                    <asp:ListItem>Saving</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="rfvToAccount" runat="server" ControlToValidate="rblToAccount" CssClass="error" Display="Dynamic">Must select an account!</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Button ID="btnTransfereeBack" runat="server" CssClass="button" Text="&lt; Back" Width="95px" OnClick="btnTransfereeBack_Click" CausesValidation="False" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnTransfereeNext" runat="server" CssClass="button" Text="Next &gt;" Width="95px" OnClick="btnTransfereeNext_Click" />
            </p>
        </asp:Panel>
    </form>
</body>
</html>
