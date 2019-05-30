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
                .Then(f => f.ShouldContainNumberOfTriggers(1))
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
                .Then(f => f.ShouldContainNumberOfTriggers(3))
                .BDDfy();
        }

        [TestMethod]
        public void GenerateEmptyBillingForNoTriggers()
        {
            new Feature()
                .When(f => f.CreateEmptyTriggerOrderWithCurrency(Currency.PLN))
                .Then(f => f.ShouldContainNumberOfTriggers(0))
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
