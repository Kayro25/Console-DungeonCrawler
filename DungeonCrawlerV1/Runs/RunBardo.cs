using DungeonCrawlerV1.ClassesPersonagens;
using DungeonCrawlerV1.Enums;
using DungeonCrawlerV1.Monstros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerV1.Runs
{
    public class RunBardo
    {
        //Start do bardo
        public static void PegarMonstroBardo()
        {
            Jogador jogador = new Jogador();
            Bardo bardo = new Bardo();

            int Ataque = 0;
            int Cura;
            bool controle = true;
            bool controle2 = true;
            Console.WriteLine("Digite o nome do Jogador:");
            jogador.Nome = Console.ReadLine() ?? string.Empty;

            if (controle2)
            {
                while (controle)
                {
                    Beholder beholder = new Beholder();
                    PanteraDeslocadora panteraDeslocadora = new PanteraDeslocadora();
                    MonstrodaFerrugem monstrodaFerrugem = new MonstrodaFerrugem();
                    CuboGelatinoso cuboGelatinoso = new CuboGelatinoso();
                    Lich lich = new Lich();
                    DevoradordeMentes devoradordeMentes = new DevoradordeMentes();
                    Random random = new Random();

                    Console.WriteLine();
                    Console.WriteLine("Você deseja entrar em uma masmorra ou pegar um tesouro?");
                    Console.WriteLine("1 - Masmorra");
                    Console.WriteLine("2 - Tesouro");
                    int.TryParse(Console.ReadLine(), out int opcao);

                    EscolhaRun op = (EscolhaRun)opcao;

                    switch (op)
                    {
                        case EscolhaRun.Masmorra:
                            int sorteioMonstro = random.Next(1, 6);

                            //Beholder
                            if (sorteioMonstro == 1)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Um Beholder aparece!");
                                Console.WriteLine();

                                while (bardo.VidaMaxima > 0 && beholder.VidaMaxima > 0)
                                {
                                    Console.WriteLine("++ Turno do Player ++");
                                    Console.WriteLine($"Player HP: {bardo.VidaMaxima}");
                                    Console.WriteLine($"Player XP: {jogador.XP}");
                                    Console.WriteLine("Digite 'a' para atacar e 'c' para curar!");
                                    string escolha = Console.ReadLine() ?? string.Empty;

                                    if (escolha == "a")
                                    {
                                        Ataque = random.Next(1, 4);
                                        beholder.VidaMaxima -= Ataque;
                                        Console.WriteLine("...................................................");
                                        Console.WriteLine($"Você atacou o Beholder e deu {Ataque} de dano!");
                                        Console.WriteLine("...................................................");
                                    }
                                    else if (escolha == "c")
                                    {
                                        Cura = random.Next(1, 4);
                                        bardo.VidaMaxima += Cura;
                                        Console.WriteLine(".................................");
                                        Console.WriteLine($"Você curou {Cura} de HP!");
                                        Console.WriteLine(".................................");
                                    }

                                    if (beholder.VidaMaxima > 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("++ Turno do Beholder ++");
                                        Console.WriteLine($"Beholder HP: {beholder.VidaMaxima}");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        int Nsorteio = random.Next(1, 4);

                                        if (Nsorteio == 1)
                                        {
                                            beholder.Ataque = random.Next(2, 4);
                                            bardo.VidaMaxima -= beholder.Ataque;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("..............................................");
                                            Console.WriteLine($"O Beholder te atacou e deu {beholder.Ataque} de dano!");
                                            Console.WriteLine("..............................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else if (Nsorteio == 2)
                                        {
                                            beholder.Cura = random.Next(3, 6);
                                            beholder.VidaMaxima += beholder.Cura;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("................................");
                                            Console.WriteLine($"O Beholder curou {beholder.Cura} de HP!");
                                            Console.WriteLine("................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else if (Nsorteio == 3)
                                        {
                                            beholder.Ataque = random.Next(2, 4);
                                            bardo.VidaMaxima -= beholder.Ataque;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("..............................................");
                                            Console.WriteLine($"O Beholder te atacou e deu {beholder.Ataque} de dano!");
                                            Console.WriteLine("..............................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else
                                        {
                                            beholder.Cura = random.Next(3, 6);
                                            beholder.VidaMaxima += beholder.Cura;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("................................");
                                            Console.WriteLine($"O Beholder curou {beholder.Cura} de HP!");
                                            Console.WriteLine("................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    }
                                }

                                if (bardo.VidaMaxima > 0)
                                {
                                    int XPObtido = random.Next(1, 10);

                                    jogador.XP += XPObtido;

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine("Você matou o Beholder!");
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine($"XP obtido: {XPObtido}");
                                    bardo.VidaMaxima += 5;
                                    Console.WriteLine($"Você ganha 5 de vida!");
                                    Console.ForegroundColor = ConsoleColor.White;



                                    controle = true;
                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine("O Beholder te matou!");
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Thread.Sleep(3000);
                                    Console.Clear();

                                    Start.ExecutarAventura();
                                }
                            }

                            //Pantera Deslocadora
                            else if (sorteioMonstro == 2)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Uma Pantera Deslocadora aparece!");
                                Console.WriteLine();

                                while (bardo.VidaMaxima > 0 && panteraDeslocadora.VidaMaxima > 0)
                                {
                                    Console.WriteLine("++ Turno do Player ++");
                                    Console.WriteLine($"Player HP: {bardo.VidaMaxima}");
                                    Console.WriteLine($"Player XP: {jogador.XP}");
                                    Console.WriteLine("Digite 'a' para atacar e 'c' para curar!");
                                    string escolha = Console.ReadLine() ?? string.Empty;

                                    if (escolha == "a")
                                    {
                                        Ataque = random.Next(1, 4);
                                        panteraDeslocadora.VidaMaxima -= Ataque;
                                        Console.WriteLine("...................................................");
                                        Console.WriteLine($"Você atacou a Pantera Deslocadora e deu {Ataque} de dano!");
                                        Console.WriteLine("...................................................");
                                    }
                                    else if (escolha == "c")
                                    {
                                        Cura = random.Next(1, 4);
                                        bardo.VidaMaxima += Cura;
                                        Console.WriteLine(".................................");
                                        Console.WriteLine($"Você curou {Cura} de HP!");
                                        Console.WriteLine(".................................");
                                    }

                                    if (panteraDeslocadora.VidaMaxima > 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("++ Turno do Pantera Deslocadora ++");
                                        Console.WriteLine($"Pantera Deslocadora HP: {panteraDeslocadora.VidaMaxima}");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        int Nsorteio = random.Next(1, 4);

                                        if (Nsorteio == 1)
                                        {
                                            panteraDeslocadora.Ataque = random.Next(1, 4);
                                            bardo.VidaMaxima -= panteraDeslocadora.Ataque;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("..............................................");
                                            Console.WriteLine($"A Pantera Deslocadora te atacou e deu {panteraDeslocadora.Ataque} de dano!");
                                            Console.WriteLine("..............................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else if (Nsorteio == 2)
                                        {
                                            panteraDeslocadora.Cura = random.Next(1, 2);
                                            panteraDeslocadora.VidaMaxima += panteraDeslocadora.Cura;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("................................");
                                            Console.WriteLine($"A Pantera Deslocadora curou {panteraDeslocadora.Cura} de HP!");
                                            Console.WriteLine("................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else if (Nsorteio == 3)
                                        {
                                            panteraDeslocadora.Ataque = random.Next(1, 4);
                                            bardo.VidaMaxima -= panteraDeslocadora.Ataque;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("..............................................");
                                            Console.WriteLine($"A Pantera Deslocadora te atacou e deu {panteraDeslocadora.Ataque} de dano!");
                                            Console.WriteLine("..............................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else
                                        {
                                            panteraDeslocadora.Cura = random.Next(1, 2);
                                            panteraDeslocadora.VidaMaxima += panteraDeslocadora.Cura;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("................................");
                                            Console.WriteLine($"A Pantera Deslocadora curou {panteraDeslocadora.Cura} de HP!");
                                            Console.WriteLine("................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    }
                                }

                                if (bardo.VidaMaxima > 0)
                                {
                                    int XPObtido = random.Next(1, 10);

                                    jogador.XP += XPObtido;

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine("Você matou a Pantera Deslocadora!");
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine($"XP obtido: {XPObtido}");
                                    bardo.VidaMaxima += 5;
                                    Console.WriteLine($"Você ganha 5 de vida!");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    controle = true;

                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine("A Pantera Deslocadora te matou!");
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Thread.Sleep(3000);
                                    Console.Clear();

                                    Start.ExecutarAventura();
                                }
                            }

                            //Monstro da Ferrugem
                            else if (sorteioMonstro == 3)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Um Monstro da Ferrugem aparece!");
                                Console.WriteLine();

                                while (bardo.VidaMaxima > 0 && monstrodaFerrugem.VidaMaxima > 0)
                                {
                                    Console.WriteLine("++ Turno do Player ++");
                                    Console.WriteLine($"Player HP: {bardo.VidaMaxima}");
                                    Console.WriteLine($"Player XP: {jogador.XP}");
                                    Console.WriteLine("Digite 'a' para atacar e 'c' para curar!");
                                    string escolha = Console.ReadLine() ?? string.Empty;

                                    if (escolha == "a")
                                    {
                                        Ataque = random.Next(1, 4);
                                        monstrodaFerrugem.VidaMaxima -= Ataque;
                                        Console.WriteLine("...................................................");
                                        Console.WriteLine($"Você atacou o Monstro da Ferrugem e deu {Ataque} de dano!");
                                        Console.WriteLine("...................................................");
                                    }
                                    else if (escolha == "c")
                                    {
                                        Cura = random.Next(1, 4);
                                        bardo.VidaMaxima += Cura;
                                        Console.WriteLine(".................................");
                                        Console.WriteLine($"Você curou {Cura} de HP!");
                                        Console.WriteLine(".................................");
                                    }

                                    if (monstrodaFerrugem.VidaMaxima > 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("++ Turno do Monstro da Ferrugem ++");
                                        Console.WriteLine($"Monstro da Ferrugem HP: {monstrodaFerrugem.VidaMaxima}");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        int Nsorteio = random.Next(1, 4);

                                        if (Nsorteio == 1)
                                        {
                                            monstrodaFerrugem.Ataque = random.Next(1, 3);
                                            bardo.VidaMaxima -= monstrodaFerrugem.Ataque;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("..............................................");
                                            Console.WriteLine($"O Monstro da Ferrugem te atacou e deu {monstrodaFerrugem.Ataque} de dano!");
                                            Console.WriteLine("..............................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else if (Nsorteio == 2)
                                        {
                                            monstrodaFerrugem.Cura = random.Next(1, 4);
                                            monstrodaFerrugem.VidaMaxima += monstrodaFerrugem.Cura;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("................................");
                                            Console.WriteLine($"O Monstro da Ferrugem curou {monstrodaFerrugem.Cura} de HP!");
                                            Console.WriteLine("................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else if (Nsorteio == 3)
                                        {
                                            monstrodaFerrugem.Ataque = random.Next(1, 3);
                                            bardo.VidaMaxima -= monstrodaFerrugem.Ataque;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("..............................................");
                                            Console.WriteLine($"O Monstro da Ferrugem te atacou e deu {monstrodaFerrugem.Ataque} de dano!");
                                            Console.WriteLine("..............................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else
                                        {
                                            monstrodaFerrugem.Cura = random.Next(1, 4);
                                            monstrodaFerrugem.VidaMaxima += monstrodaFerrugem.Cura;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("................................");
                                            Console.WriteLine($"O Monstro da Ferrugem curou {monstrodaFerrugem.Cura} de HP!");
                                            Console.WriteLine("................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    }
                                }

                                if (bardo.VidaMaxima > 0)
                                {
                                    int XPObtido = random.Next(1, 10);

                                    jogador.XP += XPObtido;

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine("Você matou o Monstro da Ferrugem!");
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine($"XP obtido: {XPObtido}");
                                    bardo.VidaMaxima += 5;
                                    Console.WriteLine($"Você ganha 5 de vida!");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    controle = true;
                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine("O Monstro da Ferrugem te matou!");
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Thread.Sleep(3000);
                                    Console.Clear();

                                    Start.ExecutarAventura();
                                }
                            }

                            //Cubo Gelatinoso
                            else if (sorteioMonstro == 4)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Um Cubo Gelatinoso aparece!");
                                Console.WriteLine();

                                while (bardo.VidaMaxima > 0 && cuboGelatinoso.VidaMaxima > 0)
                                {
                                    Console.WriteLine("++ Turno do Player ++");
                                    Console.WriteLine($"Player HP: {bardo.VidaMaxima}");
                                    Console.WriteLine($"Player XP: {jogador.XP}");
                                    Console.WriteLine("Digite 'a' para atacar e 'c' para curar!");
                                    string escolha = Console.ReadLine() ?? string.Empty;

                                    if (escolha == "a")
                                    {
                                        Ataque = random.Next(1, 4);
                                        cuboGelatinoso.VidaMaxima -= Ataque;
                                        Console.WriteLine("...................................................");
                                        Console.WriteLine($"Você atacou o Cubo Gelatinoso e deu {Ataque} de dano!");
                                        Console.WriteLine("...................................................");
                                    }
                                    else if (escolha == "c")
                                    {
                                        Cura = random.Next(1, 4);
                                        bardo.VidaMaxima += Cura;
                                        Console.WriteLine(".................................");
                                        Console.WriteLine($"Você curou {Cura} de HP!");
                                        Console.WriteLine(".................................");
                                    }

                                    if (cuboGelatinoso.VidaMaxima > 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("++ Turno do Cubo Gelatinoso ++");
                                        Console.WriteLine($"Cubo Gelatinoso HP: {cuboGelatinoso.VidaMaxima}");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        int Nsorteio = random.Next(1, 4);

                                        if (Nsorteio == 1)
                                        {
                                            cuboGelatinoso.Ataque = random.Next(2, 5);
                                            bardo.VidaMaxima -= cuboGelatinoso.Ataque;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("..............................................");
                                            Console.WriteLine($"O Cubo Gelatinoso te atacou e deu {cuboGelatinoso.Ataque} de dano!");
                                            Console.WriteLine("..............................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else if (Nsorteio == 2)
                                        {
                                            cuboGelatinoso.Cura = random.Next(1, 3);
                                            cuboGelatinoso.VidaMaxima += cuboGelatinoso.Cura;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("................................");
                                            Console.WriteLine($"O Cubo Gelatinoso curou {cuboGelatinoso.Cura} de HP!");
                                            Console.WriteLine("................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else if (Nsorteio == 3)
                                        {
                                            cuboGelatinoso.Ataque = random.Next(2, 5);
                                            bardo.VidaMaxima -= cuboGelatinoso.Ataque;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("..............................................");
                                            Console.WriteLine($"O Cubo Gelatinoso te atacou e deu {cuboGelatinoso.Ataque} de dano!");
                                            Console.WriteLine("..............................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else
                                        {
                                            cuboGelatinoso.Cura = random.Next(1, 3);
                                            cuboGelatinoso.VidaMaxima += cuboGelatinoso.Cura;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("................................");
                                            Console.WriteLine($"O Cubo Gelatinoso curou {cuboGelatinoso.Cura} de HP!");
                                            Console.WriteLine("................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    }
                                }

                                if (bardo.VidaMaxima > 0)
                                {
                                    int XPObtido = random.Next(1, 10);

                                    jogador.XP += XPObtido;

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine("Você matou o Cubo Gelatinoso!");
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine($"XP obtido: {XPObtido}");
                                    bardo.VidaMaxima += 5;
                                    Console.WriteLine($"Você ganha 5 de vida!");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    controle = true;

                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine("O Cubo Gelatinoso te matou!");
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Thread.Sleep(3000);
                                    Console.Clear();

                                    Start.ExecutarAventura();
                                }
                            }

                            //Lich
                            else if (sorteioMonstro == 5)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Um Lich aparece!");
                                Console.WriteLine();

                                while (bardo.VidaMaxima > 0 && lich.VidaMaxima > 0)
                                {
                                    Console.WriteLine("++ Turno do Player ++");
                                    Console.WriteLine($"Player HP: {bardo.VidaMaxima}");
                                    Console.WriteLine($"Player XP: {jogador.XP}");
                                    Console.WriteLine("Digite 'a' para atacar e 'c' para curar!");
                                    string escolha = Console.ReadLine() ?? string.Empty;

                                    if (escolha == "a")
                                    {
                                        Ataque = random.Next(1, 4);
                                        lich.VidaMaxima -= Ataque;
                                        Console.WriteLine("...................................................");
                                        Console.WriteLine($"Você atacou o Lich e deu {Ataque} de dano!");
                                        Console.WriteLine("...................................................");
                                    }
                                    else if (escolha == "c")
                                    {
                                        Cura = random.Next(1, 4);
                                        bardo.VidaMaxima += Cura;
                                        Console.WriteLine(".................................");
                                        Console.WriteLine($"Você curou {Cura} de HP!");
                                        Console.WriteLine(".................................");
                                    }

                                    if (lich.VidaMaxima > 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("++ Turno do Lich ++");
                                        Console.WriteLine($"Lich HP: {lich.VidaMaxima}");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        int Nsorteio = random.Next(1, 4);

                                        if (Nsorteio == 1)
                                        {
                                            lich.Ataque = random.Next(1, 3);
                                            bardo.VidaMaxima -= lich.Ataque;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("..............................................");
                                            Console.WriteLine($"O Lich te atacou e deu {lich.Ataque} de dano!");
                                            Console.WriteLine("..............................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else if (Nsorteio == 2)
                                        {
                                            lich.Cura = random.Next(1, 2);
                                            lich.VidaMaxima += lich.Cura;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("................................");
                                            Console.WriteLine($"O Lich curou {lich.Cura} de HP!");
                                            Console.WriteLine("................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else if (Nsorteio == 3)
                                        {
                                            lich.Ataque = random.Next(1, 3);
                                            bardo.VidaMaxima -= lich.Ataque;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("..............................................");
                                            Console.WriteLine($"O Lich te atacou e deu {lich.Ataque} de dano!");
                                            Console.WriteLine("..............................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else
                                        {
                                            lich.Cura = random.Next(1, 2);
                                            lich.VidaMaxima += lich.Cura;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("................................");
                                            Console.WriteLine($"O Lich curou {lich.Cura} de HP!");
                                            Console.WriteLine("................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    }
                                }

                                if (bardo.VidaMaxima > 0)
                                {
                                    int XPObtido = random.Next(1, 10);

                                    jogador.XP += XPObtido;

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine("Você matou o Lich!");
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine($"XP obtido: {XPObtido}");
                                    bardo.VidaMaxima += 5;
                                    Console.WriteLine($"Você ganha 5 de vida!");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    controle = true;

                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine("O Lich te matou!");
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Thread.Sleep(3000);
                                    Console.Clear();

                                    Start.ExecutarAventura();
                                }
                            }

                            //Devorador de Mentes
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Um Devorador de Mentes aparece!");
                                Console.WriteLine();

                                while (bardo.VidaMaxima > 0 && devoradordeMentes.VidaMaxima > 0)
                                {
                                    Console.WriteLine("++ Turno do Player ++");
                                    Console.WriteLine($"Player HP: {bardo.VidaMaxima}");
                                    Console.WriteLine($"Player XP: {jogador.XP}");
                                    Console.WriteLine("Digite 'a' para atacar e 'c' para curar!");
                                    string escolha = Console.ReadLine() ?? string.Empty;

                                    if (escolha == "a")
                                    {
                                        Ataque = random.Next(1, 4);
                                        devoradordeMentes.VidaMaxima -= Ataque;
                                        Console.WriteLine("...................................................");
                                        Console.WriteLine($"Você atacou o Devorador de Mentes e deu {Ataque} de dano!");
                                        Console.WriteLine("...................................................");
                                    }
                                    else if (escolha == "c")
                                    {
                                        Cura = random.Next(1, 4);
                                        bardo.VidaMaxima += Cura;
                                        Console.WriteLine(".................................");
                                        Console.WriteLine($"Você curou {Cura} de HP!");
                                        Console.WriteLine(".................................");
                                    }

                                    if (devoradordeMentes.VidaMaxima > 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("++ Turno do Devorador de Mentes ++");
                                        Console.WriteLine($"Devorador de Mentes HP: {devoradordeMentes.VidaMaxima}");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        int Nsorteio = random.Next(1, 4);

                                        if (Nsorteio == 1)
                                        {
                                            devoradordeMentes.Ataque = random.Next(3, 6);
                                            bardo.VidaMaxima -= devoradordeMentes.Ataque;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("..............................................");
                                            Console.WriteLine($"O Devorador de Mentes te atacou e deu {devoradordeMentes.Ataque} de dano!");
                                            Console.WriteLine("..............................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else if (Nsorteio == 2)
                                        {
                                            devoradordeMentes.Cura = random.Next(3, 5);
                                            devoradordeMentes.VidaMaxima += devoradordeMentes.Cura;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("................................");
                                            Console.WriteLine($"O Devorador de Mentes curou {devoradordeMentes.Cura} de HP!");
                                            Console.WriteLine("................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else if (Nsorteio == 3)
                                        {
                                            devoradordeMentes.Ataque = random.Next(3, 6);
                                            bardo.VidaMaxima -= devoradordeMentes.Ataque;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("..............................................");
                                            Console.WriteLine($"O Devorador de Mentes te atacou e deu {devoradordeMentes.Ataque} de dano!");
                                            Console.WriteLine("..............................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        else
                                        {
                                            devoradordeMentes.Cura = random.Next(3, 5);
                                            devoradordeMentes.VidaMaxima += devoradordeMentes.Cura;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("................................");
                                            Console.WriteLine($"O Devorador de Mentes curou {devoradordeMentes.Cura} de HP!");
                                            Console.WriteLine("................................");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    }
                                }

                                if (bardo.VidaMaxima > 0)
                                {
                                    int XPObtido = random.Next(1, 10);

                                    jogador.XP += XPObtido;

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine("Você matou o Devorador de Mentes!");
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine($"XP obtido: {XPObtido}");
                                    bardo.VidaMaxima += 5;
                                    Console.WriteLine($"Você ganha 5 de vida!");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    controle = true;

                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.WriteLine("O Devorador de Mentes te matou!");
                                    Console.WriteLine("-=-=-=-=-=-=-=-=-==-");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Thread.Sleep(3000);
                                    Console.Clear();

                                    Start.ExecutarAventura();
                                }
                            }
                            break;
                        case EscolhaRun.Tesouro:
                            int sorteioTesouro = random.Next(1, 6);

                            if (sorteioTesouro == 1)
                            {
                                Console.WriteLine("Você achou uma poção vermelha!");
                                Console.WriteLine();
                                Console.WriteLine("Você ganha 7 de HP!");

                                bardo.VidaMaxima += 7;

                                controle = true;
                            }

                            else if (sorteioTesouro == 2)
                            {
                                Console.WriteLine("Você achou uma poção grande e vermelha!");
                                Console.WriteLine();
                                Console.WriteLine("Você ganha 12 de HP!");

                                bardo.VidaMaxima += 12;

                                controle = true;
                            }

                            else if (sorteioTesouro == 3)
                            {
                                Console.WriteLine("Você achou uma espada verde!");
                                Console.WriteLine();
                                Console.WriteLine("Você ganhou 8 de ataque!");

                                Ataque += 8;

                                controle = true;
                            }

                            else if (sorteioTesouro == 4)
                            {
                                Console.WriteLine("Você foi picado por um escorpião!");
                                Console.WriteLine();
                                Console.WriteLine("Você perde 3 de HP!");

                                bardo.VidaMaxima -= 3;

                                if (bardo.VidaMaxima <= 0)
                                {
                                    Start.ExecutarAventura();
                                }

                                controle = true;
                            }

                            else if (sorteioTesouro == 5)
                            {
                                Console.WriteLine("Você aciona uma armadilha e é atingido por flechas!");
                                Console.WriteLine();
                                Console.WriteLine("Você perde 5 de HP!");

                                bardo.VidaMaxima -= 5;

                                if (bardo.VidaMaxima <= 0)
                                {
                                    Start.ExecutarAventura();
                                }

                                controle = true;
                            }

                            else
                            {
                                Console.WriteLine("Você cai no chão!");
                                Console.WriteLine();
                                Console.WriteLine("Você perde 2 de HP!");

                                bardo.VidaMaxima -= 2;

                                if (bardo.VidaMaxima <= 0)
                                {
                                    Start.ExecutarAventura();
                                }

                                controle = true;
                            }
                            break;
                        default:
                            Console.WriteLine("Número inválido!");
                            Thread.Sleep(2000);
                            Console.Clear();
                            controle = true;
                            break;
                    }

                    //Sistema de Nível
                    if (jogador.XP >= 4)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Level Up!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();

                        bardo.VidaMaxima += 8;
                    }

                    else if (jogador.XP >= 8)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Level Up!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();

                        bardo.VidaMaxima += 10;
                    }

                    else if (jogador.XP >= 12)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Level Up!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();

                        bardo.VidaMaxima += 10;
                    }

                    else if (jogador.XP >= 16)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Level Up!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();

                        bardo.VidaMaxima += 10;
                    }

                    else if (jogador.XP >= 20)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Level Up!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();

                        bardo.VidaMaxima += 10;
                    }

                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Level Up!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();

                        bardo.VidaMaxima += 15;
                    }

                    Start.JSONEnviar(jogador.Nome, jogador.XP);
                }

                
            }
        }
    }
}
