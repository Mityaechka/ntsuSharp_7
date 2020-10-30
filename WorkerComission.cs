using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_labs
{
    class WorkerComission : Worker
    {

        private uint totalSoldSum;
        private readonly uint standardSalary;
        private readonly double salaryRate;

        public WorkerComission(string fcs, Sex sex, uint standardSalary, double salaryRate) 
            :base(ref fcs, sex)
        {
            if (standardSalary <= 0)
                throw new Exception("ERROR\npayment == 0\n");
            if (salaryRate < 0)
                throw new Exception("ERROR\npaymentRate < 0\n");

            this.standardSalary = standardSalary;
            this.salaryRate = salaryRate;
        }


        public override void DoWork(uint value)
        {
            this.totalSoldSum += value * 100;
        }

        public override uint CalculateSalary()
        {
            //бесконечные конвертации стоят "выигранных" 3 байт?
            uint priceSum = ((uint)Convert.ToInt32(Math.Round(this.standardSalary + (this.totalSoldSum * this.salaryRate))));
            this.totalSoldSum = 0;
            return priceSum;
        }

        public override string getClassType()
        {
            return "WorkerComission";
        }

        public override void ToJSON()
        {

        }

        public override bool SaveToJsonFile(ref string filepath)
        {
            return true;
        }

        public new Dictionary<string, string> getWorkerInfo()
        {
            var info = base.getWorkerInfo();
            info.Add("totalSoldSum", totalSoldSum.ToString());
            info.Add("standardSalary", totalSoldSum.ToString());
            info.Add("salaryRate", totalSoldSum.ToString());
            return info;
        }
    }
}
