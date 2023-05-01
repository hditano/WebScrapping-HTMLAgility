// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;
using System.Runtime.InteropServices.ComTypes;
using WebScrapping.Models;

var html = @"https://gist.github.com/raysan5/909dc6cf33ed40223eb0dfe625c0de74";

HtmlWeb web = new HtmlWeb();

var htmlDoc = web.Load(html);

var TitleTable = htmlDoc.DocumentNode.SelectNodes("//tbody/tr");

var gameEngines = new List<GameEngine>();

foreach(var row in TitleTable)
{
    var game = new GameEngine
    {
        Name = row.SelectSingleNode("./td[1]").InnerText,
        Employees = row.SelectSingleNode("./td[2]").InnerText,
        Engine = row.SelectSingleNode("./td[3]").InnerText,
        Games = row.SelectSingleNode("./td[4]").InnerText
    };

    gameEngines.Add(game);
}

foreach(var engine in gameEngines)
    Console.WriteLine(engine.Games);
