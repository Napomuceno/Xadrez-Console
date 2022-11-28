using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;




        public PartidaDeXadrez()
        {
            Tab =  new Tabuleiro (8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPeca();
                   

        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);

            p.IncrementarQteMovimentos();

            Peca PecaCapturada = Tab.RetirarPeca(destino);

            Tab.ColocarPeca(p, destino);

            if (PecaCapturada != null)
            {
                capturadas.Add(PecaCapturada);
            }

        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }


        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if(Tab.peca(pos)== null)
            {
                throw new TabueleiroException("Não existe peca na posição de origem escolhida!");
            }
            if(JogadorAtual != Tab.peca(pos).cor)
            {
                throw new TabueleiroException("A peca de origem escolhida não é sua!");
            }
            if (!Tab.peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabueleiroException("Não a movimentos possiveis para a  peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestido(Posicao origem, Posicao destino)
        {
            if (!Tab.peca(origem).PodeMoverPara(destino))
            {
                throw new TabueleiroException("Posicao de destino invalida!");
            }
        }

        private void MudarJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }

            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }


        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        private void ColocarPeca()
        {
            colocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            colocarNovaPeca('c', 2,new Torre(Tab, Cor.Branca));
            colocarNovaPeca('d', 2,new Torre(Tab, Cor.Branca));
            colocarNovaPeca('e', 2,new Torre(Tab, Cor.Branca));
            colocarNovaPeca('e', 1,new Torre(Tab, Cor.Branca));
            colocarNovaPeca('d', 1,new Rei(Tab, Cor.Branca));


            colocarNovaPeca('c', 7,new Torre(Tab, Cor.Preta));
            colocarNovaPeca('c', 8,new Torre(Tab, Cor.Preta));
            colocarNovaPeca('d', 7,new Torre(Tab, Cor.Preta));
            colocarNovaPeca('e', 7,new Torre(Tab, Cor.Preta));
            colocarNovaPeca('e', 8,new Torre(Tab, Cor.Preta));
            colocarNovaPeca('d', 8,new Rei(Tab, Cor.Preta));


        }
    }
}
