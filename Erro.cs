namespace Compilador
{
    public class Erro : Token
    {
        public Erro(int linha, int coluna, string tipo, string nome)
        : base(linha, coluna, tipo, nome)
        {
        }
        public override void ImprimeToken()
        {
            System.Console.WriteLine($"{Tipo} na linha {Linha} e coluna {Coluna} => {Nome}");
        }
    }
}