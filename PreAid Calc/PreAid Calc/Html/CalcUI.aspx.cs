using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PreAid_Calc
{
    public partial class CalcUI : System.Web.UI.Page
    {
        /*Constants to be taken from web page*/
        /*Will be set when associated method is called*/
        Boolean priorTo2007;
        Boolean purchasedLocalFeesPlan;
        Boolean purchasedDiffFeesPlan;
        private int creditHours;
        private double tuitionAndFeeRate;
        private double prepaidTuitionPlanRate;
        private double localFeesPlanRate;
        private double prepaidDiffFeePlanRate;

        /*This var will be able to be updated by admin*/
        private double currentTuitionRate = 203.94;

        /*Keeps track of credit hours field value before modification*/
        private int currentVal;

        protected void Page_Load(object sender, EventArgs e)
        {
            /*Retrieve values for global vars*/
            this.priorTo2007 = (ViewState["priorTo2007"]!=null) ? (bool)ViewState["priorTo2007"] : false;
            this.purchasedLocalFeesPlan = (ViewState["purchasedLocalFeesPlan"]!=null) ? (bool)ViewState["purchasedLocalFeesPlan"] : false;
            this.purchasedDiffFeesPlan = (ViewState["purchasedDiffFeesPlan"]!=null) ? (bool)ViewState["purchasedDiffFeesPlan"] : false;
            this.creditHours = (ViewState["creditHours"]!=null) ? (int)ViewState["creditHours"] : 0;
            this.tuitionAndFeeRate = (ViewState["tuitionAndFeeRate"]!=null) ? (double)ViewState["tuitionAndFeeRate"] : 0.00;
            this.prepaidTuitionPlanRate = (ViewState["prepaidTuitionPlanRate"]!=null) ? (double)ViewState["prepaidTuitionPlanRate"] : 0.00;
            this.localFeesPlanRate = (ViewState["localFeesPlanRate"]!=null) ? (double)ViewState["localFeesPlanRate"] : 0.00;
            this.prepaidDiffFeePlanRate = (ViewState["prepaidDiffFeePlanRate"]!=null) ? (double)ViewState["prepaidDiffFeePlanRate"] : 0.00;
            this.currentVal = (ViewState["currentVal"]!=null) ? (int)ViewState["currentVal"] : 0;
        }

        /*Called from HTML's oninput attribute to update creditHours immediately. Value must be between 0 and 18.*/
        protected void creditHoursUpdated(String updatedVal)
        {
            /*Take in only valid input*/
            int newVal;
            if (int.TryParse(updatedVal, out newVal))
            {
                if (newVal < 0)
                {
                    newVal = 0;
                }
                else if (newVal > 18)
                {
                    newVal = 18;
                }

                /*Update variables and text field*/
                this.creditHours = newVal;
                currentVal = newVal;
                credHours.Text = currentVal.ToString();

                /*Update ViewState vars*/
                ViewState.Add("currentVal", currentVal);
                ViewState.Add("creditHours", creditHours);
            }
            else //Parse failed, reset text field value
            {
                credHours.Text = currentVal.ToString();
            }
        }

        /*When prior to 2007 "yes" clicked, disable diff fee plan list (use onclick)*/
        /*On click, take in value of source. Set selected to false of other radio button in list*/
        /*Use Request.Form to get values*/

        /*Called when corresponding HTML radio button is clicked to update vars.*/
        protected void priorTo2007Selected()
        {
            this.priorTo2007 = q1rbtyes.Checked;
            this.tuitionAndFeeRate = priorTo2007 ? 167.56 : currentTuitionRate;
            this.prepaidTuitionPlanRate = 117.08;

            /*If purchased prior to 2007, differential fees plan must be false*/
            if (priorTo2007)
            {
                /*Disable diffFeesPlan buttons, hand off to respective method*/
                q3rbtno.Enabled = false;
                q3rbtno.Checked = true;
                q3rbtyes.Enabled = false;
                q3rbtyes.Checked = false;
                diffFeePlanSelected();
            }
            else //Re-enable buttons if option changed to "No"
            {
                q3rbtno.Enabled = true;
                q3rbtno.Checked = false;
                q3rbtyes.Enabled = true;
                q3rbtyes.Checked = false;
                diffFeePlanSelected();
            }

            /*Update ViewState vars*/
            ViewState["priorTo2007"] = this.priorTo2007;
            ViewState["tuitionAndFeeRate"] = this.tuitionAndFeeRate;
            ViewState["prepaidTuitionPlanRate"] = this.prepaidTuitionPlanRate;
        }

        /*Called when corresponding HTML radio button is clicked to update vars.*/
        protected void localFeesPlanSelected()
        {
            this.purchasedLocalFeesPlan = q2rbtyes.Checked;
            this.localFeesPlanRate = purchasedLocalFeesPlan ? 38.28 : 0.00;

            /*Update ViewState vars*/
            ViewState["purchasedLocalFeesPlan"] = this.purchasedLocalFeesPlan;
            ViewState["localFeesPlanRate"] = this.localFeesPlanRate;
        }

        /*Called when corresponding HTML radio button is clicked to update vars.*/
        protected void diffFeePlanSelected()
        {
            this.purchasedDiffFeesPlan = q3rbtyes.Checked;
            this.prepaidDiffFeePlanRate = purchasedDiffFeesPlan ? 36.38 : 0.00;

            /*Update ViewState vars*/
            ViewState["purchasedDiffFeesPlan"] = this.purchasedDiffFeesPlan;
            ViewState["prepaidDiffFeePlanRate"] = this.prepaidDiffFeePlanRate;
        }

        /*Called when TBD*/
        // TODO decide when method is called
        public void displayRateSummary()
        {
            System.Console.WriteLine("Estimated Tuition & Fee Rate at FGCU (per credit hour): {0}", tuitionAndFeeRate);
            System.Console.WriteLine("Estimated Florida Prepaid Tuition Plan Rate (per credit hour): {0}", prepaidTuitionPlanRate);
            System.Console.WriteLine("Estimated Florida Prepaid Local Fees Plan Rate (per credit hour): {0}", localFeesPlanRate);
            System.Console.WriteLine("Estimated Florida Prepaid Differential Fee Plan Rate (per credit hour): {0}", prepaidDiffFeePlanRate);
        }

        /*Called when TBD*/
        // TODO decide when method is called
        public void displayCostSummary()
        {
            double estTuitionAndFees = creditHours * tuitionAndFeeRate;
            double estPrepaidBenefit = (prepaidTuitionPlanRate + localFeesPlanRate + prepaidDiffFeePlanRate) * creditHours;
            System.Console.WriteLine("Total Estimated Tuition & Fees: " + estTuitionAndFees);
            System.Console.WriteLine("Total Estimated Florida Prepaid Benefit: " + estPrepaidBenefit);
            System.Console.WriteLine("Your Estimated Out-of-Pocket Tuition & Fee Cost (per term): " + (estTuitionAndFees - estPrepaidBenefit));
        }

        public void displayResults()
        {
            /*Rate Summary*/
            estTuitionRate.Text = tuitionAndFeeRate.ToString();
            estTuitionPlanRate.Text = prepaidTuitionPlanRate.ToString();
            estLocalFeesRate.Text = localFeesPlanRate.ToString();
            estDiffPlanRate.Text = prepaidDiffFeePlanRate.ToString();

            /*Cost Summary*/
            double estTuitionAndFees = creditHours * tuitionAndFeeRate;
            double estPrepaidBenefit = (prepaidTuitionPlanRate + localFeesPlanRate + prepaidDiffFeePlanRate) * creditHours;

            estTuititon.Text = String.Format("{0:0.00}", estTuitionAndFees);
            estBenefit.Text = String.Format("{0:0.00}", estPrepaidBenefit);
            estOutOfPocket.Text = String.Format("{0:0.00}", (estTuitionAndFees - estPrepaidBenefit));
        }

        /*Prior to 2007 question*/
        protected void q1rbtyes_CheckedChanged(object sender, EventArgs e)
        {
            q1rbtno.Checked = false;
            priorTo2007Selected();
            displayResults();
        }

        protected void q1rbtno_CheckedChanged(object sender, EventArgs e)
        {
            q1rbtyes.Checked = false;
            priorTo2007Selected();
            displayResults();
        }

        /*Local Fees Plan question*/
        protected void q2rbtyes_CheckedChanged(object sender, EventArgs e)
        {
            q2rbtno.Checked = false;
            localFeesPlanSelected();
            displayResults();
        }

        protected void q2rbtno_CheckedChanged(object sender, EventArgs e)
        {
            q2rbtyes.Checked = false;
            localFeesPlanSelected();
            displayResults();
        }

        /*Differential Fee Plan question*/
        protected void q3rbtyes_CheckedChanged(object sender, EventArgs e)
        {
            q3rbtno.Checked = false;
            diffFeePlanSelected();
            displayResults();
        }

        protected void q3rbtno_CheckedChanged(object sender, EventArgs e)
        {
            q3rbtyes.Checked = false;
            diffFeePlanSelected();
            displayResults();
        }

        protected void creditHours_TextChanged(object sender, EventArgs e)
        {
            String val = credHours.Text;
            creditHoursUpdated(credHours.Text);
            displayResults();
        }
    }
}
