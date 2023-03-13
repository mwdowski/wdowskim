using Code;
using FluentAssertions;

namespace Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Calculate_EmptyString()
        {
            var calc = new StringCalculator();
            calc.Calculate("").Should().Be(0);
        }

        [Fact]
        public void Calculate_SingleNumber()
        {
            var calc = new StringCalculator();

            calc.Calculate("22").Should().Be(22);
            calc.Calculate("0").Should().Be(0);
        }

        [Fact]
        public void Calculate_ComaDelimeteredPair()
        {
            var calc = new StringCalculator();

            calc.Calculate("21,1").Should().Be(22);
            calc.Calculate("1,7").Should().Be(8);
        }

        [Fact]
        public void Calculate_NewlineDelimeteredPair()
        {
            var calc = new StringCalculator();

            calc.Calculate("21\n1").Should().Be(22);
            calc.Calculate("21\n7").Should().Be(28);
        }

        [Fact]
        public void Calculate_DelimeteredTriplet()
        {
            var calc = new StringCalculator();

            calc.Calculate("1\n1\n1").Should().Be(3);
            calc.Calculate("1,1\n1").Should().Be(3);
            calc.Calculate("1\n1,1").Should().Be(3);
            calc.Calculate("1,1,1").Should().Be(3);
        }

        [Fact]
        public void Calculate_NegativeNumbersThrowException()
        {
            var calc = new StringCalculator();

            var call = () => calc.Calculate("1\n-1\n1");
            call.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Calculate_Over1000NumbersAreIgnored()
        {
            var calc = new StringCalculator();

            calc.Calculate("1\n2137\n1").Should().Be(2);
        }

        [Fact]
        public void Calculate_WithAdditionalDelimeter()
        {
            var calc = new StringCalculator();

            calc.Calculate("//#\n1\n2#1").Should().Be(4);
        }
    }
}