using System;

namespace Transport1.Droid.Model
{
   public class Det
    {
        const double EPS = 1E-9;
        double det = 1;
        public double GetDet(double[][]a, double[][]b, int N)
        {
            for(int i = 0; i < N; i++)
            {
                int k = i;
                for (int j = i + 1; j < N; ++j)
                    if (Math.Abs(a[j][i]) > Math.Abs(a[k][i]))
                        k = j;
                if (Math.Abs(a[k][i]) < EPS)
                {
                    det = 0;
                    break;
                }
                b[0] = a[i];
                a[i] = a[k];
                a[k] = b[0];
                if (i != k)
                    det = -det;
                det *= a[i][i];
                for (int j = i + 1; j < N; ++j)
                    a[i][j] /= a[i][i];
                for (int j = 0; j < N; ++j)
                    if ((j != i) && (Math.Abs(a[j][i]) > EPS))
                        for (k = i + 1; k < N; ++k)
                            a[j][k] -= a[i][k] * a[j][i];
               
            }
            return det;
        }
    }
}