namespace Compilador
{
    public static class Regexs
    {
        //regex para string
        public static string letras = @"[a-zA-Z|_]";

        //regex para separadores string
        public static char aspas = '"';
        public static string stringSep = @$"[\s|/|*|+|\-|(|)|%|=|;|[|,|<|>|\]|'|-|{aspas}]";

        //regex para verificar string

        public static string stringVali = @"^[a-z|A-Z|_][a-zA-Z|1-9|_]*$";

        //regex para numeros
        public static string numeros = @"[0-9]";

        //regex para separadores de numeros
        public static string numeroSep = @"[\s|/|*|+|-|(|)|%|=|;|,]";

        //regex para verificar float
        public static string floatVali = @"^[1-9]+\.[1-9]*$";

        //regex para verificar float
        public static string intVali = @"^[0-9]+$";

        //regex para operadores aritimeticos
        public static string aritimetico = @"[*|/|%|+|=|-|(|)|[|]|{|}|,]";

        //regex para separadores de operadores aritimeticos
        public static string aritiSep = @"[a-zA-Z|\s|(|)]";

        //regex para operadores expeciais
        public static string expeciais = @"[/|+|-|=|>|<]";

        //regex para separadores de operadores aritimeticos
        public static string expeciaisSep = @"[\s]";

        //regex para separadores de operadores aritimeticos duplos
        public static string operador_duplo_sep = @"[\s|a-zA-Z|_|(|)|;|1-9]";

    }
}