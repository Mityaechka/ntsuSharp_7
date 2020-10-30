using System;

namespace Csharp_labs
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Test.TestWorkerComission();
                Test.TestWorkerHour();
                Test.TestFactory();
            }
            catch (Exception e)
            {
                Console.WriteLine("Some Test was not passed\nTest LOG:\n");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("All tests was passed successfully\n\n\n");

            WorkerComission Pyotr = new WorkerComission("Pytor Solo", Sex.woman, 10000, 0.05);
            WorkerHour Semyon = new WorkerHour("Semyon So", Sex.man, 1500, 2150, 150);

            Factory Jojo = new Factory("Jojo INC.", "Anime");

            Jojo.RecruitMemberStaff(Pyotr);
            Jojo.RecruitMemberStaff(Semyon);

            Jojo.SimulateWork(32);
        }
    }
}
