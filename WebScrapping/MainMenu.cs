using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrapping.Models;
using ConsoleTables;

namespace WebScrapping
{
    internal class MainMenu
    {
        public static void Run(HtmlNodeCollection html)
        {
            var gameEngines = ParseHTML(html);

            Console.WriteLine($"| Game Engines DataBase |");
            Console.WriteLine();

            var table = new ConsoleTable("Company", "Employees", "Ëngine", "Games");

            foreach(var item in gameEngines)
            {
                table.AddRow(item.Name, item.Employees, item.Engine, item.Games);
            }

            table.Write();
            Console.WriteLine();

        }

        static List<GameEngine> ParseHTML(HtmlNodeCollection TitleTable)
        {
            var gameEngines = new List<GameEngine>();

            foreach (var row in TitleTable)
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

            return gameEngines;
        }
    }
}
