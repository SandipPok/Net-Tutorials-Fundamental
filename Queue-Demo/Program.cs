using System.Collections;

namespace QueueDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating Queue
            Queue queue = EnqueDemo();

            // Dequeue
            DequeueDemo(ref queue);

            // PeekDemo
            PeekDemo(ref queue);

            // Clone Demo
            CloneDemo(ref queue);

            // CopyTo Demo
            CopyToDemo(ref queue);

            // Clear demo
            ClearDemo(ref queue);

            Console.ReadKey();
        }

        static Queue EnqueDemo()
        {
            Queue queue1 = new Queue();
            queue1.Enqueue(1);
            queue1.Enqueue("Hello World");
            queue1.Enqueue(null);
            queue1.Enqueue(4.1);
            queue1.Enqueue(1f);

            Console.WriteLine($"Total number of items in queue: {queue1.Count}");

            return queue1;
        }

        static void DequeueDemo(ref Queue queue)
        {
            Console.WriteLine("\nRemove item with dequeue is {0} and total items are {1}", queue.Dequeue(), queue.Count);
        }

        static void PeekDemo(ref Queue queue)
        {
            Console.WriteLine("\nFirst item in queue is {0} and total items are {1}", queue.Peek(), queue.Count);
        }

        static void CloneDemo(ref Queue queue)
        {
            Queue queueCopy = (Queue)queue.Clone();

            Console.WriteLine("\nDisplaying items of copied queue");
            foreach (object item in queueCopy)
            {
                Console.Write(item + "\t");
            }
        }

        static void CopyToDemo(ref Queue queue)
        {
            object[] array = new object[queue.Count];

            queue.CopyTo(array, 0);

            Console.WriteLine("\n\nCopying items of queue to array");
            foreach (object item in array)
            {
                Console.Write(item + "\t");
            }
        }

        static void ClearDemo(ref Queue queue)
        {
            queue.Clear();
            Console.WriteLine($"\n\nTotal items in queue after clear is used is {queue.Count}");
        }
    }
}