var client = new HttpClient();
var url = "https://ru.wikipedia.org/wiki/";

for (var i = 'a'; i <= 'z'; i++)
{
    for (var j = 'a'; j <= 'z'; j++)
    {
        var path = url + "." + i + j;

        HttpResponseMessage responce = await client.GetAsync(path);

        if (responce.IsSuccessStatusCode)
        {
            Console.Write($"{url}{i}{j}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t success");
            Console.ForegroundColor = ConsoleColor.White;


            var text = await responce.Content.ReadAsStringAsync();
            var dataPath = $"..\\..\\..\\HtmlFiles\\{i}{j}.html";

            File.Create(dataPath).Close();
            File.WriteAllText(dataPath, text);
        }
        else
        {
            Console.Write($"{url}{i}{j}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t not a success");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}