using NFluent;
using Xunit;

namespace Day1
{
    public class CalibrationCalculatorTest
    {
        [Fact]
        public void String_Of_Letters_Returns_Zero()
        {
            Check.That(GetCalibration("e")).IsEqualTo(0);
        }

        [Fact]
        public void String_Of_One_Digit_Returns_The_Digit_Two_Times()
        {
            Check.That(GetCalibration("3")).IsEqualTo(33);
        }

        [Fact]
        public void String_Of_Two_Digits_Returns_The_Two_Digits()
        {
            Check.That(GetCalibration("32")).IsEqualTo(32);
        }

        [Fact]
        public void String_Of_One_Letter_And_One_Digit_Returns_The_Digit_Two_Times()
        {
            Check.That(GetCalibration("a3")).IsEqualTo(33);
        }

        [Fact]
        public void String_of_Two_Digits_Separated_With_Letters_Returns_The_Two_Digits()
        {
            Check.That(GetCalibration("3pm2")).IsEqualTo(32);
        }

        [Fact]
        public void String_Of_Three_Digits_Returns_The_first_and_Last_Digit()
        {
            Check.That(GetCalibration("123")).IsEqualTo(13);
        }

        [Fact]
        public void String_Of_Two_Lines_Returns_The_Sum_Of_Values_For_Each_Lines()
        {
            Check.That(GetCalibration("a3pm2e\r\nbe2ye5ml")).IsEqualTo(32+25);
        }

        [Fact]
        public void First_Example_Returns_142()
        {
            Check.That(GetCalibration("1abc2\r\npqr3stu8vwx\r\na1b2c3d4e5f\r\ntreb7uchet")).IsEqualTo(142);
        }

        [Fact]
        public void String_Of_Digits_spelled_In_Letters_Returns_The_First_and_Last_Corresponding_Digits()
        {
            Check.That(GetCalibration("two1nine")).IsEqualTo(29);
        }

        [Fact]
        public void Second_Example_Returns_281()
        {
            Check.That(GetCalibration("two1nine\r\neightwothree\r\nabcone2threexyz\r\nxtwone3four\r\n4nineeightseven2\r\nzoneight234\r\n7pqrstsixteen")).IsEqualTo(281);
        }
     
        private int GetCalibration(string input)
        {
            return new CalibrationCalculator().GetSumOfCalibration(input);
        }
    }
}
