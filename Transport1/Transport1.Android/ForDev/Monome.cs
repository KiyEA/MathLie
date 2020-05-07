using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Transport1.Droid.Model
{
    public class Monome
    {
        public static bool IsIt(String func)
        {
            if (func.Length > 2 && func.Substring(0, 2) == "x^")
            {
                try
                {
                    Convert.ToDouble(func.Substring(2));
                    return true;
                }
                catch (Exception) { }
            }

            return false;
        }

        public static String Diff(String func)
        {
            Double power = Convert.ToDouble(func.Substring(2));
            return power.ToString() + "*x^" + (power - 1).ToString();
        }
    }
}