namespace Compilador
{
    public static class Reservadas
    {

        public static Dictionary<string, string> palavras = new Dictionary<string, string>()
            {
                { "int", "Palavra reservada int"},
                { "float", "Palavra reservada int"},
                { "char", "Palavra reservada char"},
                { "break", "Palavra reservada break"},
                { "do", "Palavra reservada do"},
                { "else", "Palavra reservada else"},
                { "for", "Palavra reservada for"},
                { "while", "Palavra reservada while"},
                { "double", "Palavra reservada double"},
                { "if", "Palavra reservada if"}
            };

        public static Dictionary<string, string> operadores = new Dictionary<string, string>()
            {
                { "-", "Operador aritimedico -"},
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
                { ",", "Separdor ,"}
            };
    }
}