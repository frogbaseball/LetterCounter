using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;

namespace LetterCounter {
    internal class Program {
        static string sentence;
        static char[] bannedCharacters = { 
            ' ', '.', '!', '/', ',', '<', '>', '"', '\'', ':', ';', '{', '}', '[', ']', '(', ')', '\\', '|', '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '-', '_', '=', '+', '0', '1',
            '2', '3', '4', '5' , '6', '7', '8', '9'
        };
        static void Main(string[] args) {
            var panel = new Panel("[red]Enter a sentence:[/]");
            panel.Border = BoxBorder.Ascii;
            panel.BorderColor(Color.Red);
            AnsiConsole.Write(panel);
            Input();
            var table = new Table();
            List<char> chars = ReturnUniqueLetters(sentence);
            table.Border(TableBorder.HeavyEdge);
            table.AddColumns("Letter", "Amount");
            table.BorderColor(Color.Red);
            foreach (char c in chars) {
                table.AddRow(c.ToString(), CountAmountOfLetters(sentence, c).ToString());
            }
            AnsiConsole.Write(table);
        }
        static void Input() {
            try {
                sentence = Console.ReadLine();
                if (sentence.Trim() == string.Empty) {
                    Input();
                }
            } catch {
                Input();
            }
        }
        static List<char> ReturnUniqueLetters(string sentence) {
            List<char> chars = new List<char>();
            foreach (char c in sentence) {
                if (!chars.Contains(c) && !bannedCharacters.Contains(c)) {
                    chars.Add(c);
                }
            }
            return chars;
        }
        static int CountAmountOfLetters(string sentence, char letter) {
            int amount = 0;
            foreach (char c in sentence) {
                if (c == letter && !bannedCharacters.Contains(c))
                    amount++;
            }
            return amount;
        }
    }
}
