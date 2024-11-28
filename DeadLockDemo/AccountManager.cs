namespace DeadLockDemo
{
    //public class AccountManager
    //{
    //    private Account FromAccount;
    //    private Account ToAccount;
    //    private double TransferAmount;
    //    public AccountManager(Account AccountFrom, Account AccountTo, double AmountTransfer)
    //    {
    //        FromAccount = AccountFrom;
    //        ToAccount = AccountTo;
    //        TransferAmount = AmountTransfer;
    //    }
    //    public void FundTransfer()
    //    {
    //        Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire lock on {FromAccount.ID}");
    //        lock (FromAccount)
    //        {
    //            Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {FromAccount.ID}");
    //            Console.WriteLine($"{Thread.CurrentThread.Name} Doing Some work");
    //            Thread.Sleep(3000);
    //            Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire lock on {ToAccount.ID}");
    //            //lock (ToAccount)
    //            //{
    //            //    FromAccount.WithdrawMoney(TransferAmount);
    //            //    ToAccount.DepositMoney(TransferAmount);
    //            //}

    //            if (Monitor.TryEnter(ToAccount, 3000))
    //            {
    //                Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {ToAccount.ID}");
    //                try
    //                {
    //                    FromAccount.WithdrawMoney(TransferAmount);
    //                    ToAccount.DepositMoney(TransferAmount);
    //                }
    //                finally
    //                {
    //                    Monitor.Exit(ToAccount);
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine($"{Thread.CurrentThread.Name} Unable to acquire lock on {ToAccount.ID}, So existing.");
    //            }
    //        }
    //    }
    //}

    public class AccountManager
    {
        private Account FromAccount;
        private Account ToAccount;
        private readonly double TransferAmount;
        public AccountManager(Account AccountFrom, Account AccountTo, double AmountTransfer)
        {
            this.FromAccount = AccountFrom;
            this.ToAccount = AccountTo;
            this.TransferAmount = AmountTransfer;
        }
        public void FundTransfer()
        {
            object _lock1, _lock2;
            if (FromAccount.ID < ToAccount.ID)
            {
                _lock1 = FromAccount;
                _lock2 = ToAccount;
            }
            else
            {
                _lock1 = ToAccount;
                _lock2 = FromAccount;
            }
            Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire lock on {((Account)_lock1).ID}");

            lock (_lock1)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {((Account)_lock1).ID}");
                Console.WriteLine($"{Thread.CurrentThread.Name} Doing Some work");
                Thread.Sleep(3000);
                Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire lock on {((Account)_lock2).ID}");
                lock (_lock2)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {((Account)_lock2).ID}");
                    FromAccount.WithdrawMoney(TransferAmount);
                    ToAccount.DepositMoney(TransferAmount);
                }
            }
        }
    }
}
