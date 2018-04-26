<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferFrom.aspx.cs" Inherits="FundTransferFrom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server">
        <asp:Panel ID="PanelTransferFrom" runat="server" CssClass="LargeDistinct" GroupingText="Transfer From" Width="500px">
            <p>
                <asp:RequiredFieldValidator ID="rfvTransferor" runat="server" ErrorMessage="Must Select One" ControlToValidate="ddlTransferor" CssClass="error" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                <br />
                <asp:DropDownList ID="ddlTransferor" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlTransferor_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Transferor ...</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="lblFromAccount" runat="server" ForeColor="Black" Text="From Amount:"></asp:Label>
            </p>
            <p>
                <asp:RadioButtonList ID="rblFromAccount" runat="server" ForeColor="Black" OnSelectedIndexChanged="rblFromAccount_SelectedIndexChanged">
                    <asp:ListItem>Checking</asp:ListItem>
                    <asp:ListItem>Saving</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="rfvFromAccount" runat="server" ControlToValidate="rblFromAccount" CssClass="error" Display="Dynamic">Must select an account!</asp:RequiredFieldValidator></p>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Amount:" ForeColor="Black"></asp:Label>
                &nbsp;
                <asp:TextBox ID="TextBox1" runat="server" CssClass="input" Height="16px" Width="193px"></asp:TextBox>
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="rfvAmount" runat="server" ControlToValidate="TextBox1" CssClass="error" Display="Dynamic">Can not be blank</asp:RequiredFieldValidator>
            </p>   
            <asp:CustomValidator ID="CustomValidator" runat="server" ControlToValidate="TextBox1" CssClass="error" Display="Dynamic" OnServerValidate="CustomValidator_ServerValidate"></asp:CustomValidator>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnTransferFrom" runat="server" CssClass="button" Text="Next &gt;" Width="95px" OnClick="btnTransferFrom_Click" />
            </p>          
        
        </asp:Panel>

    </form>
</body>
</html>
