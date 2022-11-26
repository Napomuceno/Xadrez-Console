using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei (Tabuleiro tab, Cor cor) : base (tab, cor)
        {

        }

        public override string ToString()
        {
            return "R";

        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }


        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);

            if(tab.PosicaoValidar(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //Nordeste
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);

            if (tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Direita
            pos.DefinirValores(posicao.Linha , posicao.Coluna + 1);

            if (tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Sudeste
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);

            if (tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Abaixp
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna );

            if (tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //Sudoeste
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);

            if (tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Esquerda
            pos.DefinirValores(posicao.Linha , posicao.Coluna - 1);

            if (tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Noroeste
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);

            if (tab.PosicaoValidar(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}
