using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransferFrom : System.Web.UI.Page
{
    List<Customer> availableCustomers = new List<Customer>();
    int availableCustomersCount = 0;
    int selectedTransferorIndex;
    AccountType selectedAccountType;
    double transferAmount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            if (Session["availableCustomers"] == null)
            {
                availableCustomers = Customer.GetAllCustomers();
                availableCustomersCount = availableCustomers.Count;
                Session["availableCustomers"] = availableCustomers;
                Session["totalCustomersCount"] = availableCustomersCount;
                Session["availableCustomersCount"] = availableCustomersCount;
                Session["fromPageEmpty"] = false;
                Session["toPageEmpty"] = false;
            }
            else
            {
                availableCustomers = (List<Customer>)Session["availableCustomers"];
                availableCustomersCount = (int)Session["availableCustomersCount"];
                availableCustomers.Insert(((int)Session["selectedTransferorIndex"] - 1), (Customer)Session["transferorCustomer"]);
                Session["availableCustomersCount"] = availableCustomersCount + 1;
            }

            for (int i = 0; i < availableCustomers.Count; i++)
            {
                ddlTransferor.Items.Add(availableCustomers[i].ToString());
            }

            if ((bool)Session["fromPageEmpty"] == false)
            {
                if (Session["selectedTransferorIndex"] != null && Session["transferorCustomer"] != null)
                {
                    ddlTransferor.SelectedIndex = (int)Session["selectedTransferorIndex"];
                    Customer transferor = (Customer)Session["transferorCustomer"];
                    rblFromAccount.Items[(int)AccountType.CHECKING].Text = transferor.Checking.ToString();
                    rblFromAccount.Items[(int)AccountType.SAVING].Text = transferor.Saving.ToString();
                }
                else
                {
                    ddlTransferor.ClearSelection();
                }

                if (Session["transferorAccountType"] != null)
                {
                    rblFromAccount.SelectedIndex = (int)Session["transferorAccountType"];
                }
                else
                {
                    rblFromAccount.ClearSelection();
                }

                if (Session["transferorAmount"] != null)
                {
                    transferAmount = (double)Session["transferorAmount"];
                    TextBox1.Text = transferAmount.ToString();
                }
                else
                {
                    TextBox1.Text = String.Empty;
                }
            }
            else
            {
                Session["selectedTransferorIndex"] = null;
                Session["transferorCustomer"] = null;
                ddlTransferor.ClearSelection();
                Session["transferorAccountType"] = null;
                rblFromAccount.ClearSelection();
                Session["transferorAmount"] = null;
                TextBox1.Text = String.Empty;
                Session["fromPageEmpty"] = false;
            }
        }
    }

    protected void ddlTransferor_SelectedIndexChanged(object sender, EventArgs e)
    {
        availableCustomers = (List<Customer>)Session["availableCustomers"];
        selectedTransferorIndex = ddlTransferor.Items.IndexOf(ddlTransferor.SelectedItem);
        Customer selectedCustomer = Customer.GetCustomerById(availableCustomers[selectedTransferorIndex - 1].Id);
        Session["transferorCustomer"] = selectedCustomer;
        Session["selectedTransferorIndex"] = selectedTransferorIndex;

        rblFromAccount.Items[(int)AccountType.CHECKING].Text = selectedCustomer.Checking.ToString();
        rblFromAccount.Items[(int)AccountType.SAVING].Text = selectedCustomer.Saving.ToString();
    }

    protected void rblFromAccount_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedAccountType = (AccountType)rblFromAccount.Items.IndexOf(rblFromAccount.SelectedItem);
        Session["transferorAccountType"] = selectedAccountType;
    }

    protected void CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        Customer transferorCustomer = (Customer)Session["transferorCustomer"];
        selectedAccountType = (AccountType)Session["transferorAccountType"];

        if (Double.TryParse(TextBox1.Text, out transferAmount) == false)
        {
            CustomValidator.ErrorMessage = "Input format is wrong";
            args.IsValid = false;
        }

        else if (transferAmount <= 0)
        {
            CustomValidator.ErrorMessage = "Transfer amount cannot be <= 0.";
            args.IsValid = false;
        }
        else if (selectedAccountType == AccountType.CHECKING)
        {
            if (transferAmount > transferorCustomer.Checking.Balance)
            {
                CustomValidator.ErrorMessage = "Transfer amount exceeds CHECKING account amount.";
                args.IsValid = false;
            }
            else if ((transferorCustomer.Status == CustomerStatus.REGULAR) &&
                     (transferAmount > 300))
            {
                CustomValidator.ErrorMessage = "Sorry, $300.00 is maximum for REGULAR customer.";
                args.IsValid = false;
            }
        }
        else if (selectedAccountType == AccountType.SAVING)
        {
            if (transferAmount > transferorCustomer.Saving.Balance)
            {
                CustomValidator.ErrorMessage = "Transfer amount exceeds SAVING account amount.";
                args.IsValid = false;
            }
        }
    }

    protected void btnTransferFrom_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Session["transferorAmount"] = transferAmount;

            Response.Redirect("FundTransferTo.aspx");
        }
    }
}