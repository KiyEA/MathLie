using System;
using System.Collections.Generic;

using ELW.Library.Math;
using ELW.Library.Math.Tools;
using ELW.Library.Math.Expressions;
using System.Threading.Tasks;

namespace Transport1.Droid.Model
{
   public class Integral
    {
        public async Task<double> Answer(string func, double step, double a, double b)
        {
            try
            {
                if (func == "x/x") return b - a;
                double res = 0;
                double x = 0;
                int N = (int)((b - a) / step);
                for (int i = 0; i < N; i++)
                {
                    x = step * i + a;
                    res += await H(x, func) * step;
                }
                Math.Round(res, 1);

                return await Task.FromResult(res);
            }
            catch(Exception e)
            {
                return -1;
            }
        }
        private async Task<double> H(double x, string function)
        {
            List<VariableValue> variables = new List<VariableValue>
            {
                new VariableValue(x, "x")
            };
            PreparedExpression preparedExpression = ToolsHelper.Parser.Parse(function);
            CompiledExpression compiledExpression = ToolsHelper.Compiler.Compile(preparedExpression);
            return await Task.FromResult(ToolsHelper.Calculator.Calculate(compiledExpression, variables));
        }
    }
}