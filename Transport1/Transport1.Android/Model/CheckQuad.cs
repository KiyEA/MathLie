using System;


namespace Transport1.Droid.Model
{
    public class CheckQuad
    {
        public double x1;
        public double x2;
        public double x;
        double a;
        double b;
        double c;
        public int Parser(string quady)
        {
            try
            {
                var quad = quady;
                var index = quad.IndexOf("x^2");
                if (index > 1)
                {
                    var astr = quad.Substring(0, index);

                    if (!double.TryParse(astr, out a))
                    {
                        return -1;
                    }
                }
                if (index == 1)
                {
                    var astr = quad.Substring(0, index);
                    if (astr == "-") a = -1;
                    else
                    {
                        if (!double.TryParse(astr, out a))
                        {
                            return -1;
                        }
                    }
                }
                if (index == 0) a = 1;
                if (index < 0)
                {
                    return -1;
                }
                var str = quad.Substring(index + 3);
                index = str.IndexOf("x");
                if (index > 1)
                {
                    var bstr = str.Substring(0, index);

                    if (!double.TryParse(bstr, out b))
                    {
                        return -1;
                    }
                }
                if (index == 1)
                {
                    var bstr = str.Substring(0, index);
                    if (bstr == "-") b = -1;
                    else b = 1;
                }
                if (index < 0)
                {
                    b = 0;
                }
                str = str.Substring(index + 1);
                index = str.IndexOf("=");
                if (index == 0)
                {
                    c = 0;
                }
                else
                {
                    var cstr = str.Substring(0, index);
                    if (!double.TryParse(cstr, out c))
                    {
                        return -1;
                    }
                }
                double d = b * b - 4 * a * c;
                if (d < 0) return 0;
                if (d == 0)
                {
                    x = (-b / (2 * a));
                    return 1;
                }
                if (d > 0)
                {
                    x1 = ((-b - Math.Sqrt(d)) / (2 * a));
                    x2 = ((-b + Math.Sqrt(d)) / (2 * a));
                }
                return 2;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}