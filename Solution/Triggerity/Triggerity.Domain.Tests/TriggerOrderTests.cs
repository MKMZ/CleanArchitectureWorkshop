using Bogus;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestStack.BDDfy;
using Triggerity.Domain.Exceptions;

namespace Triggerity.Domain.Tests
{
    [TestClass]
    public class TriggerOrderTests
    {
        [TestMethod]
        public void GenerateCorrectBillingForSingleTrigger()
        {
            new Feature()
                .Given(f => f.CreateEmptyTriggerOrderWithCurrency(Currency.PLN))
                .When(f => f.AddTriggerWithMoney(new Money(20, Currency.PLN)))
                .Then(f => f.ShouldGenerateBillingWithMoney(new Money(20, Currency.PLN)))
                    .And(f => f.ShouldContainNumberOfTriggers(1))
                .BDDfy();
        }

        [TestMethod]
        public void GenerateCorrectBillingForMultipleTriggers()
        {
            new Feature()
                .Given(f => f.CreateEmptyTriggerOrderWithCurrency(Currency.PLN))
                .When(f => f.AddTriggerWithMoney(new Money(20, Currency.PLN)))
                    .And(f => f.AddTriggerWithMoney(new Money(50, Currency.PLN)))
                    .And(f => f.AddTriggerWithMoney(new Money(10, Currency.PLN)))
                .Then(f => f.ShouldGenerateBillingWithMoney(new Money(80, Currency.PLN)))
                    .And(f => f.ShouldContainNumberOfTriggers(3))
                .BDDfy();
        }

        [TestMethod]
        public void GenerateEmptyBillingForNoTriggers()
        {
            new Feature()
                .When(f => f.CreateEmptyTriggerOrderWithCurrency(Currency.PLN))
                .Then(f => f.ShouldGenerateBillingWithMoney(new Money(0, Currency.PLN)))
                    .And(f => f.ShouldContainNumberOfTriggers(0))
                .BDDfy();
        }

        [TestMethod]
        public void TriggerWithWrongCurrencyIsNotAccepted()
        {
            new Feature()
                .Given(f => f.CreateEmptyTriggerOrderWithCurrency(Currency.PLN))
                    .And(f => f.AddTriggerWithMoney(new Money(20, Currency.PLN)))
                .When(f => f.TryAddTriggerWithMoneyUnsuccessfully(new Money(10, Currency.EUR)))
                .Then(f => f.ShouldGenerateBillingWithMoney(new Money(20, Currency.PLN)))
                    .And(f => f.ShouldContainNumberOfTriggers(1))
                .BDDfy();
        }

        private class Feature
        {
            private readonly static Faker faker = new Faker();
            private readonly IList<Trigger> triggers;
            private TriggerOrder triggerOrder;

            internal Feature()
            {
                triggers = new List<Trigger>();
            }

            internal void CreateEmptyTriggerOrderWithCurrency(Currency currency)
            {
                triggerOrder = new TriggerOrder(faker.Lorem.Sentence(5), new CompanyIdentifier(Guid.NewGuid()), currency);
            }

            internal void AddTriggerWithMoney(Money money)
            {
                var trigger = PrepareTriggerWithMoney(money);

                triggerOrder.AddTrigger(trigger);
                triggers.Add(trigger);
            }

            internal void TryAddTriggerWithMoneyUnsuccessfully(Money money)
            {
                var trigger = PrepareTriggerWithMoney(money);

                Action action = () => triggerOrder.AddTrigger(trigger);
                action.Should().Throw<DomainException>().WithMessage("Currencies must be equal to perform operation");
            }

            internal void ShouldGenerateBillingWithMoney(Money money)
            {
                triggerOrder.Billing.Money.Should().BeEquivalentTo(money);
            }

            internal void ShouldContainNumberOfTriggers(int count)
            {
                triggerOrder.Triggers.Should().HaveCount(count);
            }

            private Trigger PrepareTriggerWithMoney(Money money) =>
                new Trigger.Builder
                {
                    Description = faker.Lorem.Sentence(5),
                    Giver = new PersonIdentifier(Guid.NewGuid()),
                    Receiver = new PersonIdentifier(Guid.NewGuid()),
                    Money = money,
                    MoneyType = faker.PickRandom<TreasuryMoneyType>()
                }.ToImmutable();
        }
    }
}
