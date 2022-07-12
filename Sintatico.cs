namespace Compilador
{
    public class Sintatico
    {
        public static void Run()
        {
            List<Variaveis> variaveis = new List<Variaveis>();
            Queue<Token> filaToken = new Queue<Token>(Token.tokens);

            Token token;
            int flag = 0;
            int flag2 = 0;
            int contadorTemp = 0;
            Token dequeue()
            {
                try
                {
                    return filaToken.Dequeue();
                }
                catch (Exception)
                {
                    return new Token(0, 0, "", "");
                }
            }

            token = dequeue();
            codigo();


            void codigo()
            {
                flag2 = 1;
                if (token.Tipo == "Variavel ")
                {
                    foreach (var item in variaveis)
                    {
                        if (item.Nome == token.Nome)
                        {
                            flag2 = 0;
                            break;
                        }

                    }
                    if (flag2 == 1)
                    {
                        throw new Exception("A variavel " + token.Nome + " não foi declarada");
                    }

                    //System.Console.WriteLine("atribuicao");
                    atribuicao();
                    if (token.Nome == ";")
                    {
                        token = dequeue();
                        codigo();
                    }
                    else
                    {
                        //  throw new Exception("Era esperado ; no final da linha " + (token.Linha - 1));
                        System.Console.WriteLine("Era esperado ; no final da linha " + (token.Linha - 1));
                        codigo();
                    }
                }
                else if (token.Tipo == "Tipo")
                {
                    //System.Console.WriteLine("declaracao");
                    declaracao();
                    if (token.Nome == ";")
                    {
                        token = dequeue();
                        codigo();
                    }
                    else
                    {
                        System.Console.WriteLine("Era esperado ; no final da linha " + (token.Linha - 1));
                        codigo();
                    }

                }
                else if (token.Tipo == "Palavra reservada for")
                {
                    //System.Console.WriteLine("repeticao");
                    repeticao();
                    codigo();
                }
                else if (token.Tipo == "Palavra reservada if")
                {
                    //System.Console.WriteLine("decisao");
                    decisao();
                    codigo();
                }
                else if (token.Nome == "{")
                {
                    //System.Console.WriteLine("bloco");
                    bloco();
                    codigo();

                }

            }


            void atribuicao()
            {
                token = dequeue();
                if (token.Nome == "=")
                {
                    //System.Console.WriteLine("espracao");
                    token = dequeue();
                    esprecao();
                }
                else
                {
                    // //System.Console.WriteLine("erro");
                    //erro
                }
                //   token = dequeue();
                if (token.Nome != ";")
                {
                    //erro
                }
            }
            void declaracao()
            {
                if (flag == 1)
                {
                    variaveis.Add(new Variaveis(variaveis[variaveis.Count - 1].Tipo));
                    flag = 0;
                }
                else
                {

                    variaveis.Add(new Variaveis(token.Nome));
                }
                token = dequeue();
                if (token.Tipo == "Variavel ")
                {
                    foreach (var item in variaveis)
                    {
                        if (item.Nome == token.Nome)
                        {
                            throw new Exception("A variavel " + token.Nome + " ja foi declarada 2 vezes");

                        }
                    }
                    variaveis[variaveis.Count - 1].Nome = token.Nome;
                    //System.Console.WriteLine("atribuicao");
                    atribuicao();
                }
                else
                {
                    System.Console.WriteLine("Era esperado Variavel na " + token.Linha + " e coluna " + token.Coluna);

                }
                if (token.Nome == ",")
                {
                    flag = 1;
                    //System.Console.WriteLine("declaracao");
                    declaracao();
                }
                else if (token.Tipo == "Variavel ")
                {
                    throw new Exception("Era esperado , na " + token.Linha + " e coluna " + token.Coluna);
                }



            }
            void decisao()
            {
                token = dequeue();
                if (token.Nome == "(")
                {
                    token = dequeue();
                    esprecaologica();
                }
                else
                {
                    System.Console.WriteLine("Era esperado ( na " + token.Linha + " e coluna " + token.Coluna);
                }
                if (token.Nome == ")")
                {
                    token = dequeue();
                    if (token.Nome == "{")
                    {

                        //System.Console.WriteLine("bloco");
                        bloco();
                    }
                    else
                    {
                        throw new Exception("Esprecao invalida na linha " + token.Linha);
                    }

                }
                else
                {
                    System.Console.WriteLine("Era esperado ) na " + token.Linha + " e coluna " + token.Coluna);
                }
                if (token.Tipo == "Palavra reservada else")
                {
                    token = dequeue();
                    if (token.Nome == "{")
                    {

                        //System.Console.WriteLine("bloco");
                        bloco();
                    }
                    else
                    {
                        System.Console.WriteLine("Era esperado { na " + token.Linha + " e coluna " + token.Coluna);
                    }
                }

            }

            void repeticao()
            {
                token = dequeue();
                if (token.Nome == "(")
                {
                    token = dequeue();
                    if (token.Tipo == "Tipo")
                    {
                        //System.Console.WriteLine("declaracao");
                        declaracao();
                    }
                    else if (token.Tipo == "Variavel ")
                    {
                        //System.Console.WriteLine("atribuicao");
                        atribuicao();
                    }
                    else if (token.Tipo == "")
                    {
                        ////ok
                    }
                    else
                    {
                        System.Console.WriteLine("Esprecao invalida na linha " + token.Linha + " e coluna " + token.Coluna);
                    }

                    if (token.Nome == ";")
                    {
                        //System.Console.WriteLine("esprecaologica");
                        token = dequeue();
                        esprecaologica();
                    }
                    else
                    {
                        throw new Exception("Era esperado ; na " + token.Linha + " e coluna " + token.Coluna);
                        //System.Console.WriteLine("Era esperado ; na " + token.Linha + " e coluna " + token.Coluna);
                    }

                    if (token.Nome == ";")
                    {
                        //System.Console.WriteLine("incremento");
                        token = dequeue();
                        atribuicao();
                    }
                    else
                    {
                        System.Console.WriteLine("Era esperado ; na " + token.Linha + " e coluna " + token.Coluna);
                    }

                    if (token.Nome == ")")
                    {
                        token = dequeue();
                        if (token.Nome == "{")
                        {

                            //System.Console.WriteLine("bloco");
                            bloco();
                        }
                        else
                        {
                            System.Console.WriteLine("Era esperado { na " + token.Linha + " e coluna " + token.Coluna);
                        }

                    }
                    else
                    {
                        throw new Exception("Esprecao invalida na linha " + token.Linha);
                    }


                }
                else
                {
                    System.Console.WriteLine("Era esperado ( na " + token.Linha + " e coluna " + token.Coluna);
                }

            }

            void bloco()
            {
                token = dequeue();
                codigo();
                if (token.Nome == "}")
                {
                    ////ok 
                    token = dequeue();
                }
                else
                {
                    System.Console.WriteLine("Era esperado } na " + token.Linha + " e coluna " + token.Coluna);

                }
            }
            void esprecaologica()
            {
                //System.Console.WriteLine("esprecao");
                esprecao();
                if (token.Nome == ">" || token.Nome == "<" || token.Nome == "==" || token.Nome == ">=" || token.Nome == "<=")
                {
                    //System.Console.WriteLine("esprecao");
                    token = dequeue();
                    esprecao();
                }
                if (token.Nome == "&&" || token.Nome == "!!")
                {
                    //System.Console.WriteLine("esprecaologica");
                    token = dequeue();
                    esprecaologica();
                }

            }
            void esprecao()
            {
                if (token.Nome == "(" || token.Tipo == "Variavel " || token.Tipo == "Numeral int " || token.Tipo == "Numeral float ")
                {
                    if (token.Tipo == "Numeral int ")
                    {
                        var op1 = T();
                        //System.Console.WriteLine("Elinha");
                        var x = Elinha();
                        if (x.Length > 0 && x.Substring(0, 1) == "+")
                        {
                            System.Console.WriteLine("add VarTemp" + contadorTemp++ + " " + op1 + ", " + x.Substring(2, x.Length - 2));
                        }
                        if (x.Length > 0 && x.Substring(0, 1) == "-")
                        {
                            System.Console.WriteLine("sub VarTemp" + contadorTemp++ + " " + op1 + ", " + x.Substring(2, x.Length - 2));
                        }
                    }
                    else
                    {
                        //System.Console.WriteLine("T");
                        T();
                        //System.Console.WriteLine("Elinha");
                        Elinha();
                    }
                }

            }

            string T()
            {
                if (token.Nome == "(" || token.Tipo == "Variavel " || token.Tipo == "Numeral int " || token.Tipo == "Numeral float ")
                {
                    //System.Console.WriteLine("F");
                    var op1 = F();
                    //System.Console.WriteLine("Tlinha");
                    string x = Tlinha();
                    if (x.Length > 0 && x.Substring(0, 1) == "*")
                    {
                        System.Console.WriteLine("mul VarTemp" + contadorTemp++ + " " + op1 + ", " + x.Substring(2, x.Length - 2));
                    }
                    if (x.Length > 0 && x.Substring(0, 1) == "/")
                    {
                        System.Console.WriteLine("div VarTemp" + contadorTemp++ + " " + op1 + ", " + x.Substring(2, x.Length - 2));
                    }
                    return op1;
                }
                else
                {
                    throw new Exception("Esprecao invalida na linha " + token.Linha + " e coluna " + token.Coluna);

                }
            }
            string F()
            {
                if (token.Nome == "(")
                {
                    token = dequeue();
                    esprecao();
                    if (token.Nome == ")")
                    {
                        ////ok
                        token = dequeue();
                        return ""; // ver depois 
                    }
                    else
                    {
                        throw new Exception("Esprecao invalida na linha " + token.Linha);
                    }

                }
                else if (token.Tipo == "Variavel " || token.Tipo == "Numeral int " || token.Tipo == "Numeral float ")
                {
                    if (token.Tipo == "Numeral int ")
                    {
                        var temp = token;
                        token = dequeue();
                        return temp.Nome;
                    }
                    token = dequeue();
                    return ""; // ver depois 
                    ////ok
                }
                return ""; // ver depois 

            }

            string Elinha()
            {
                if (token.Nome == "+")
                {
                    token = dequeue();
                    //System.Console.WriteLine("Tlinha");
                    var op1 = T();
                    //System.Console.WriteLine("Elinha");
                    Elinha();
                    return "+ " + op1;
                }
                else if (token.Nome == "-")
                {
                    token = dequeue();
                    //System.Console.WriteLine("Tlinha");
                    var op1 = T();
                    //System.Console.WriteLine("Elinha");
                    Elinha();
                    return "- " + op1;
                }
                return "";
            }

            string Tlinha()
            {
                if (token.Nome == "*")
                {
                    token = dequeue();
                    //System.Console.WriteLine("F");
                    var op1 = F();
                    //System.Console.WriteLine("Tlinha");
                    Tlinha();
                    return "* " + op1;
                }
                else if (token.Nome == "/")
                {
                    token = dequeue();
                    //System.Console.WriteLine("F");
                    var op1 = F();
                    //System.Console.WriteLine("Tlinha");
                    Tlinha();
                    return "/ " + op1;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}