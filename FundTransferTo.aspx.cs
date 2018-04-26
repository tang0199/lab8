using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransfer : System.Web.UI.Page
{
    List<Customer> availableCustomers = new List<Customer>();
    int availableCustomersCount = 0;
    int selectedTransfereeIndex;
    AccountType selectedAccountType;

    protected void Page_Load(object sender, EventArgs e)
    {
        availableCustomers = (List<Customer>)Session["availableCustomers"];
        availableCustomersCount = (int)Session["availableCustomersCount"];

        if (this.IsPostBack == false)
        {
            if (availableCustomersCount == (int)Session["totalCustomersCount"])
            {
                availableCustomers.RemoveAt(((int)Session["selectedTransferorIndex"] - 1));
                Session["availableCustomersCount"] = availableCustomersCount - 1;
            }

            for (int i = 0; i < availableCustomers.Count; i++)
            {
                ddlTransferee.Items.Add(availableCustomers[i].ToString());
            }

            if ((bool)Session["toPageEmpty"] == false)
            {
                if (Session["selectedTransfereeIndex"] != null && Session["transfereeCustomer"] != null)
                {
                    ddlTransferee.SelectedIndex = (int)Session["selectedTransfereeIndex"];
                    Customer transferee = (Customer)Session["transfereeCustomer"];
                    rblToAccount.Items[(int)AccountType.CHECKING].Text = transferee.Checking.ToString();
                    rblToAccount.Items[(int)AccountType.SAVING].Text = transferee.Saving.ToString();
                }
                else
                {
                    ddlTransferee.ClearSelection();
                }

                if (Session["transfereeAccountType"] != null)
                {
                    rblToAccount.SelectedIndex = (int)Session["transfereeAccountType"];
                }
                else
                {
                    rblToAccount.ClearSelection();
                }
            }
            else
            {
                Session["selectedTransfereeIndex"] = null;
                Session["transfereeCustomer"] = null;
                ddlTransferee.ClearSelection();
                Session["transfereeAccountType"] = null;
                rblToAccount.ClearSelection();
                Session["toPageEmpty"] = false;
            }
        }
    }

    protected void ddlTransferee_SelectedIndexChanged(object sender, EventArgs e)
    {
        availableCustomers = (List<Customer>)Session["availableCustomers"];
        selectedTransfereeIndex = ddlTransferee.Items.IndexOf(ddlTransferee.SelectedItem);
        Customer selectedCustomer = Customer.GetCustomerById(availableCustomers[selectedTransfereeIndex - 1].Id);
        Session["transfereeCustomer"] = selectedCustomer;
        Session["selectedTransfereeIndex"] = selectedTransfereeIndex;

        rblToAccount.Items[(int)AccountType.CHECKING].Text = selectedCustomer.Checking.ToString();
        rblToAccount.Items[(int)AccountType.SAVING].Text = selectedCustomer.Saving.ToString();
    }

    protected void rblToAccount_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedAccountType = (AccountType)rblToAccount.Items.IndexOf(rblToAccount.SelectedItem);
        Session["transfereeAccountType"] = selectedAccountType;
    }

    protected void btnTransfereeBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("FundTransferFrom.aspx");
    }

    protected void btnTransfereeNext_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Response.Redirect("FundTransferConfirmation.aspx");
        }
    }
}