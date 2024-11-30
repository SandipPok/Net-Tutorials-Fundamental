## MultiThreading

### ThreadPool

#### The Request Life cycle of a Thread in C# with Example

<img src="./images/ThreadLifeCycle.png" width="300" />

#### The Request Life cycle of a Thread Pool in C# with Example

<img src="./images/ThreadPoolCycle.png" width="300" />

#### <h3 style="color:red">Methods of `Thread Pool` Class in C#</h3>

## ThreadPool.QueueUserWorkItem(new WaitCallback(MyMethod))

- This method queues a task for execution by a thread pool worker thread.
- Runs asynchronously

## WaitCallback

- It is a delegate type used to represent a method that takes a single object parameter and return void.
- The **`WaitCallback`** delegate is required by `ThreadPool.QueueUserWorkItem` to specify the method that should be executed on the thread pool thread.

## MyMethod

- Custom method to execute.