using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    // A peça possui apenas um tabuleiro, porem um tabuleiro contem varias peças
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        //Sobrecarga do metodo peça
        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }
       
        //Funcão que da a posição no tabuleiro / Coloca a peça no tabuleiro
        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe peça nessa posição");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        //Função que retira a peça do tabuleiro
        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null; //Marca a posição da peça como nula
            pecas[pos.linha, pos.coluna] = null; // Marca a posição do tabuleiro onde estava a peça como nula
            return aux; // Retorna a peça
        }
        
        //Metodo que valida se existe uma peça em determinada posição
        public bool existePeca(Posicao pos)
        {

            validarPosicao(pos); // Caso exista algum erro de validação de posição, o metodo (existe peça) é finalizado e é lançada a exceção de erro
            return peca(pos) != null; //Caso seja "true", significa que existe uma peça naquela posição
        }


        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }        
        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }
    }
}

