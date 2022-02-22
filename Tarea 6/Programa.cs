using System;

class Programa
{
    static void Main()
    {
        Console.Title = "Tarea 6";
        char[,] pantalla = new char[24, 80];
        char[] letras = new char[5] { 'A', 'B', 'C', 'D', 'E' };
        Random rand = new Random();

        for(int i=0; i < 24; i++)                                               //filas
        {
            for(int j=0; j < 80; j++)                                           //columnas
            {
                pantalla[i, j] = letras[rand.Next(5)];                          //generador de letras
            }
        }

        int repeticiones = Contar(pantalla);                    
        for(int k=0; k < 24; k++)                   //escribe el resto de la matriz en la que no está la palabra
        {
            for(int l=0; l<80; l++)
            {
                if(pantalla[k, l]!= '0')
                {
                    Console.SetCursorPosition(l, k);
                    Console.Write(pantalla[k, l]);
                }
            }
        }

        Console.WriteLine("\n\nNumero de repeticiones: {0}", repeticiones);         //Resultados
        Console.ReadLine();
    }

    
    
    //Este metodo halla todas las palabras "DECA" en la matriz, las pinta en la consola y las cuenta

    static int Contar(char[,] pantalla)
    {

        int contador=0;
        string palabraH = "";                                      //Variables para idenficar la palabra
        string palabraV = "";

        for(int i=0; i < 24; i++)
        {
            for(int j=0; j < 80; j++)
            {
                if (pantalla[i, j] == 'D')                          //Ubicas las "D" en la matriz
                {
                    if(i<=20 )                                      //descarta que no estén ubicadas en los limites de la matriz
                    {
                        palabraV = "D";
                        for (int k = 1; k <= 3; k++)               //busca que sea la secuencia correcta
                        {
                            palabraV = palabraV + pantalla[i + k, j];
                        }

                        if (palabraV == "DECA")
                        {
                            contador++;
                            Console.ForegroundColor = ConsoleColor.DarkCyan;        //Pinta las palabras
                            for(int l=0; l<=3; l++)
                            {
                                Console.SetCursorPosition(j, i + l);
                                Console.Write(pantalla[i + l,  j]);
                                pantalla[i + l, j] = '0';                       //"elimina" los caracteres
                            }
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }

                    if (j <= 76)                                                //Descarta que no estén en los limites de la matriz
                    {
                        palabraH = "D";
                        for (int k = 1; k <= 3; k++)                            //busca que sea la secuencia correcta
                        {
                            palabraH = palabraH + pantalla[i, j + k];   
                        }

                        if (palabraH == "DECA")
                        {
                            contador++;
                            Console.ForegroundColor = ConsoleColor.DarkCyan;    //Pinta las palabras
                            for (int l = 0; l <= 3; l++)
                            {
                                Console.SetCursorPosition(j + l, i);
                                Console.Write(pantalla[i, j + l]);
                                pantalla[i, j + l] = '0';                   //"elimina" los caracteres
                            }
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                }
            }
        }
        return contador;
    }
}