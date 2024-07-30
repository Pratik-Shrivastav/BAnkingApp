using System;
using System.Collections.Generic;

namespace BAnkingApp
{
    public class Program
    {
        public static void BankingOptions(int option, Account account)
        {
            if (option == 1)
            {
                Console.WriteLine("Enter the amount to be deposited");
                double depositedAmount = double.Parse(Console.ReadLine());
                Console.WriteLine("The Current Balance after Deposite is" + Account.Deposite(account, depositedAmount));
            }
            if (option == 2)
            {
                Console.WriteLine("Enter the amount to be withdrawn");
                double withdrawnAmount = double.Parse(Console.ReadLine());
                double balanceAfterWithdrawal = Account.Withdraw(account, withdrawnAmount);
                if (balanceAfterWithdrawal == -1)
                {
                    Console.WriteLine("You have ensuffient balance to maintain Minimum Balance after this Withdrawal");
                }
                else
                {
                    Console.WriteLine("The Current Balance after Withdrawal is" + balanceAfterWithdrawal);
                }
            }
            if (option == 3)
            {
                PrintAccountDetails(account);
            }
        }
        public static void PrintAccountDetails(Account account)
        {
            int accountId;
            string accountName;
            string accountBankName;
            double accountBalance;
            Account.PrintDetailsOut(account, out accountId, out accountName, out accountBankName, out accountBalance);
            Console.WriteLine($"The account number is:{ accountId}" +
                $"\nThe account name is: {accountName}" +
                $"\nThe account Bank Name is: {accountBankName}" +
                $"\nThe account Balance is: {accountBalance}");
        }
        public static void BankingOptionsSelection(Account account)
        {
            int userInput = 1;
            while (userInput != 0)
            {
                Console.WriteLine("Enter the Option Number to select an option");
                Console.WriteLine("1. Deposite");
                Console.WriteLine("2. Withdrawal");
                Console.WriteLine("3. Check details");
                Console.WriteLine("0. Exit");
                userInput = int.Parse(Console.ReadLine());
                if (userInput == 0)
                {
                    break; 
                }
                BankingOptions(userInput, account);
            }
            
        }
        
        public static List<Account> BeginBanking(List<Account> accounts) 
        {
            int userAccountInput=-1;
            while (userAccountInput != 0)
            {
                Console.WriteLine("Enter the account number to perform functions" +
                    "\nEnter 0 to exit");
                userAccountInput = int.Parse(Console.ReadLine());
                foreach (Account account in accounts)
                {
                  if (account.accountId == userAccountInput)
                    {  
                        BankingOptionsSelection(account);
                    }
                }
            }
            return accounts;
        }
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            Account account1 = new Account(1, "Pratik", "SBI", 2000);
            Account account2 = new Account(2, "Ravi", "HDFC");
            Account account3 = new Account(3, "Suresh", "ICICI", 400000);
            Account account4 = new Account(4, "Tarun", "UBI", 600);

            accounts.Add(account1);accounts.Add(account2);accounts.Add(account3);accounts.Add(account4);
            accounts = SerialDeserial.DesrializeData();
            accounts= BeginBanking(accounts);
            SerialDeserial.SerializeData(accounts);
        }
    }
}

