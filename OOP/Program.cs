using System;
using System.Security.Principal;

namespace OOP {
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Hello OOP");

            var accountNhat = new BankAcount("Do Van Nhat", 1000000000);
            //var accountNhat2 = new BankAcount("Do Van Nhat", 10000000000000000);

            accountNhat.MakeDeposit(50000000, DateTime.Now, "Luong ve");
            accountNhat.MakeWithdrawal(10000000, DateTime.Now, "Mua dt");

            //accountNhat.ShowInfor();
            //accountNhat.ShowAllTranssaction();
            // Test that the initial balances must be positive.


            // Test for a negative balance.
            //try
            //{
            //    accountNhat.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            //}
            //catch (InvalidOperationException e)
            //{
            //    Console.WriteLine("Exception caught trying to overdraw");
            //    Console.WriteLine(e.ToString());
            //}

            //accountNhat.MakeWithdrawal(10000000, DateTime.Now, "Mua Xbox ");
            //Console.WriteLine(accountNhat.ShowAllTranssaction());

            //try
            //{
            //  var  invalidAccount = new BankAcount("invalid", -55);
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine("Exception caught creating account with negative balance");
            //    Console.WriteLine(e.ToString());
            //    return;
            //}

          
            accountNhat.ShowInfor();
            Console.WriteLine(accountNhat.ShowAllTranssaction());
        }
    }

}