/*namespace CustomEventDelegateDemo
{
    //Step1: Define one delegate
    public delegate void WorkPerformedHandler(int hours, WorkType workType);

    public class Worker
    {
        //Step2: Define one event to notify the work progress using the custom delegate
        public event WorkPerformedHandler WorkPerformed;
        //Step2: Define another event to notify when the work is completed using buil-in EventHandler delegate
        public event EventHandler WorkCompleted;
        public void DoWork(int hours, WorkType workType)
        {
            //Do Work here and notify the consumer that work has been performed
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i + 1, workType);
                Thread.Sleep(3000);
            }
            //Notify the consumer that work has been completed
            OnWorkCompleted();
        }
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //Raising Events only if Listeners are attached

            //Approach1
            //if(WorkPerformed != null)
            //{
            //    WorkPerformed(8, WorkType.GenerateReports);
            //}

            //Approach2
            //WorkPerformed?.Invoke(8, WorkType.GenerateReports);

            //Approach3
            //WorkPerformedHandler del1 = WorkPerformed as WorkPerformedHandler;
            //if(del1 != null)
            //{
            //    del1(8, WorkType.GenerateReports);
            //}

            //Approach4
            if (WorkPerformed is WorkPerformedHandler del2)
            {
                del2(8, WorkType.GenerateReports);
            }
        }
        protected virtual void OnWorkCompleted()
        {
            //Raising the Event
            
            //Approach1
            //EventHandler delegate takes two parameters i.e. object sender, EventArgs e
            //Sender is the current class i.e. this keyword and we do not need to pass any data
            //So, we need to pass Empty EventArgs
            //WorkCompleted?.Invoke(this, EventArgs.Empty);
            
            //Approach2
            if (WorkCompleted is EventHandler del)
            {
                del(this, EventArgs.Empty);
            }
            //Note: You can also use other two Approached
        }
    }

    public enum WorkType
    {
        Golf,
        GotoMeetings,
        GenerateReports
    }
}*/


using System;
using System.Threading;

namespace CustomEventDelegateDemo
{
    //Step1: Define one delegate
    //Custom Delegate
    //public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

    public class Worker
    {
        //Step2: Define one event to notify the work progress using the custom delegate
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;

        //Step2: Define another event to notify when the work is completed using buil-in EventHandler delegate
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            //Do Work here and notify the consumer that work has been performed
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i + 1, workType);
                Thread.Sleep(3000);
            }

            //Notify the consumer that work has been completed
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //Raising Events only if Listeners are attached

            //Approach1

            if (WorkPerformed != null)
            {
                WorkPerformedEventArgs e = new WorkPerformedEventArgs()
                {
                    Hours = hours,
                    WorkType = workType
                };
                WorkPerformed(this, e);
            }

            //Approach2
            //EventHandler<WorkPerformedEventArgs> del1 = WorkPerformed as EventHandler<WorkPerformedEventArgs;
            //if (del1 != null)
            //{
            //    WorkPerformedEventArgs e = new WorkPerformedEventArgs()
            //    {
            //        Hours = hours,
            //        WorkType = workType
            //    };
            //    del1(this, e);
            //}

            //Approach3
            //if (WorkPerformed is EventHandler<WorkPerformedEventArgs> del2)
            //{
            //    WorkPerformedEventArgs e = new WorkPerformedEventArgs()
            //    {
            //        Hours = hours,
            //        WorkType = workType
            //    };
            //    del2(this, e);
            //}
        }

        protected virtual void OnWorkCompleted()
        {
            //Raising the Event
            //Approach1
            //EventHandler delegate takes two parameters i.e. object sender, EventArgs e
            //Sender is the current class i.e. this keyword and we do not need to pass any data
            //So, we need to pass Empty EventArgs
            //WorkCompleted?.Invoke(this, EventArgs.Empty);

            //Approach2
            if (WorkCompleted is EventHandler del)
            {
                del(this, EventArgs.Empty);
            }

            //Note: You can also use other two Approaches
        }
    }

    public enum WorkType
    {
        Golf,
        GotoMeetings,
        GenerateReports
    }
}