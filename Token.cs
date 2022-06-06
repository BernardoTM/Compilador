namespace Compilador
{
    public class Token
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }

        public Token(int linha, int coluna, string tipo, string nome)
        {
            Linha = linha + 1;
            Coluna = coluna;
            Tipo = tipo;
            Nome = nome;
        }

        public virtual void ImprimeToken()
        {
            System.Console.WriteLine(Linha + "   | " + Coluna + "   | " + Nome + "   | " + Tipo);
        }
        public static System.Collections.Generic.List<Token> tokens = new List<Token>();

    }
}