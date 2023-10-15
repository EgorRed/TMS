
using WorkingWithStrings;

StringAnalyzer stringAnalyzer = new(@"C:\Users\User\Desktop\proj\test.txt", Mode.mPath);
//var a = stringAnalyzer.WordAndCountNumbers();
//foreach (var word in a)
//{
//    Console.WriteLine($"{word.word} - {word.num}");
//}

//var a = stringAnalyzer.TheLongestWord();
//Console.WriteLine($"Саме длинное слово: [{a.word}] количество вхождений: {a.num} ");

var a = stringAnalyzer.FindWordsWithSameStartEndLetter();
foreach (var sentence in a)
{
    Console.WriteLine(sentence);
}
