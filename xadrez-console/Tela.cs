﻿using System;
using tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace xadrez_console
{
    class Tela
    {

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCaputuradas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);

            if(!partida.Terminada)
            {
                Console.WriteLine("Aguardando Jogada: " + partida.JogadorAtual);

                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE! ");
                }

            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }
            
        }

        public static void ImprimirPecasCaputuradas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Pecas Capturadas");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[ ");
            foreach (Peca x in conjunto)
            {
                Console.Write(x +  " " );
                
            }

            Console.Write("] ");


        }


        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.peca(i, j));
                   

                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor FundoOriginal = Console.BackgroundColor;
            ConsoleColor FundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j] == true)
                    {
                        Console.BackgroundColor = FundoAlterado;
                    }

                    else
                    {
                        Console.BackgroundColor = FundoOriginal;
                    }
                    ImprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = FundoOriginal;


                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = FundoOriginal;

        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);

        }

        public static void ImprimirPeca(Peca peca)
        {

            if (peca == null)
            {
                Console.Write("- ");
            }

            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);

                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);

                    Console.ForegroundColor = aux;
                }

                Console.Write(" ");
            }



        }
    }
}
