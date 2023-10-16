using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithStrings
{
    internal class Menu
    {
        public void Start(ref StringAnalyzer sa)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите операцию");
                Console.WriteLine("0 => Выйти");
                Console.WriteLine("1 => Найти слова, содержащие максимальное количество цифр.");
                Console.WriteLine("2 => Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.");
                Console.WriteLine("3 => Заменить цифры от 0 до 9 на слова «ноль», «один», ..., «девять»");
                Console.WriteLine("4 => Вывести на экран сначала вопросительные, а затем восклицательные предложения.");
                Console.WriteLine("5 => Вывести на экран только предложения, не содержащие запятых.");
                Console.WriteLine("6 => Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву");
                int result = 0;
                if(int.TryParse(Console.ReadLine(), out result))
                {
                    switch (result)
                    {
                        case 1:
                            foreach (var i in sa.WordAndCountNumbers())
                            {
                                Console.WriteLine($"{i.word} - {i.num}");
                            }
                            Console.ReadLine();
                            break;
                        case 2:
                            var temp = sa.TheLongestWord();
                            Console.WriteLine($"Самое длинное слово: {temp.word} \nКоличество вхождений: {temp.num}");
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine(sa.ReplaceNumbers());
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("\nВопросительные:");
                            foreach (var i in sa.QuestionSentences())
                                Console.WriteLine(i);

                            Console.WriteLine("\nВосклицательные:");
                            foreach (var i in sa.ExclamationSentences())
                                Console.WriteLine(i);
                            Console.ReadLine();
                            break;
                        case 5:
                            foreach(var i in sa.SentencesWithoutCommas())
                                Console.WriteLine(i);
                            Console.ReadLine();
                            break;
                        case 6:
                            foreach (var i in sa.FindWordsWithSameStartEndLetter())
                                Console.WriteLine(i);
                            Console.ReadLine();
                            break;
                        case 0:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Доступны только циферки от 0 до 6ти, ещё раз такую дич напишешь, я тебе винду снесу! ");
                    Console.ReadLine();
                }
                 
            }
        }

    }
}
