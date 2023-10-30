using System.Xml.Linq;

var url = "https://ru.wikipedia.org/wiki/";
var client = new HttpClient();

var chars = new char[]{'a', 'b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

for (var i = 0; i <= chars.Length; i++)
{
    for (var j = 0; j <= chars.Length; j++)
    {
        string name = chars[i].ToString() + chars[j].ToString();
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