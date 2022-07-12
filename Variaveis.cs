namespace Compilador
{
    public class Variaveis
    {
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public bool Inicialisada { get; set; }

        public Variaveis(string tipo)
        {
            Tipo = tipo;
        }
    }
}