using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Night1.Test
{
    [TestClass]
    public class ProgramTest
    {
        [DataTestMethod]
        [DataRow(new int[] { 2016, 5, 4, 3, 2, 1 }, 6048)]
        [DataRow(new int[] { 5, 5, 2016, 3, 2, 1 }, 6048)]
        public void Verify_Get_Product(int[] input, int expectedProduct)
        {
            Program.GetProduct(input).Should().Be(expectedProduct);
        }

        [DataTestMethod]
        [DataRow(2019, new int[] { 2016, 3, 1 }, 1)]
        public void Verify_Compare(int comparisonSum, int[] comparisonGroup, int finalNumber)
        {
            Program.Compare(comparisonSum, comparisonGroup, out finalNumber).Should().Be(true);
            finalNumber.Should().Be(1);
        }

        [DataTestMethod]
        [DataRow(new int[] { 2019, 1 })]
        [DataRow(new int[] { 1570, 450 })]
        [DataRow(new int[] { 1, 1, 2018 })]
        [DataRow(new int[] { 118, 54, 1848 })]
        public void Verify_Sum_Is_2020(int[] numbers)
        {
            Program.SumIs2020(numbers).Should().BeTrue();
        }
    }
}
