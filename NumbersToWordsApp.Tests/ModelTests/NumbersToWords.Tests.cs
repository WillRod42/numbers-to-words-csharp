using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersToWordsApp.Models;
using System;
using System.Collections.Generic;

namespace NumbersToWordsApp.Tests
{
  [TestClass]
  public class NumbersToWordsTests
  {
    [TestMethod]
    public void Convert_ConvertsFirstDigitToWord_One() {
      Assert.AreEqual("one", NumbersToWords.Convert("1"));
    }

    [TestMethod]
    public void Convert_ConvertsTwoDigitsToWord_TwentyOne() {
      Assert.AreEqual("twenty one", NumbersToWords.Convert("21"));
    }

    [TestMethod]
    public void Convert_ConvertsTwoDigitsToWord_Twelve() {
      Assert.AreEqual("twelve", NumbersToWords.Convert("12"));
    }

    [TestMethod]
    public void Convert_ConvertsThreeDigitsToWord_OneHundred() {
      Assert.AreEqual("one hundred", NumbersToWords.Convert("100"));
    }

    [TestMethod]
    public void Convert_ConvertsThreeDigitsToWord_OneHundredTwo() {
      Assert.AreEqual("one hundred two", NumbersToWords.Convert("102"));
    }

    [TestMethod]
    public void Convert_ConvertsThreeDigitsToWord_OneHundredThirteen() {
      Assert.AreEqual("one hundred thirteen", NumbersToWords.Convert("113"));
    }

    [TestMethod]
    public void Convert_ConvertsThreeDigitsToWord_OneHundredFiftySix() {
      Assert.AreEqual("one hundred fifty six", NumbersToWords.Convert("156"));
    }

    [TestMethod]
    public void Convert_ConvertsThreeDigitsToWord_OneThousandOneHundredFiftySix() {
      Assert.AreEqual("one thousand one hundred fifty six", NumbersToWords.Convert("1156"));
    }

    [TestMethod]
    public void Convert_ConvertsThreeDigitsToWord_FourMillionTwoThousandOneHundredFiftySix() {
      Assert.AreEqual("four million two thousand one hundred fifty six", NumbersToWords.Convert("4002156"));
    }

    [TestMethod]
    public void Convert_ConvertsThreeDigitsToWord_BigNumber() {
      Assert.AreEqual("thirty four billion one hundred four million two thousand one hundred fifty six", NumbersToWords.Convert("34104002156"));
    }
  }
}
