using DungeonCrawlerV1.ClassesPersonagens;
using DungeonCrawlerV1.Enums;
using DungeonCrawlerV1.Runs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerV1
{
    public class Start
    {
        static string JsonFile = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Placar.json");
        static List<Jogador> Jogadores = JsonConvert.DeserializeObject<List<Jogador>>(JsonFile);
        public static void ExecutarAventura()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("░▒█▀▄▀█░█░░█░█▀▀░▀█▀░█▀▀░█▀▀▄░█░░█░░░▒█▀▀▄░█░▒█░█▀▀▄░█▀▀▀░█▀▀░▄▀▀▄░█▀▀▄");
            Console.WriteLine("░▒█▒█▒█░█▄▄█░▀▀▄░░█░░█▀▀░█▄▄▀░█▄▄█░░░▒█░▒█░█░▒█░█░▒█░█░▀▄░█▀▀░█░░█░█░▒█");
            Console.WriteLine("░▒█░░▒█░▄▄▄▀░▀▀▀░░▀░░▀▀▀░▀░▀▀░▄▄▄▀░░░▒█▄▄█░░▀▀▀░▀░░▀░▀▀▀▀░▀▀▀░░▀▀░░▀░░▀");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(string.Empty);

            Console.WriteLine("1 - Start");
            Console.WriteLine("2 - Rank");
            Console.WriteLine("3 - Help");

            int.TryParse(Console.ReadLine(), out int opcao);

            switch (opcao)
            {
                case 1:
                    PegarInfo();
                    break;
                case 2:
                    JSONMostrar();
                    Thread.Sleep(5000);
                    Console.Clear();
                    ExecutarAventura();
                    break;
                case 3:
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("Mystery Dungeon é um dungeon crawler, espero que se divirta muito!");
                    Console.WriteLine("------------------------------------------------------------------");
                    Thread.Sleep(5000);
                    Console.Clear();
                    ExecutarAventura();
                    break;
                default:
                    Console.WriteLine("Número inválido!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExecutarAventura();
                    break;
            }
        }

        public static void PegarInfo()
        {
            Thread.Sleep(2000);
            Console.Clear();

            Console.WriteLine("Escolha uma classe:");

            Console.WriteLine("1 - Bardo");
            Console.WriteLine("2 - Clérigo");
            Console.WriteLine("3 - Druida");

            int.TryParse(Console.ReadLine(), out int opcao);

            Classes op = (Classes)opcao;

            switch (op)
            {
                case Classes.Bardo:
                    RunBardo.PegarMonstroBardo();
                    break;
                case Classes.Clerigo:
                    RunClerigo.PegarMonstroClerigo();
                    break;
                case Classes.Druida:
                    RunDruida.PegarMonstroDruida();
                    break;
                default:
                    Console.WriteLine("Número inválido!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    PegarInfo();
                    break;
            }
        }

        public static void JSONMostrar()
        {
            Jogador player = new Jogador();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Jogador | Pontos");
            Console.ForegroundColor = ConsoleColor.White;

            List<Jogador> ListaOrdenada = Jogadores.OrderByDescending(x => x.XP).ToList();
            
            foreach (Jogador jogador1 in ListaOrdenada)
            {
                Console.WriteLine($"{jogador1.Nome} | {jogador1.XP}");
            }
        }

        public static void JSONEnviar(string nome, int xp)
        {
            Jogador player = new Jogador();

            player.Nome = nome;
            player.XP = xp;

            Jogadores.Add(player);

            var JsonSerializado = JsonConvert.SerializeObject(Jogadores);

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Placar.json", JsonSerializado);
        }
    }
}
