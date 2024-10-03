using System; // Importa o namespace System, que contém classes fundamentais

class JogoDaVelha // Define a classe principal do jogo
{
    static char[,] tabuleiro = new char[3, 3]; // Declara um tabuleiro 3x3 de caracteres
    static char jogadorAtual = 'X'; // Define o jogador atual, começando com 'X'

    static void Main(string[] args) // Método principal, ponto de entrada do programa
    {
        InicializarTabuleiro(); // Inicializa o tabuleiro com espaços em branco
        while (true) // Loop infinito para o jogo
        {
            MostrarTabuleiro(); // Mostra o estado atual do tabuleiro
            FazerJogada(); // Permite que o jogador atual faça uma jogada
            if (VerificarVencedor()) // Verifica se o jogador atual venceu
            {
                MostrarTabuleiro(); // Mostra o tabuleiro final
                Console.WriteLine($"Jogador {jogadorAtual} venceu!"); // Anuncia o vencedor
                break; // Sai do loop, encerrando o jogo
            }
            if (VerificarEmpate()) // Verifica se houve um empate
            {
                MostrarTabuleiro(); // Mostra o tabuleiro final
                Console.WriteLine("Empate!"); // Anuncia o empate
                break; // Sai do loop, encerrando o jogo
            }
            TrocarJogador(); // Troca para o próximo jogador
        }
    }

    static void InicializarTabuleiro() // Método para inicializar o tabuleiro
    {
        for (int i = 0; i < 3; i++) // Loop para cada linha do tabuleiro
            for (int j = 0; j < 3; j++) // Loop para cada coluna do tabuleiro
                tabuleiro[i, j] = ' '; // Define cada célula como um espaço em branco
    }

    static void MostrarTabuleiro() // Método para mostrar o tabuleiro no console
    {
        Console.Clear(); // Limpa a tela do console
        Console.WriteLine("  0 1 2"); // Exibe os índices das colunas
        for (int i = 0; i < 3; i++) // Loop para cada linha do tabuleiro
        {
            Console.Write(i + " "); // Mostra o índice da linha
            for (int j = 0; j < 3; j++) // Loop para cada coluna da linha
            {
                Console.Write(tabuleiro[i, j]); // Mostra o conteúdo da célula
                if (j < 2) Console.Write("|"); // Adiciona separador entre colunas
            }
            Console.WriteLine(); // Nova linha após cada linha do tabuleiro
            if (i < 2) Console.WriteLine("  -----"); // Adiciona linha horizontal entre linhas
        }
    }

    static void FazerJogada() // Método para permitir que um jogador faça uma jogada
    {
        int linha, coluna; // Declara variáveis para linha e coluna
        while (true) // Loop para garantir jogada válida
        {
            Console.Write($"Jogador {jogadorAtual}, digite a linha e a coluna (ex: 0 1): "); // Solicita entrada do jogador
            var input = Console.ReadLine().Split(' '); // Lê a entrada e divide em linha e coluna
            // Verifica se a entrada é válida
            if (input.Length == 2 && 
                int.TryParse(input[0], out linha) && 
                int.TryParse(input[1], out coluna) && 
                linha >= 0 && linha < 3 && 
                coluna >= 0 && coluna < 3 && 
                tabuleiro[linha, coluna] == ' ')
            {
                tabuleiro[linha, coluna] = jogadorAtual; // Atualiza a célula no tabuleiro
                break; // Sai do loop se a jogada foi válida
            }
            Console.WriteLine("Jogada inválida, tente novamente."); // Mensagem de erro se a jogada for inválida
        }
    }

    static void TrocarJogador() // Método para trocar o jogador atual
    {
        jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X'; // Troca entre 'X' e 'O'
    }

    static bool VerificarVencedor() // Método para verificar se há um vencedor
    {
        for (int i = 0; i < 3; i++) // Loop para verificar linhas e colunas
        {
            // Verifica se todas as células da linha ou coluna têm o mesmo símbolo
            if ((tabuleiro[i, 0] == jogadorAtual && tabuleiro[i, 1] == jogadorAtual && tabuleiro[i, 2] == jogadorAtual) ||
                (tabuleiro[0, i] == jogadorAtual && tabuleiro[1, i] == jogadorAtual && tabuleiro[2, i] == jogadorAtual))
                return true; // Retorna true se houver um vencedor
        }
        // Verifica as diagonais
        return (tabuleiro[0, 0] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 2] == jogadorAtual) ||
               (tabuleiro[0, 2] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 0] == jogadorAtual);
    }

    static bool VerificarEmpate() // Método para verificar se houve um empate
    {
        foreach (var cell in tabuleiro) // Loop por cada célula no tabuleiro
            if (cell == ' ') return false; // Retorna false se encontrar uma célula vazia
        return true; // Retorna true se todas as células estiverem preenchidas
    }
}
