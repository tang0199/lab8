using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Customer transferer = (Customer)Session["transferorCustomer"];
        AccountType transferorAccountType = (AccountType)Session["transferorAccountType"];
        double transferorAmount = (double)Session["transferorAmount"];

        lblTransfererName.Text = transferer.ToString();
        if (transferorAccountType == AccountType.CHECKING)
        {
            lblTransfererAccount.Text = transferer.Checking.ToString();
        }
        else
        {
            lblTransfererAccount.Text = transferer.Saving.ToString();
        }
        lblTransferAmount.Text = "$" + transferorAmount.ToString();

        Customer transferee = (Customer)Session["transfereeCustomer"];
        AccountType transfereeAccountType = (AccountType)Session["transfereeAccountType"];

        lblTransfereeName.Text = transferee.ToString();
        if (transfereeAccountType == AccountType.CHECKING)
        {
            lblTransfereeAccount.Text = transferee.Checking.ToString();
        }
        else
        {
            lblTransfereeAccount.Text = transferee.Saving.ToString();
        }
    }

    protected void btnReviewBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("FundTransferTo.aspx");
    }

    protected void btnReviewComplete_Click(object sender, EventArgs e)
    {
        Response.Redirect("FundTransferResult.aspx");
    }
}