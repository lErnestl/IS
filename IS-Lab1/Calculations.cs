using IS_Lab1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_Lab1
{
    public static class Calculations
    {
        public static int CalculateResult(ParametersModel parameters, decimal x1, decimal x2)
        {
            
            decimal y = (x1 * parameters.w1) + (x2 * parameters.w2) + parameters.b;

            if(y <= 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public static ParametersModel CalculateParameters(ParametersModel currentParameters, decimal x1, decimal x2, decimal e)
        {
            ParametersModel newParameters = new ParametersModel();

            decimal eta = 0;

            // generates random eta
            while(eta == 0)
            {
                eta = (decimal)new Random().NextDouble();
            }

            // calculating w1(n+1)
            decimal w1p = currentParameters.w1 + (eta * e * x1);
            newParameters.w1 = w1p;
           
            // calculating w2(n+1)
            decimal w2p = currentParameters.w2 + (eta * e * x2);
            newParameters.w2 = w2p;

            // Calculating b(n+1);
            decimal bp = currentParameters.b + (eta * e);
            newParameters.b = bp;

            return newParameters;
        }

    }


}
