using System.ComponentModel.DataAnnotations;

namespace homework7
{

    //#1
    public class Me
    {
        // Backing fields
        private int age;
        private string pid;

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
            }
        }

        public string Pid
        {
            get
            {
                return pid;
            }
            set
            {
                if (value.Length == 11)
                {
                    pid = value;
                }
            }
        }

        public string Phone { get; set; }
        public string Email { get; set; }

        public Me(string name, string surname, int age, string pid, string phone, string email)
        {
            Firstname = name;
            Lastname = surname;
            Age = age;
            Pid = pid;
            Phone = phone;
            Email = email;
        }

        public void showInfo()
        {
            Console.WriteLine(this.Firstname + " " + this.Lastname + " " + this.Age + " " + this.Pid + " " + this.Phone + " " + this.Email);
        }
    }








    //#2
    public class Account
    {
        private string accnumber;
        private string currency;
        private double balance;
        public string Accnumber
        {
            get
            {
                return accnumber;
            }
            set
            {
                if (value.Length == 22)
                {
                    accnumber = value;
                }
            }
        }

        public string Currency
        {
            get
            {
                return currency;
            }

            set
            {
                if (value.Length == 3)
                {
                    currency = value;
                }
            }
        }

        public double Balance
        {
            get
            {
                return balance;
            }

            set
            {
                if (value >= 0)
                {
                    balance = value;
                }
            }
        }
    }



    public class Client
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        private string pid;
        public Account account {  get; set; }
        public string Pid
        {
            get
            {
                return pid;
            }
            set
            {
                if (value.Length == 11)
                {
                    pid = value;
                }
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > account.Balance)
            {
                Console.WriteLine($"{firstname} {lastname} does not have enough money. Balance is {account.Balance}{account.Currency}");
            }
            else
            {
                account.Balance -= amount;
                Console.WriteLine($"{firstname} {lastname} withdrawed {amount}{account.Currency}. Balance left: {account.Balance}{account.Currency}");
            }
        }


        public void showClientInfo()
        {
            Console.WriteLine($"Client: {this.firstname} {this.lastname}, PID: {this.Pid}, " +
                  $"Account Number: {this.account.Accnumber}, " +
                  $"Currency: {this.account.Currency}, Balance: {this.account.Balance}");

        }

        public void Deposit(double amount)
        {
            account.Balance+= amount;
            Console.WriteLine($"{firstname} {lastname} deposited {amount}{account.Currency}. Balance: {account.Balance}{account.Currency}");
        }

        public void transferMoney(double amount, Client receiver)
        {
            this.account.Balance -= amount;
            receiver.account.Balance += amount;

            Console.WriteLine($"{this.lastname} gave {amount}{this.account.Currency} to {receiver.lastname}. " +
                              $"{this.lastname} balance: {this.account.Balance}{this.account.Currency}. " +
                              $"{receiver.lastname} balance: {receiver.account.Balance}{receiver.account.Currency}");
        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Me myself = new Me("Luka", "Bitsadze", 20, "12312312312", "512321413", "bitsadzeluka@gmail.com");
            //myself.showInfo();


            Account messiAcc = new Account()
            {
                Accnumber = "1234567890123456789012", 
                Currency = "USD", 
                Balance = 7856.99 
            };




            Client messi = new Client()
            {
                firstname = "Lionel",
                lastname = "Messi",
                Pid = "12345678901",
                account = messiAcc
            };



            Account giorgiAcc = new Account()
            {
                Accnumber = "4739518463902516742989",
                Currency = "USD",
                Balance = 5433.61
            };




            Client chakve = new Client()
            {
                firstname = "Giorgi",
                lastname = "Chakvetadze",
                Pid = "12344321910",
                account = giorgiAcc
            };

            messi.showClientInfo();
            chakve.showClientInfo();

            //chakve.Withdraw(100);
            //messi.Withdraw(10000);
            //messi.Deposit(123);

            messi.transferMoney(5000.47, chakve);
        }
    }
    
}
