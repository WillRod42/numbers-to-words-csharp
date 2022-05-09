using System;

namespace NumbersToWordsApp.Models
{
  public class NumberWithConversion
  {
    public int Number { get; }
    public string Word { get; }

    public NumberWithConversion(int number)
    {
      Number = number;
      Word = NumbersToWords.Convert(number.ToString());
    }
  }
}