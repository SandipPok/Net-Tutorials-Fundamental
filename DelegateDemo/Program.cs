using System.Reflection;
using System.Xml.Serialization;
using static DelegatesDemo.Program;

namespace DelegatesDemo
{
    //First Example Delegate
    public delegate void WorkPerformedHandler(int hours, WorkType workType);
    //Second Example Delegate
    public delegate void CallbackMethodHandler(string message);
    //Third Example Delegate
    public delegate void DoSomeMethodHandler(string message);

    public class Program
    {
        public static void Main(string[] args)
        {
            //First Example Functions
            WorkPerformedHandler del1 = new WorkPerformedHandler(Manager_WorkPerformed);
            del1(10, WorkType.Golf);

            Console.ReadKey();

            //Second Example Functions
            Program obj = new Program();
            CallbackMethodHandler del2 = new CallbackMethodHandler(obj.CallbackMethod);

            DoSomething(del2);

            Console.ReadKey();

            //Third Example Functions
            SomeClass obj2 = new SomeClass();
            DoSomeMethodHandler del3 = new DoSomeMethodHandler(obj2.DoSomework);

            MethodInfo Method = del3.Method;
            object Target = del3.Target;
            Delegate[] InvocationList = del3.GetInvocationList();

            Console.WriteLine($"\nMethod Property: {Method}");
            Console.WriteLine($"Target Property: {Target}");

            foreach(var item in InvocationList)
            {
                Console.WriteLine($"InvocationList: {item}");
            }

            Console.ReadKey();
        }

        //First Example Function
        public static void Manager_WorkPerformed(int workHours, WorkType wType)
        {
            Console.WriteLine("Work Performed by Event Handler");
            Console.WriteLine($"Work Hours: {workHours}, Work Type:{wType}");
        }
        public enum WorkType
        {
            Golf,
            GotoMeetings,
            GenerateReports
        }

        //Second Example Functions
        public static void DoSomething(CallbackMethodHandler del)
        {
            Console.WriteLine("\nProcessing some task");
            del("DonDai");
        }

        public void CallbackMethod(string message)
        {
            Console.WriteLine("CallbackMethod Executed");
            Console.WriteLine($"Hello: {message}, Good Morning");
        }
    }

    //Third example function
    public class SomeClass
    {
        public void DoSomework(string message)
        {
            Console.WriteLine("DoSomework Executed");
            Console.WriteLine($"Hello: {message}, Good Morning");
        }
    }
}