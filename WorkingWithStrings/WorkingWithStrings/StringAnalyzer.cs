using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WorkingWithStrings
{
    enum Mode
    {
        mString,
        mPath
    }

    struct NumberAndWordPair
    {
        public string word { set; get; }
        public int num { set; get; }
    }

    internal class StringAnalyzer
    {
        public StringAnalyzer(in string pathOrString, Mode mode)
        {
            switch (mode)
            {
                case Mode.mString:
                    this.str = pathOrString;
                    break;
                case Mode.mPath:
                    using (var sr = new StreamReader(pathOrString, Encoding.UTF8))
                    {
                        str = sr.ReadToEnd();
                    }
                    break;
            }
        }

        // Найти слова, содержащие максимальное количество цифр
        public List<NumberAndWordPair> WordAndCountNumbers()
        {
            List<NumberAndWordPair> arrPair = new List<NumberAndWordPair>();            

            var arrStr = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in arrStr)
            {
                NumberAndWordPair pair = new();
                pair.word = word;
                pair.num = DigitCount(word);
                arrPair.Add(pair);
            }

            return arrPair;
        }

        //Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.
        public NumberAndWordPair TheLongestWord()
        {
            NumberAndWordPair pair = new();
            var arrStr = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int maxlength = 0;

            foreach (var word in arrStr)
            {
                if (maxlength < word.Length)
                {
                    maxlength = word.Length;
                    pair.word = word;
                } 
            }
            pair.num = NumberOfOccurrences(ref arrStr, pair.word);

            return pair;
        }

        //Заменить цифры от 0 до 9 на слова «ноль», «один», ..., «девять».
        public string ReplaceNumbers()
        {
            StringBuilder stringBuilder = new StringBuilder(str);

            for (int i = 0; i < stringBuilder.Length; i++)
            {
                if (char.IsNumber(stringBuilder[i]))
                {
                    var temp = NumberConverter(stringBuilder[i]);
                    stringBuilder.Remove(i, 1);
                    stringBuilder.Insert(i, temp);
                }
            }

            return stringBuilder.ToString();
        }

        //Вывести на экран сначала вопросительные, а затем восклицательные предложения
        public List<string> QuestionSentences()
        {
            List<string> questionS = new List<string>();
            int lastPosition = 0;
            for (int i = 0;i < str.Length;i++)
            {
                if(CheckSentenceSeparators(str[i]))
                {
                    var result = str.Substring(lastPosition, (i-lastPosition)+1);
                    lastPosition = i+1;
                    if (result.Last() == '?') questionS.Add(result);
                }
            }
            return questionS;
        }

        public List<string> ExclamationSentences()
        {
            List<string> exclamationS = new List<string>();
            int lastPosition = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (CheckSentenceSeparators(str[i]))
                {
                    var result = str.Substring(lastPosition, (i - lastPosition) + 1);
                    lastPosition = i + 1;
                    if (result.Last() == '!') exclamationS.Add(result);
                }
            }
            return exclamationS;
        }


        //Вывести на экран только предложения, не содержащие запятых.
        public List<string> SentencesWithoutCommas()
        {
            List<string> sentenceWithoutCommas = new List<string>();
            string[] AllSentences = str.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string sentence in AllSentences)
            {
                if(sentence.IndexOf(',') == -1) sentenceWithoutCommas.Add(sentence);
            }
            return sentenceWithoutCommas;
        }


        //Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.
        public List<string> FindWordsWithSameStartEndLetter()
        {
            List<string> wordsWithSameStartEndLetter = new List<string>();
            string[] words = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i][0] == words[i][words[i].Length - 1])
                {
                    wordsWithSameStartEndLetter.Add(words[i]);
                }
            }
            return wordsWithSameStartEndLetter;
        }


        private bool CheckSentenceSeparators(char symbol) 
        {
            char[] separators = { '.', '!', '?' };
            foreach (char c in separators) 
            {
                if(symbol == c) return true;
            }
            return false;

        }

        private string NumberConverter(char number) => number switch
        {
            '0' => "НОЛЬ",
            '1' => "ОДИН",
            '2' => "ДВА",
            '3' => "ТРИ",
            '4' => "ЧЕТЫРЕ",
            '5' => "ПЯТЬ",
            '6' => "ШЕСТЬ",
            '7' => "СЕМЬ",
            '8' => "ВОСЕМЬ",
            '9' => "ДЕВЯТЬ",
            _ => "ERR"
        };

        private int NumberOfOccurrences(ref string[] arrStr, in string maxLengthWord)
        {

            int counter = 0;

            foreach (var word in arrStr)
            {
                if (string.CompareOrdinal(word, maxLengthWord) == 0) counter++;
            }

            return counter;
        }

        private string RemoveSlashCharacters(in string str)
        {
            StringBuilder stringBuilder = new StringBuilder(str);
            stringBuilder.Replace("\\n", "");
            //stringBuilder.Replace("\\n", "");
            //stringBuilder.Replace("\\n", "");
            //stringBuilder.Replace("\\n", "");
            return stringBuilder.ToString();
        }

        private int DigitCount(in string word)
        {
            int counter = 0;
            foreach (var item in word)
            {
                if (char.IsDigit(item)) counter++;
            }
            return counter;
        }


        private string str;
    }
}

