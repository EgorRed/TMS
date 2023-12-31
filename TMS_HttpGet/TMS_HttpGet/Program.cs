﻿using System.Xml.Linq;

var url = "https://ru.wikipedia.org/wiki/";
var client = new HttpClient();

var chars = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray();

foreach (char leftSymbol in chars)
    {
    foreach (char rigthSymbol in chars)
    {
        string name = chars[leftSymbol].ToString() + chars[rigthSymbol].ToString();
        var path = url + "." + name;

        try
        {
            HttpResponseMessage responce = await client.GetAsync(path);

            if (responce.IsSuccessStatusCode)
            {
                Console.Write($"{url}{name}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t success");
                Console.ForegroundColor = ConsoleColor.White;


                var text = await responce.Content.ReadAsStringAsync();
                var dataPath = $"..\\..\\..\\HtmlFiles\\{name}.html";

                File.Create(dataPath).Close();
                File.WriteAllText(dataPath, text);
            }
            else
            {
                Console.Write($"{url}{name}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t not a success");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Ошибка при обработке страницы \"{path}\".\n{ex.Data}");
        }
    }

    
}