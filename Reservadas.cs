
namespace Compilador
{
    public static class Reservadas
    {

        public static Dictionary<string, string> palavras = new Dictionary<string, string>()
            {
                { "int", "Tipo"},
                { "float", "Tipo"},
                { "char", "Tipo"},
                { "double", "Tipo"},
                { "break", "Palavra reservada break"},
                { "do", "Palavra reservada do"},
                { "else", "Palavra reservada else"},
                { "for", "Palavra reservada for"},
                { "while", "Palavra reservada while"},
                { "if", "Palavra reservada if"}
            };

        public static Dictionary<string, string> operadores = new Dictionary<string, string>()
            {
                { "-", "Operador aritimedico -"},
                { ">", "Operador logico >"},
                { "<", "Operador logico <"},
                { "*", "Operador aritimedico *"},
                { "+", "Operador aritimedico +"},
                { "=", "atribuição ="},
                { "%", "Operador aritimedico %"},
                { "/", "Operador aritimedico /"},
                { "(", "Separador ("},
                { ")", "Separdor )"},
                { "[", "Separador ["},
                { "]", "Separdor ]"},
                { "{", "Separdor {"},
                { "}", "Separador }"},
                { ";", "Separador ;"},
                { ",", "Separdor ,"}
            };
    }
}