// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;
using WebScrapping.Models;

var html = @"https://gist.github.com/raysan5/909dc6cf33ed40223eb0dfe625c0de74";

HtmlWeb web = new HtmlWeb();

var htmlDoc = web.Load(html);

var TitleTable = htmlDoc.DocumentNode.SelectNodes("//*[@id='file-custom_game_engines_small_study-md-readme']/article/table[2]/tbody/tr[1]");

var engines = new List<GameEngine>();

foreach (var row in TitleTable)
{
    var gameEngine = new GameEngine
    {
        Name = row.SelectSingleNode("./td[1]").InnerText,
        Employees = row.SelectSingleNode("./td[2]").InnerText,
        Engine = row.SelectSingleNode("./td[3]").InnerText,
        Games = row.SelectSingleNode("./td[4]").InnerText
    };

    engines.Add(gameEngine);
}


foreach(var item in engines)
{
    Console.WriteLine($"{item.Name}");
    Console.WriteLine($"{item.Engine}");
}
