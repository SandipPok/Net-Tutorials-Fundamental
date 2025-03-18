namespace Ex12_Attach_Child_Task_To_Parent_Task
{
    class MethodImpl
    {
        public static void DetachChildTask()
        {
            Console.WriteLine("Detach Method Started");

            var parentTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer Task Started");
                var childTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Child Task Started");
                    Thread.Sleep(5000);
                    Console.WriteLine("Child Task Completed");
                });
                Console.WriteLine("Outer Task Completed");
            });

            parentTask.Wait();
            Console.WriteLine("Detach Method Completed");
            Console.ReadKey();
        }

        public static async Task DetachChildTaskWithReturnType()
        {
            Console.WriteLine("Detach Method with Return Type Started");
            var parentTask = Task<string>.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent Task Started");

                var childTask = Task<string>.Factory.StartNew(() =>
                {
                    Console.WriteLine("Child Task Started");
                    Thread.Sleep(5000);
                    Console.WriteLine("Child Task Completed");
                    return "Task Completed";
                });

                return childTask.Result;
            });
            await parentTask;
            Console.WriteLine("Parent Task Completed");
            Console.WriteLine("Detach Method with Return Type Completed");
        }

        public static async Task AttachChildTask()
        {
            Console.WriteLine("Attach Child Task Started");

            var parentTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent Task Started");

                var childTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Child Task Started");
                    Thread.Sleep(5000);
                    Console.WriteLine("Child Task Completed");
                }, TaskCreationOptions.AttachedToParent);

                Console.WriteLine("Parent Task Completed");
            });

            await parentTask;
            Console.WriteLine("Attach Child Task Completed");
        }

        public static async Task PreventParentAttachFromChildTask()
        {
            Console.WriteLine("Prevent Parent Attach From Child Task Started");

            var parentTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent Task Started");

                var childTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Child Task Started");
                    Thread.Sleep(5000);
                    Console.WriteLine("Child Task Completed");
                }, TaskCreationOptions.AttachedToParent);

                Console.WriteLine("Parent Task Completed");
            }, TaskCreationOptions.DenyChildAttach);

            await parentTask;
            Console.WriteLine("Prevent Parent Attach From Child Task Completed");
        }

        public static async Task PreventTaskUsingTaskRun()
        {
            Console.WriteLine("Prevent Parent Attach From Child Using Task Run Task Started");

            var parentTask = Task.Run(() =>
            {
                Console.WriteLine("Parent Task Started");

                var childTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Child Task Started");
                    Thread.Sleep(5000);
                    Console.WriteLine("Child Task Completed");
                }, TaskCreationOptions.AttachedToParent);

                Console.WriteLine("Parent Task Completed");
            });

            await parentTask;
            Console.WriteLine("Prevent Parent Attach From Child Using Task Run Task Completed");
            Console.ReadKey();
        }

        public static async Task ExceptionDetachedChildTask()
        {
            Console.WriteLine("Exception Detached Child Task Method Started");

            try
            {
                var parentTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Parent Task Started");
                    var childTask = Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("Child Task Started");
                        int x = 10, y = 0;
                        int z = x / y;
                        Console.WriteLine("Child Task Completed");
                    });
                    Console.WriteLine("Parent Task Completed");
                });

                await parentTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }

            Console.WriteLine("Exception Detached Child Task Method Completed");
        }

        public static async Task ExceptionAttachedChildTask()
        {
            Console.WriteLine("Exception Detached Child Task Method Started");
            try
            {
                var parentTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Parent Task Started");
                    var childTask = Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("Child Task Started");
                        int x = 10, y = 0;
                        int z = x / y;
                        Console.WriteLine("Child Task Completed");
                    }, TaskCreationOptions.AttachedToParent);
                    Console.WriteLine("Parent Task Completed");
                });
                await parentTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.WriteLine("Exception Detached Child Task Method Completed");
        }
    }
}
