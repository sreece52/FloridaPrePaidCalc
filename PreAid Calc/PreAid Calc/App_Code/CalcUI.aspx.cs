using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloridaPrepaidCalc
{
    class Calculator
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

        public static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            calc.creditHoursUpdated(12);

            calc.priorTo2007Selected(true);
            calc.localFeesPlanSelected(true);
            calc.diffFeePlanSelected(true);

            calc.displayRateSummary();
            calc.displayCostSummary();

            System.Console.ReadLine();
        }

        /*Called from HTML's oninput attribute to update creditHours immediately. Value must be between 0 and 18.*/
        protected void creditHoursUpdated(int updatedVal)
        {
            if(updatedVal < 0)
            {
                updatedVal = 0;
            }
            if(updatedVal > 18)
            {
                updatedVal = 18;
            }
            this.creditHours = updatedVal;
        }

        /*When prior to 2007 "yes" clicked, disable diff fee plan list (use onclick)*/
        /*On click, take in value of source. Set selected to false of other radio button in list*/
        /*Use Request.Form to get values*/

        /*Called when corresponding HTML radio button is clicked to update vars.*/
        protected void priorTo2007Selected(Boolean selection)
        {
            this.priorTo2007 = selection;
            this.tuitionAndFeeRate = priorTo2007 ? 167.56 : currentTuitionRate;
            this.prepaidTuitionPlanRate = 117.08;

            /*If purchased prior to 2007, differential fees plan must be false*/
            if (priorTo2007)
            {
                /*Disable diffFeesPlan buttons, call diffFeePlanSelected to update related vars*/
                purchasedDiffFeesPlan = false;
            }
        }

        /*Called when corresponding HTML radio button is clicked to update vars.*/
        protected void localFeesPlanSelected(Boolean selection)
        {
            this.purchasedLocalFeesPlan = selection;
            this.localFeesPlanRate = purchasedLocalFeesPlan ? 38.28 : 0;
        }

        /*Called when corresponding HTML radio button is clicked to update vars.*/
        protected void diffFeePlanSelected(Boolean selection)
        {
            this.purchasedDiffFeesPlan = priorTo2007 ? false : selection;
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

        public void Test1()
        {
            System.Console.WriteLine("Test1");
            System.Console.ReadLine();
        }

        public void Test2()
        {
            System.Console.WriteLine("Test2");
            System.Console.ReadLine();
        }
    }
}
