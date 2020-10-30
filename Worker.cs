using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_labs
{
    //Man,Woman
    enum Sex
    {
        man = 1,
        woman
    }
    abstract class Worker
    {
        //заменить на свойства
        private readonly string fcs;
        private readonly Sex sex;
        

        //зачем ref параметр ?
        // constructors
        public Worker(ref string fcs, Sex sex)  {
            this.fcs = fcs;
            this.sex = sex;
        }


        // logic
        public abstract void DoWork(uint value);

        //используй enum
        public abstract string getClassType();

        public virtual uint CalculateSalary() 
        {
            // Console.WriteLine($"Worker with name {this.fcs} got salary:");
            return 0u;
        }
        //зачем?
        public virtual Dictionary<string, string> getWorkerInfo()
        {
            Dictionary<string, string> info = new Dictionary<string, string>(2);
            info.Add("fcs", this.fcs);
            info.Add("sex", this.sex.ToString());
            return info;
        }
        // getters
        //пиздец, джавист ебаный
        //public string Fcs { get; private set; }
        public string Fcs()
        {
            return fcs;
        }

        public Sex Sex()
        {
            return sex;
        }


        // json
        public abstract bool SaveToJsonFile(ref string filepath);

        public abstract void ToJSON();
    }
}
