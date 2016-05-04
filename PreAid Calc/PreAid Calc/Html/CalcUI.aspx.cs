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
        Boolean priorTo2007 = false;
        Boolean purchasedLocalFeesPlan = false;
        Boolean purchasedDiffFeesPlan = false;
        private int creditHours = 0;
        private double tuitionAndFeeRate;
        private double prepaidTuitionPlanRate;
        private double localFeesPlanRate;
        private double prepaidDiffFeePlanRate;

        /*This var will be able to be updated by admin*/
        private double currentTuitionRate = 203.94;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*Called from HTML's oninput attribute to update creditHours immediately. Value must be between 0 and 18.*/
        protected void creditHoursUpdated(int updatedVal)
        {
            if (updatedVal < 0)
            {
                updatedVal = 0;
            }
            if (updatedVal > 18)
            {
                updatedVal = 18;
            }
            this.creditHours = updatedVal;
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
        }

        /*Called when corresponding HTML radio button is clicked to update vars.*/
        protected void localFeesPlanSelected()
        {
            this.purchasedLocalFeesPlan = q2rbtyes.Checked;
            this.localFeesPlanRate = purchasedLocalFeesPlan ? 38.28 : 0;
        }

        /*Called when corresponding HTML radio button is clicked to update vars.*/
        protected void diffFeePlanSelected()
        {
            this.purchasedDiffFeesPlan = q3rbtyes.Checked;
            this.prepaidDiffFeePlanRate = purchasedDiffFeesPlan ? 36.38 : 0;
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

        /*Prior to 2007 question*/
        protected void q1rbtyes_CheckedChanged(object sender, EventArgs e)
        {
            q1rbtno.Checked = false;
            priorTo2007Selected();
        }

        protected void q1rbtno_CheckedChanged(object sender, EventArgs e)
        {
            q1rbtyes.Checked = false;
            priorTo2007Selected();
        }

        /*Local Fees Plan question*/
        protected void q2rbtyes_CheckedChanged(object sender, EventArgs e)
        {
            q2rbtno.Checked = false;
            localFeesPlanSelected();
        }

        protected void q2rbtno_CheckedChanged(object sender, EventArgs e)
        {
            q2rbtyes.Checked = false;
            localFeesPlanSelected();
        }

        /*Differential Fee Plan question*/
        protected void q3rbtyes_CheckedChanged(object sender, EventArgs e)
        {
            q3rbtno.Checked = false;
            diffFeePlanSelected();
        }

        protected void q3rbtno_CheckedChanged(object sender, EventArgs e)
        {
            q3rbtyes.Checked = false;
            diffFeePlanSelected();
        }
    }
}
