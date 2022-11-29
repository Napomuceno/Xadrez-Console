namespace tabuleiro
{
    abstract  class Peca
    {
        public Posicao posicao { get; set; }

        public Cor cor { get; protected set; }

        public int QteMovimentos { get; protected set; }

        public  Tabuleiro tab { get; protected set; }

        public Peca( Tabuleiro tab,Cor cor )
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            QteMovimentos = 0;
            
        }

        public abstract bool[,] MovimentosPossiveis();
       
            
        

        public void IncrementarQteMovimentos()
        {
            QteMovimentos++;
        }


        public void DecrementarQteMovimentos()
        {
            QteMovimentos--;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0;  i<tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if(mat[i,j]== true)
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }
    }
}
