using IS_Lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Lab1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            List<DataModel> data = DataPreparation.GetData();
            ParametersModel parameters = DataPreparation.GetRandomParameters();
            int iteration = 1;

            decimal totalError = decimal.MaxValue;

            if (data != null)
            {
                while (totalError != 0)
                {
                    try
                    {
                        List<decimal> loaclErrors = new List<decimal>();

                        foreach(var entry in data)
                        {
                            int y = Calculations.CalculateResult(parameters, entry.x1, entry.x2);

                            decimal e = entry.d - y;

                            loaclErrors.Add(e);

                            parameters = Calculations.CalculateParameters(parameters, entry.x1, entry.x2, e);

                            //Console.WriteLine($"{parameters.b}, {parameters.w1}, {parameters.w2}");
                        }


                        totalError = Math.Abs(loaclErrors.ToArray().Average());

                        Console.WriteLine($"Iteration: {iteration}, Average Error: {totalError}");
                        iteration++;
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                Console.WriteLine("Error in reading data");
            }
          

            Console.ReadLine();
        }
    }
}
