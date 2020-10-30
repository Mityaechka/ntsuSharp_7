using System;
using System.Collections.Generic;
using System.Text;
//стандартная библиотек для работы с коллекцими
using System.Linq;
namespace Csharp_labs
{
    class Factory
    {
        //Исрользовать авто свойства вместо переменных
        //public List<Worker> Staff { get; set; }

        private readonly List<Worker> staff = new List<Worker>();
        public readonly string factoryName;
        public readonly string factoryCountry;
        //использовать int
        private byte dayOfMonth = 0;

        public Factory(string factoryName, string factoryCountry)
        {
            //убрать это говно
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
            //вместо делигата использовать лямбду
            //worker=> worker.CalculateSalary()
            this.staff.ForEach(delegate (Worker worker)
            {
                worker.CalculateSalary();
            });
        }
        private void DoWork() 
        {
            Random rand = new Random();
            //вместо делигата использовать лямбду
            //worker=> DoWork((uint)rand.Next(1, 15))
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
            //Использовать linq выражение
            //staff.RemoveAll(worker => worker.Fcs() == fcs);
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
        //бесполезный метод
        //если хочешь закрыть коллекцию от редактирования исползуй indexer
        public void AllWorker(out List<string> storage)
        {
            storage = new List<string>();
            foreach (Worker aWorker in staff)
            {
                storage.Add(aWorker.Fcs());
            }
        }
        //использовать get свойство
        //public uint WorkersQuantity=> (uint)this.staff.Count;
        public uint WorkersQuantity()
        {
            return (uint)this.staff.Count;
        }
        //использовать get свойство
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
