using IS_Lab1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace IS_Lab1
{
    public static class DataPreparation
    {
        [STAThread]
        public static List<DataModel> GetData()
        {
            string path;
            List<DataModel> data = new List<DataModel>();


            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Select Data File";
            fd.ShowDialog();
            path = fd.FileName;

            if (!string.IsNullOrEmpty(path))
            {
                var readed = File.ReadAllLines(path);

                foreach (var v in readed)
                {
                    try
                    {
                        var splitted = v.Split(',');

                        data.Add(new DataModel
                        {
                            x1 = decimal.Parse(splitted[0]),
                            x2 = decimal.Parse(splitted[1]),
                            d = int.Parse(splitted[2])
                        });
                    }
                    catch
                    {

                    }

                }

                return data;
            }

            else return null;
        }


        public static ParametersModel GetRandomParameters()
        {
            ParametersModel randomParameters = new ParametersModel();

            Random rnd = new Random();

            randomParameters.b = (decimal)rnd.Next(1, 1000000000) / 1000000000;
            randomParameters.w1 = (decimal)rnd.Next(1, 1000000000) / 1000000000;
            randomParameters.w2 = (decimal)rnd.Next(1, 1000000000) / 1000000000;

            return randomParameters;

        }
    }

 
}
