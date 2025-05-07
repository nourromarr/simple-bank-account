using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking__account
{
    internal class Program
    {
        public class bank
        {
            public string name { get; private set; }
            public int account_num { get; private set; }
            public double balance { get; private set; }

            public bank(string name, int account_num, double balance)
            {
                this.name = name;
                this.account_num = account_num;
                this.balance = balance;
            }
            public void deposit(double amount)
            {
                balance+=amount;
            }
            public bool withdraw(double amount)
            {
                if (balance == 0 || balance < amount)
                {
                    return false;
                }
                else
                {
                    balance -=amount;
                    return true;

                }

            }


            
        }


        static void Main(string[] args)
        {
            Dictionary<int, bank> accounts = new Dictionary<int, bank>();
            bool keep_run = true;

            while (keep_run)
            {
                Console.WriteLine("welcome to the bank account ");
                Console.WriteLine("select options : ");
                Console.WriteLine("1- create account ");
                Console.WriteLine("2-deposit");
                Console.WriteLine("3-withdraw");
                Console.WriteLine("4-check balance");
                Console.WriteLine("5-exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        create_account();
                        break;
                    case "2":
                        deposit();
                        break;
                    case "3":
                        withdraw();
                        break;
                    case "4":
                        checkbalance();
                        break;
                    case "5":
                        keep_run = false;
                        Console.WriteLine("than you for using the bank system account");
                        break;
                    default:
                        Console.WriteLine("invalid option please try again");
                        break;






                }
            }
             void create_account()
            {
                Console.WriteLine("enter your name ");
                string name = Console.ReadLine();
                Console.WriteLine("please enter an intial deposite account ");
                double initial_deposite = getvalidamount();
                int accountNumber = accounts.Count + 1;
                accounts[accountNumber] = new bank(name, accountNumber, initial_deposite);
                Console.WriteLine($"account created successfully! your account number is :{accountNumber}");

            }
             void deposit()
            {

                Console.WriteLine("enter your account number");

                int accountNumber = getValidaccount();
                Console.WriteLine("your amount of the money is equal to =");
                double amount = getvalidamount();
                accounts[accountNumber].deposit(amount);
                Console.WriteLine($"deposit is successfully done : {accounts[accountNumber].balance}");
            }
             void withdraw()
            {
                

                int accountNumber = getValidaccount();
                Console.WriteLine("enter your account number ");

                Console.WriteLine("please enter the amount you want to withdraw");
                double amount = getvalidamount();
                if (accounts[accountNumber].withdraw(amount))
                {
                    Console.WriteLine($"withdrawl is succefully done , new balance is : {accounts[accountNumber].balance}");

                }
                else
                {
                    Console.WriteLine("the amount that you enter is not valid ");
                }

            }
             void checkbalance()
            {
                Console.WriteLine("enter your account number : ");
                int accountNumber = getValidaccount();
                Console.WriteLine($"account holder is : {accounts[accountNumber].account_num}");
                Console.WriteLine($"account balance is : {accounts[accountNumber].balance}");


            }
             int getValidaccount()
            {
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int accountNumber) && accounts.ContainsKey(accountNumber))
                    {
                        return accountNumber;
                    }
                    else
                    {
                        Console.WriteLine("invalid account number, please try again :");
                    }

                }

            }
             double getvalidamount()
            {
                while (true)
                {
                    if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
                    {
                        return amount;
                    }
                    else
                    {
                        Console.WriteLine("invalid amount please enter valid amount ");
                    }
                }
            }
        }








    }
}
    

    

