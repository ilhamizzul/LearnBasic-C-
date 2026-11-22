using LearningBasic.Labs.Infrastructure;

namespace LearningBasic.Labs.Lab02_Oop;

public class Lab02 : ILab
{
    public int Number => 2;
    public string Title => "OOP and SOLID";

    public void Run()
    {
        Check.Throws<ArgumentException>("2.1 Amount 0 is rejected", () => new BankTransfer(0));
        Check.Throws<ArgumentException>("2.1 Negative amount is rejected", () => new CreditCard(-5));

        Check.Equal("2.2 BankTransfer total", 106_500m, () => new BankTransfer(100_000).Total());
        Check.Equal("2.3 CreditCard fee", 3_000m, () => new CreditCard(100_000).Fee());
        Check.Equal("2.4 EWallet fee uses the 1,000 minimum", 1_000m, () => new EWallet(50_000).Fee());
        Check.Equal("2.4 EWallet fee is 1% above the minimum", 2_000m, () => new EWallet(200_000).Fee());

        Check.True("2.5 Factory: \"CARD\" makes a CreditCard", () => PaymentFactory.Create("CARD", 10_000) is CreditCard);
        Check.True("2.5 Factory: \"ewallet\" makes an EWallet", () => PaymentFactory.Create("ewallet", 10_000) is EWallet);
        Check.Throws<ArgumentException>("2.5 Factory: unknown type", () => PaymentFactory.Create("cash", 10_000));

        Check.Equal("2.x Polymorphism: total of mixed payments", 310_500m, () =>
        {
            List<Payment> payments = [new BankTransfer(100_000), new CreditCard(100_000), new EWallet(100_000)];
            return payments.Sum(p => p.Total());
        });

        var classic = new RuleBasedFizzBuzz([new DivisibleRule(3, "Fizz"), new DivisibleRule(5, "Buzz")]);
        Check.True("2.6 DivisibleRule(3) matches 9", () => new DivisibleRule(3, "Fizz").Matches(9));
        Check.Equal("2.7 Say(7)", "7", () => classic.Say(7));
        Check.Equal("2.7 Say(9)", "Fizz", () => classic.Say(9));
        Check.Equal("2.7 Say(15)", "FizzBuzz", () => classic.Say(15));

        var extended = new RuleBasedFizzBuzz([
            new DivisibleRule(3, "Fizz"), new DivisibleRule(5, "Buzz"), new DivisibleRule(7, "Bazz")]);
        Check.Equal("2.7 New rule, no code change: Say(21)", "FizzBazz", () => extended.Say(21));
        Check.Equal("2.7 New rule, no code change: Say(105)", "FizzBuzzBazz", () => extended.Say(105));
    }
}