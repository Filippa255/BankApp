using System.Xml.Serialization;

public class BankAccount
{
    public string Owner { get; set; }
    public decimal Balance { get; set; }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if(amount <= Balance)
            Balance -= amount;
    }
    
}


