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
        if (this.IsPostBack == false)
        {
            Customer transferer = (Customer)Session["transferorCustomer"];
            AccountType transferorAccountType = (AccountType)Session["transferorAccountType"];
            double transferorAmount = (double)Session["transferorAmount"];
            Customer transferee = (Customer)Session["transfereeCustomer"];
            AccountType transfereeAccountType = (AccountType)Session["transfereeAccountType"];
            TransferTransaction transferTransaction = new TransferTransaction(transferorAmount);
            TransactionResult transactionResult = TransactionResult.SUCCESS;

            if (transferorAccountType == AccountType.CHECKING)
            {
                transferTransaction.FromAccount = transferer.Checking;
            }
            else
            {
                transferTransaction.FromAccount = transferer.Saving;
            }

            if (transfereeAccountType == AccountType.CHECKING)
            {
                transferTransaction.ToAccount = transferee.Checking;
            }
            else
            {
                transferTransaction.ToAccount = transferee.Saving;
            }

            transactionResult = transferTransaction.Execute();

            if (transactionResult != TransactionResult.SUCCESS)
            {
                PanelSuccess.Visible = false;
                PanelFailed.Visible = true;
                lblError.Text = "Transaction Failed! " + transactionResult.ToString();
            }
            else
            {
                lblTransferAmount.Text = "$" + transferorAmount.ToString();

                lblTransfererName.Text = transferer.ToString();
                if (transferorAccountType == AccountType.CHECKING)
                {
                    lblTransfererAccount.Text = transferer.Checking.ToString();
                }
                else
                {
                    lblTransfererAccount.Text = transferer.Saving.ToString();
                }

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
        }
    }

    protected void btnReviewComplete_Click(object sender, EventArgs e)
    {
        Session["fromPageEmpty"] = true;
        Session["toPageEmpty"] = true;
        Response.Redirect("FundTransferFrom.aspx");
    }
}