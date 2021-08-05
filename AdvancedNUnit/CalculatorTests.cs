using NUnit.Framework;
using System.Collections.Generic;

namespace AdvancedNUnit
{
    public class CalculatorTests
    {

        // [TestFixture] indicates a Test class



        [SetUp]
        public void Setup() { }

        [Test] // test attributes
        public void Add_Always_ReturnsExpectedResult()
        {
            // Arrange
            var expectedResult = 6;
            var subject = new Calculator { Num1 = 2, Num2 = 4 };
            // Act
            var result = subject.Add();
            // Assert
            Assert.That(result, Is.EqualTo(expectedResult), "optional failure message");
        }

        [Test]
        public void SomeConstraints() 
        {
            var subject = new Calculator { Num1 = 6 };
            Assert.That(subject.DivisibleBy3());

            subject.Num1 = 7;

            //Assert.That(subject.DivisibleBy3(), Is.False);
            Assert.That(subject.ToString(), Does.Contain("Calculator"));

        }

        [Test]
        public void StringConstraint() 
        {
            var subject = new Calculator { Num1 = 2, Num2 = 4 };
            var strResult = subject.ToString();

            Assert.That(strResult, Is.EqualTo("AdvancedNUnit.Calculator"));
            Assert.That(strResult, Does.Contain("Calculator"));
            Assert.That(strResult, Does.Not.Contain("Alex"));
            Assert.That(strResult, Is.EqualTo("advancedNUnit.Calculator").IgnoreCase);
            Assert.That(strResult, Is.Not.Empty);

        }

        
        [Test]
        public void TestArrayOfStrings() 
        {
            var fruit = new List<string> { "apple", "banana", "pear", "peach" };

            var Interpol = $"{fruit[0]}{fruit[1]}";
            var interpolCheck = $"{fruit[0]}{fruit[0]}";

            var Point0Check = fruit[0];

            Assert.That(Point0Check, Is.Not.EqualTo(fruit[1]));
            Assert.That(Point0Check, Is.EqualTo(fruit[0]));
            Assert.That(Interpol, Is.Not.EqualTo(interpolCheck));

            Assert.That(fruit, Does.Contain("pear"));
            Assert.That(fruit, Has.Count.EqualTo(4));
            Assert.That(fruit, Has.Exactly(2).StartsWith("pea"));

        }


        [Test]
        public void TestRange() 
        {
            Assert.That(8, Is.InRange(1, 10));
            List<int> nums = new List<int> { 4, 2, 7, 5, 9 };
            Assert.That(nums, Is.All.InRange(1, 10));
            Assert.That(nums, Has.Exactly(3).InRange(1, 5));

        }

        [TestFixture]
        public class Counter 
        {
            public int Count { get; private set; }
        }



    }
    

}