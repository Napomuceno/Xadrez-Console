using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {


        private PartidaDeXadrez partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";

        }


        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }


        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

           if(cor == Cor.Branca)
            {
                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);
                if(tab.PosicaoValidar(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha - 2, posicao.Coluna);
                if (tab.PosicaoValidar(pos) && livre(pos) && QteMovimentos ==0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);
                if (tab.PosicaoValidar(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna +1);
                if (tab.PosicaoValidar(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // #Jogadaespecial  en passant
                if (posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    if (tab.PosicaoValidar(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.VulneravelEnPassant )
                    {
                        mat[esquerda.Linha -1 , esquerda.Coluna] = true;
                    }
                    Posicao direta = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    if (tab.PosicaoValidar(direta) && existeInimigo(direta) && tab.peca(direta) == partida.VulneravelEnPassant)
                    {
                        mat[direta.Linha -1, direta.Coluna] = true;
                    }

                }


            }

            else
            {
                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
                if (tab.PosicaoValidar(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha + 2, posicao.Coluna);
                if (tab.PosicaoValidar(pos) && livre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
                if (tab.PosicaoValidar(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
                if (tab.PosicaoValidar(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }


                // #Jogadaespecial  en passant
                if (posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    if (tab.PosicaoValidar(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direta = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    if (tab.PosicaoValidar(direta) && existeInimigo(direta) && tab.peca(direta) == partida.VulneravelEnPassant)
                    {
                        mat[direta.Linha + 1, direta.Coluna] = true;
                    }

                }

            }



            return mat;


        }
    }
}
