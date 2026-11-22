using System;
using System.Collections.Generic;
using System.Text;

namespace LearningBasic.Labs.Lab02_Oop;

// ---------- Part A: payments ----------
public abstract class Payment
{
    public decimal Amount { get; }

    protected Payment(decimal Amount)
    {
        if(Amount <= 0) throw new ArgumentException("Amount must be greater than zero.", nameof(Amount));
        this.Amount = Amount;
    }

    public abstract decimal Fee();
    public decimal Total() => Amount + Fee();
}

public class BankTransfer(decimal amount) : Payment(amount)
{
    public override decimal Fee()
    {
        return 6_500m;
    }
}

public class CreditCard(decimal amount) : Payment(amount)
{
    public override decimal Fee()
    {
        return Amount * 0.03m;
    }
}

public class EWallet(decimal amount): Payment(amount)
{
    public override decimal Fee()
    {
        decimal fee = Amount * 0.01m;
        if (fee < 1000m) return 1000m;
        return fee;
    }
}

public static class PaymentFactory
{
    public static Payment Create(string type, decimal amount)
    {
        return type.ToLower() switch
        {
            "banktransfer" => new BankTransfer(amount),
            "card" => new CreditCard(amount),
            "ewallet" => new EWallet(amount),
            _ => throw new ArgumentException("Invalid payment type.", nameof(type))
        };
    }
}

// ---------- Part B: FizzBuzz yang bisa ditambah tanpa diedit ----------
public interface IRule
{
    bool Matches(int n);
    string Word { get; }
}

public class DivisibleRule(int advisor, string word) : IRule
{
    public string Word { get; } = word;

    public bool Matches(int n)
    {
        if (n % advisor == 0) return true;
        return false;
    }
}

public class RuleBasedFizzBuzz(IEnumerable<IRule> rules)
{
    // TODO 2.7: gabungkan Word dari semua rule yang cocok, sesuai urutan;
    //           kalau tidak ada yang cocok -> angkanya sebagai text
    public string Say(int n) {
        string result = "";
        foreach (var rule in rules)
        {
            if(rule.Matches(n)) result += rule.Word;
        }
        if (result == "") return n.ToString();
        return result;
    }
}