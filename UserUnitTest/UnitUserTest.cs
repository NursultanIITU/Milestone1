using System;
using Xunit;
using Milestone1.Services;
using Milestone1.Models;

namespace Milestone1.UserUnitTest
{
    public class UnitUserTest
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(15, 33, 48)]
        public void SumTest(int firstNumber, int secondNumber, int expectedResult)
        {
            var userService = new UserService();
           // var calService = new CalculatorService();
            var resultSum = userService.Sum(firstNumber, secondNumber);
            Assert.Equal(expectedResult, resultSum);
        }

        [Fact]
        public void AddUser()
        {
            var userService = new UserService();
           // var resultSum = userService.checkUser2(-9);
            Assert.Equal(true, userService.checkUser2(9));
        }
    
    }
}
