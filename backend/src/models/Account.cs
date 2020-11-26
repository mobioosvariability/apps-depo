using System;
namespace BankWeb.models
{
  public class Account
  {
    public long Id { get; }
    public double Balance { get; set; }
    public string Currency { get; set; }
    private readonly int LIMIT = 1000;

    public Account(long id, double initial)
    {
      this.Id = id;
      this.Balance = initial;
      this.Currency = "Euro";
    }

    public double Deposit(double amount)
    {
      this.Balance += amount;
      return this.Balance;
    }

    public double Withdraw(double amount)
    {

      if (this.Balance - amount >= this.LIMIT && amount > 0)
      {
        this.Balance -= amount;
      }

      return this.Balance;
    }


    public void DislayInfo()
    {
      Console.WriteLine(" Account ID :" + this.Id);
      Console.WriteLine(" Account Balance :" + this.Balance);
      Console.WriteLine(" Account Currency :" + this.Currency);
      Console.WriteLine(" Account Limit :" + this.LIMIT);



    }
  }
}