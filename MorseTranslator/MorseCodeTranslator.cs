using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morse.MorseTranslator
{
    public class MorseCodeTranslator
    {
        private Dictionary<char, string>? engToMorse;
        private Dictionary<string, char>? morseToEng;
        private void EngToMorseCodeAlphabet()
        {
            engToMorse = new Dictionary<char, string>
            {
                { 'A', ".-"},
                { 'B', "-..."},
                { 'C',"-.-."},
                { 'D',"-.."},
                { 'E',"."},
                { 'F',"..-."},
                { 'G',"--."},
                { 'H',"...."},
                { 'I',".."},
                { 'J',".---"},
                { 'K',"-.-"},
                { 'L',".-.."},
                { 'M',"--"},
                { 'N',"-."},
                { 'O',"---"},
                { 'P',".--."},
                { 'Q',"--.-"},
                { 'R',".-."},
                { 'S',"..."},
                { 'T',"-"},
                { 'U',"..-"},
                { 'V',"...-"},
                { 'W',".--"},
                { 'X',"-..-"},
                { 'Y',"-.--"},
                { 'Z',"--.."},
                { ' '," "},
                { '1',".----"},
                { '2',"..---"},
                { '3',"...--"},
                { '4',"....-"},
                { '5',"....."},
                { '6',"-...."},
                { '7',"--..."},
                { '8',"---.."},
                { '9',"----."},
                { '0',"-----"},
            };
        }

        private void MorseToEngCodeAlphabet()
        {
            morseToEng = new Dictionary<string, char>
            {
                {  ".-", 'A'},
                {  "-...", 'B'},
                { "-.-.", 'C'},
                { "-..", 'D'},
                { ".", 'E'},
                { "..-.", 'F'},
                { "--.", 'G'},
                {"....", 'H'},
                { "..", 'I'},
                { ".---", 'J'},
                { "-.-", 'K'},
                { ".-..", 'L'},
                { "--", 'M'},
                { "-.", 'N'},
                { "---", 'O'},
                { ".--.", 'P'},
                { "--.-", 'Q'},
                { ".-.", 'R'},
                { "...", 'S'},
                { "-", 'T'},
                { "..-", 'U'},
                { "...-", 'V'},
                { ".--", 'W'},
                { "-..-", 'X'},
                { "-.--", 'Y'},
                { "--..", 'Z'},
                { "/", ' '},
                { ".----", '1'},
                { "..---", '2'},
                { "...--", '3'},
                { "....-", '4'},
                { ".....", '5'},
                { "-....", '6'},
                { "--...", '7'},
                { "---..", '8'},
                { "----.", '9'},
                { "-----", '0'},
            };
        }

        public string TranslateEngToMorse(string inputChars)
        {
            EngToMorseCodeAlphabet();
            string result = "";
            if (!string.IsNullOrEmpty(inputChars))
            {
                try
                {
                    for (int i = 0; i < inputChars.Length; i++)
                    {
                        result += engToMorse[inputChars.ToUpper()[i]] + " ";
                    }
                }
                catch
                {
                    result = $"Error in input! Try again.";
                }
            }

            return result;
        }

        public string TranslateMorseToEng(string inputValue)
        {
            MorseToEngCodeAlphabet();
            string[] morseWords = inputValue.Split(new string[] { "   " }, StringSplitOptions.None);
            StringBuilder result = new StringBuilder();

            if (!string.IsNullOrEmpty(inputValue))
            {
                try
                {
                    foreach (string morseWord in morseWords)
                    {
                        string[] morseChars = morseWord.Split(' ');
                        foreach (string morseChar in morseChars)
                        {
                            if (morseToEng.ContainsKey(morseChar))
                            {
                                result.Append(morseToEng[morseChar]);
                            }
                            else
                            {
                                result.Append('?'); // если символ Морзе не найден, добавляем '?'
                            }
                        }
                        result.Append(' '); // добавляем пробел между словами
                    }
                    // Удаляем последний лишний пробел
                    if (result.Length > 0)
                    {
                        result.Length--;
                    }
                }
                catch
                {
                    result.Clear();
                    result.Append("Error in input! Try again.");
                }
            }

            return result.ToString();
        }

    }
}
