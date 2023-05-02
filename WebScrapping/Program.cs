// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;
using System.Runtime.InteropServices.ComTypes;
using WebScrapping.Models;
using WebScrapping;

var html = @"https://gist.github.com/raysan5/909dc6cf33ed40223eb0dfe625c0de74";

HtmlWeb web = new HtmlWeb();

var htmlDoc = web.Load(html);

var TitleTable = htmlDoc.DocumentNode.SelectNodes("//tbody/tr");

MainMenu.Run(TitleTable);


