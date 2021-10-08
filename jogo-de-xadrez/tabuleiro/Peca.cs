

namespace tabuleiro
{
    // A peça possui apenas um tabuleiro, porem um tabuleiro contem varias peças
    // Classe generica
    //Sempre que a classe possui ao menos uma função abstrata (que não implementa metodo na propria classe), a classe também deve ser definida como abstrata
    //Uma classe abstrata não pode ser instanciada, apenas herdada
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null; //Toda peça inicia na posição nula
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
            
        }
        public void incrementarQteMovimentos()
        {
            qteMovimentos ++;
        }

        public void decrementarQteMovimentos()
        {
            qteMovimentos--;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    //Verifica se a posição está marcada como "true", caso sim, retorna "true" (que existem movimentos possíveis),
                    //Se esgotar a matriz toda e não retornar nada, signfica que não existem movimentos possiveis, retornando assim "false".
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool movimentoPossivel(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }
        //Metodos abstrato não possui implementção na classe, ele possui somente a definição de sua assinatura,
        //Sua implementação deve ser feita na classe derivada, é um metodo virtual que deve ser implementado usando o modificador override
        public abstract bool[,] movimentosPossiveis();
        
    }
}
