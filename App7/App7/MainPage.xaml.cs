using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App7
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        

        

        private void Calculate_Clicked(object sender, EventArgs e)
        {

            try
            {// time entry output
                String hours = TimeIn.Time.ToString("hh");
                String minutes = TimeIn.Time.ToString("mm");

            
                //converting inputs to doubles
                double a = double.Parse(ScHrWk.Text);
                double b = double.Parse(HrSoFar.Text);
                double c = double.Parse(hours);
                double d = double.Parse(minutes);          
                
                //converting decimal to standard time
                double x = (a - b);
                double y = (d / 60);
                double z = (c + y + x);

                // converting 24 hour time to 12 hour
                if (z > 24)
                { z = z - 24; }
                else if (z > 12)
                { z = z - 12; }

                TimeSpan timespan = TimeSpan.FromHours(z);
                string TimeOut = timespan.ToString("h\\:mm");

                //IfElse for bad or excessive input
                if (a <= b)
                { DisplayAlert("Uh-oh!", "You're already at or over your scheduled hours for the week!", "Okay!"); }
                else 
                DisplayAlert("You must clock out at", TimeOut, "Will Do!");
            }
            catch (Exception)
            {//TryCatch for NullEntry exception
                DisplayAlert("Uh-oh!", "Please ensure you fill out both your scheduled hours for the week and hours worked so far", "Alright!");
            }
        }
    }
}
