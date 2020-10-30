using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_labs
{
    //почему тесты вылетают?
    class Test
    {
        public static void TestWorkerComission()
        {
            WorkerComission Pyotr = new WorkerComission("Pytor Solo", Sex.woman, 10000, 0.05);
            
            Pyotr.DoWork(15000u);

            if (Pyotr.CalculateSalary() != 85000)
                throw new Exception("WorkerComission.CalculatePayment wrong result\n");

            if (Pyotr.getClassType() != "WorkerComission")
                throw new Exception("WorkerComission.GetClassType wrong result;\n");

            var pyotrInfo = Pyotr.getWorkerInfo();

            if(pyotrInfo["fcs"] != "Pytor Solo")
                throw new Exception("WorkerComissionInfo[\"key\"] != \"keyvalue\"\n");

        }

        public static void TestWorkerHour()
        {
            WorkerHour Semyon = new WorkerHour("Semyon So", Sex.man, 1500, 2150, 150);

            Semyon.DoWork(140);
            if (Semyon.CalculateSalary() != 210000)
                throw new Exception("WorkerHour.paymentCalculate wrong result with value <= edgeHours\n");

            Semyon.DoWork(190);
            if (Semyon.CalculateSalary() != 311000)
                throw new Exception("WorkerHour.paymentCalculate wrong result with value > edgeHours\n");

            var semyonInfo = Semyon.getWorkerInfo();

            if (semyonInfo["fcs"] != "Semyon So")
                throw new Exception("workerHourInfo[\"key\"] != \"keyvalue\"\n");
        }

        public static void TestFactory()
        {
            WorkerComission Pyotr = new WorkerComission("Pytor Solo", Sex.woman, 10000, 0.05);
            WorkerHour Semyon = new WorkerHour("Semyon So", Sex.man, 1500, 2150, 150);

            Factory Jojo = new Factory("Jojo INC.", "Anime");

            Jojo.RecruitMemberStaff(Pyotr);
            Jojo.RecruitMemberStaff(Semyon);

            if (Jojo.WorkersQuantity() != 2)
                throw new Exception("Jojo.WorkersQuantity wrong value;\n");

            var pytorInfo = Jojo.WorkerInfo("Pytor Solo");

            if(pytorInfo["fcs"] != "Pytor Solo")
                throw new Exception("workerInfo[\"key\"] != \"keyvalue\";\n");

            Jojo.DismissMemberStaff("Pytor Solo");
            pytorInfo = Jojo.WorkerInfo("Pytor Solo");

            if(pytorInfo != null)
                throw new Exception("Factory.DismissMemberStaff(\"workerName\");\n");

        }
    }
}
