using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_labs
{
    class WorkerHour : Worker
    {
        private readonly uint standardSalaryPerHour,
                            proccessionSalaryPerHour,
                            standardHoursPerMonth;

        private uint totalWorkedHours = 0u;

        public WorkerHour(string fcs, Sex sex, uint standardSalaryPerHour, uint proccessionSalaryPerHour, uint standardHoursPerMonth)
            : base(ref fcs, sex)
        {
            if(fcs.Length < 2)
                throw new Exception("fcs should be > 1");

            this.standardSalaryPerHour = standardSalaryPerHour;
            this.proccessionSalaryPerHour = proccessionSalaryPerHour;
            this.standardHoursPerMonth = standardHoursPerMonth;

        }


        public override void DoWork(uint value)
        {
            this.totalWorkedHours += value;
        }

        public override uint CalculateSalary()
        {
            // base.CalculateSalary();
            uint processionSalaryPerMonth;
            uint totalWorkedHoursPerMonth = this.totalWorkedHours;
            this.totalWorkedHours = 0;
            

            if(totalWorkedHoursPerMonth >= standardHoursPerMonth)
            {
                processionSalaryPerMonth = (uint)(totalWorkedHoursPerMonth - this.standardHoursPerMonth) * this.proccessionSalaryPerHour;

                Console.WriteLine(this.standardHoursPerMonth * this.standardSalaryPerHour + processionSalaryPerMonth);
                return this.standardHoursPerMonth * this.standardSalaryPerHour + processionSalaryPerMonth;
            }
            Console.WriteLine(totalWorkedHoursPerMonth * this.standardSalaryPerHour);
            return totalWorkedHoursPerMonth * this.standardSalaryPerHour;
        }

        public override string getClassType()
        {
            return "WorkerHour";
        }


        public new Dictionary<string, string> getWorkerInfo()
        {
            var info = base.getWorkerInfo();
            info.Add("standardSalaryPerHour", this.standardSalaryPerHour.ToString());
            info.Add("proccessionSalaryPerHour", this.proccessionSalaryPerHour.ToString());
            info.Add("standardHoursPerMonth", this.standardHoursPerMonth.ToString());
            info.Add("totalWorkedHours", this.totalWorkedHours.ToString());

            return info;
        }

        public override void ToJSON()
        {
            
        }

        public override bool SaveToJsonFile(ref string filepath)
        {
            return true;
        }
    }
}
