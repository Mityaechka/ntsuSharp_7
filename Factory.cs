using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_labs
{
    class Factory
    {
        private readonly List<Worker> staff = new List<Worker>();
        public readonly string factoryName;
        public readonly string factoryCountry;
        private byte dayOfMonth = 0;

        public Factory(string factoryName, string factoryCountry)
        {
            if (factoryName.Length == 0)
                throw new Exception("ERROR\nfactoryName.Length == 0;\n");
            if (factoryCountry.Length == 0)
                throw new Exception("ERROR\nfactoryCountry.Length == 0;\n");

            this.factoryName = factoryName;
            this.factoryCountry = factoryCountry;
        }

        public Factory() {}

        private void GiveSalary() 
        {
            this.staff.ForEach(delegate (Worker worker)
            {
                worker.CalculateSalary();
            });
        }
        private void DoWork() 
        {
            Random rand = new Random();
            this.staff.ForEach(delegate (Worker worker)
            {
                worker.DoWork((uint)rand.Next(1, 15));
            });
        }

        public void RecruitMemberStaff(Worker recruitWorker)
        {
            staff.Add(recruitWorker);
        }

        public bool DismissMemberStaff(string fcs)
        {
            foreach (Worker aWorker in this.staff)
            {
                if (aWorker.Fcs() == fcs)
                {
                    this.staff.Remove(aWorker);
                    return true;
                }
            }
            return false;
        }

        public void SimulateWork(byte days)
        {
            for(byte i = 0; i < days; ++i)
            {
                ++this.dayOfMonth;
                if (this.dayOfMonth % 15 == 0)
                    GiveSalary();
                if (this.dayOfMonth % 30 == 0)
                    this.dayOfMonth = 0;

                DoWork();
            }
        }

        public void AllWorker(out List<string> storage)
        {
            storage = new List<string>();
            foreach (Worker aWorker in staff)
            {
                storage.Add(aWorker.Fcs());
            }
        }

        public uint WorkersQuantity()
        {
            return (uint)this.staff.Count;
        }

        public Dictionary<string, string> WorkerInfo(string fcs)
        {
            foreach(Worker aWorker in staff)
            {
                if(aWorker.Fcs() == fcs)
                {
                    return aWorker.getWorkerInfo();
                }
            }
            return null;
        }

    }
}
