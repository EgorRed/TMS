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

                    }
                }
                
            }
        }

    }
}
