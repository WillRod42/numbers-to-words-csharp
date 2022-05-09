using System;
using System.Collections.Generic;

namespace NumbersToWordsApp.Models
{
  public class NumbersToWords
  {
    private static Dictionary<string, string> _firstDigits = new Dictionary<string, string>
    {
      {"1", "one"},
      {"2", "two"},
      {"3", "three"},
      {"4", "four"},
      {"5", "five"},
      {"6", "six"},
      {"7", "seven"},
      {"8", "eight"},
      {"9", "nine"},
    };

    private static Dictionary<string, string> _secondDigits = new Dictionary<string, string>
    {
      {"10", "ten"},
      {"20", "twenty"},
      {"30", "thirty"},
      {"40", "forty"},
      {"50", "fifty"},
      {"60", "sixty"},
      {"70", "seventy"},
      {"80", "eighty"},
      {"90", "ninety"},
    };

    private static Dictionary<string, string> _tens = new Dictionary<string, string>
    {
      {"1", "eleven"},
      {"2", "twelve"},
      {"3", "thirteen"},
      {"4", "fourteen"},
      {"5", "fifteen"},
      {"6", "sixteen"},
      {"7", "seventeen"},
      {"8", "eighteen"},
      {"9", "nineteen"}
    };

    private static string[] _prefixes = new string[] {"thousand", "million", "billion"};

    public static string Convert(string number)
    {
      if (number.Length < 4)
      {
        return ConvertThreeDigit(number);
      }
      else
      {
        int prefixIndex = GetPrefixIndex(number.Length);
        string numberAsWord = "";
        for (int i = 0; i < number.Length; i += 3)
        {
          string numberPart = "";
          if (i == 0 && number.Length % 3 != 0)
          {
            numberPart = number.Substring(0, number.Length % 3);
            i -= (3 - (number.Length % 3));
          }
          else
          {
            numberPart = number.Substring(i, 3);
          }

          numberAsWord += ConvertThreeDigit(numberPart) + " ";
          if (prefixIndex >= 0)
          {
            numberAsWord += _prefixes[prefixIndex] + " ";
          }
          
          prefixIndex--;
        }

        return numberAsWord.Trim();
      }

      // 43345123
      // [43] [345] [123]
      // [fourty three million] [three hundred forty five thousand] [one hundred twenty three]
      // 43 345 123
      // [fourty three] [three hundred forty five] [one hundred twenty three]
    }

    private static int GetPrefixIndex(int numberLength)
    {
      switch (numberLength)
      {
        case <= 6: return 0;
        case <= 9: return 1;
        case <= 12: return 2;
        default: return -1;
      }
    }

    private static string ConvertThreeDigit(string number)
    {
      if(number == "0")
      {
        return "Zero";
      }
      else
      {
        string numberAsWords = "";
        bool exception = (number.Length > 1) && (int.Parse(number[number.Length - 2].ToString()) == 1);
        int multiplyOf = (int)Math.Pow(10, (number.Length - 1));
        for(int index = 0; index < number.Length; index++)
        {
          string currentNum = (int.Parse((number[index]).ToString()) * multiplyOf).ToString();
          if (currentNum != "0")
          {
            if (currentNum.Length == 1 && !exception)
            {
              numberAsWords += _firstDigits[currentNum];
            }
            else if (currentNum.Length == 2 && exception)
            {
              numberAsWords += _tens[(number[number.Length - 1]).ToString()];
            }
            else if (currentNum.Length == 2)
            {
              numberAsWords += _secondDigits[currentNum] + " ";
            }
            else if (currentNum.Length == 3)
            {
              numberAsWords += _firstDigits[(currentNum[0]).ToString()] + " hundred ";
            }
          }

          multiplyOf /= 10;
        }

        return numberAsWords.Trim();
      }
    }
  }
}



// one +fourty 
// Expected:<twenty one>. Actual:<ten two>.
// 12
// number[0]