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
    public class Exp
    {
        public static bool IsIt(String func)
        {
            return (func == "exp");
        }

        public static String Diff(String func)
        {
            return "exp";
        }
    }
}