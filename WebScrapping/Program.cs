// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;


var html = @"https://gist.github.com/raysan5/909dc6cf33ed40223eb0dfe625c0de74";

HtmlWeb web = new HtmlWeb();

var htmlDoc = web.Load(html);

var TitleTable = htmlDoc.DocumentNode.SelectNodes("//*[@id='file-custom_game_engines_small_study-md-readme']/article/table[2]/tbody/tr[1]/td[3]");

Console.WriteLine("------------------");

foreach (var title in TitleTable)
    Console.WriteLine(title.InnerText);
