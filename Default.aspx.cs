using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonus_Corkery
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Page.IsPostBack == false)
            {
                for (double iAmount = 1.00; iAmount <= 7.00; iAmount += .25)
                {
                    ddlInterestRate.Items.Add(iAmount.ToString());
                }
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {

            double yearlyInterestRate = Convert.ToDouble(ddlInterestRate.SelectedValue);
            int totalNumberOfMonths = Convert.ToInt32(txtYears.Text) * 12;
            double loanAmount = Convert.ToDouble(txtBorrowAmt.Text);
            double rate = (double)yearlyInterestRate / 100 / 12;
            double denominator = Math.Pow((1 + rate), totalNumberOfMonths);
            denominator = denominator - 1;
            double finalAmount =  (rate + (rate / denominator)) * loanAmount;

            finalAmount = Math.Round(finalAmount, 2);

            lblMonthlyDue.Text = "$" + finalAmount.ToString();

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlInterestRate.SelectedIndex = 0;
            txtBorrowAmt.Text = "";
            txtYears.Text = "";
        }
    }
}