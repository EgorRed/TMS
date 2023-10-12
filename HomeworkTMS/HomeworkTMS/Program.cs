using HomeworkTMS;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

Bank bank = new Bank();
var parrBankDep = bank.calculateContribution(18, 12.1, 1000).ToArray();

Console.WriteLine("+-----------+-----------+--------+--------------+------------+");

for (int i = 0; i < parrBankDep.Length; i++)
{
    var fd = parrBankDep[i].firstDayOfMonth.Date.ToString();
    var ld = parrBankDep[i].lastDayOfMonth.Date.ToString();

    Console.Write($"| {fd.Substring(3).Substring(0, fd.Length - 10)}");
    Console.SetCursorPosition(12, i + 1);

    Console.Write($"| {ld.Substring(3).Substring(0, fd.Length - 10)}");
    Console.SetCursorPosition(24, i + 1);

    Console.Write($"| {parrBankDep[i].percent} ");
    Console.SetCursorPosition(33, i + 1);

    Console.Write($"| {Math.Round(parrBankDep[i].depositAmount, 2)} BUN");
    Console.SetCursorPosition(48, i + 1);

    Console.Write($"| {Math.Round(parrBankDep[i].revenueForTheCurrentMonth, 2)} BYN");
    Console.SetCursorPosition(60, i + 1);
    Console.Write(" |");
    Console.WriteLine();
}
Console.WriteLine("+-----------+-----------+--------+--------------+------------+");
Console.WriteLine();
Console.WriteLine($"Итого: {Math.Round(parrBankDep.Last().revenueForTheCurrentMonth + parrBankDep.Last().depositAmount, 2)}");

//int[] a = { 1, 8, 1, 6 };
//var b = BubbleSort(a);

//foreach (var x in b)
//    Console.WriteLine(x);

//static int[] BubbleSort(int[] array)
//{
//    var len = array.Length;
//    for (var i = 1; i < len; i++)
//    {
//        for (var j = 0; j < len - i; j++)
//        {
//            if (array[j] > array[j + 1])
//            {
//                Swap(ref array[j], ref array[j + 1]);
//            }
//        }
//    }

//    return array;
//}
//static void Swap(ref int e1, ref int e2)
//{
//    var temp = e1;
//    e1 = e2;
//    e2 = temp;
//}