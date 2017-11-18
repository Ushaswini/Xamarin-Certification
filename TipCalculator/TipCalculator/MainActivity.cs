using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TipCalculator
{
    [Activity(Label = "TipCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnCalculate;
        EditText etInput;
        TextView tvTip;
        TextView tvTotal;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
            etInput = FindViewById<EditText>(Resource.Id.etInput);
            tvTip = FindViewById<TextView>(Resource.Id.tvTipVal);
            tvTotal = FindViewById<TextView>(Resource.Id.tvTotalVal);

            btnCalculate.Click += BtnCalculate_Click;

            
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            string text = etInput.Text;

            double bill;

            if (Double.TryParse(text, out bill))
            {
                double tip = bill * 0.15;
                Console.Write(tip.ToString());
                double total = bill + tip;

                tvTip.Text = tip.ToString();
                tvTotal.Text = total.ToString();
            }
                 

        }
    }
}

