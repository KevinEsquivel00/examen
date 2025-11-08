using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class Program
    {

        private static Dictionary<int, long> _fibMemo = new Dictionary<int, long> { { 0, 0 }, { 1, 1 } };

        static void Main(string[] args)
        {
            String Nombre = "Kevin Francisco Esquivel Perez";
            String Carne = "1790-25-13768";
            String DPI = "3087 72547 0608";
            DateTime FechaNacimiento = new DateTime(2007, 04, 11);

            bool continuar = true;
            while (continuar)
            {

                Console.WriteLine("Selecciona una opcion ");
                Console.WriteLine("1. Mostrar Nombre Completo");
                Console.WriteLine("2. Mostrar Numero de Carne");
                Console.WriteLine("3. Mostrar Numero de DPI");
                Console.WriteLine("4. Mostrar Fecha de Nacimiento");
                Console.WriteLine("5. Calcular Serie de Fibonacci");
                Console.WriteLine("6. Salir");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\nNombre Completo: " + Nombre);
                        break;
                    case 2:
                        Console.WriteLine("\nNumero de Carne: " + Carne);
                        break;
                    case 3:
                        Console.WriteLine("\nNumero de DPI: " + DPI);
                        break;
                    case 4:
                        Console.WriteLine("\nFecha de Nacimiento: " + FechaNacimiento.ToShortDateString());
                        break;
                    case 5:
                        int n = SolicitarEnteroPositivo();
                        Console.Write("\nSerie de Fibonacci: ");
                        for (int i = 0; i < n; i++)
                        {
                            if (i > 0) Console.Write(" ");
                            Console.Write(Fibonacci(i));
                        }
                        Console.WriteLine();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }
                if (continuar && opcion != 6)
                {

                    if (!SolicitarContinuar())
                    {
                        Console.WriteLine("Saliendo del programa...");
                        continuar = false;
                    }
                }
            }
        }


        public static void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Selecciona una opcion ");
            Console.WriteLine("1. Mostrar Nombre Completo");
            Console.WriteLine("2. Mostrar Numero de Carne");
            Console.WriteLine("3. Mostrar Numero de DPI");
            Console.WriteLine("4. Mostrar Fecha de Nacimiento");
            Console.WriteLine("5. Calcular Serie de Fibonacci");
            Console.WriteLine("6. Salir\n");
        }

    public static int SolicitarOpcion()
        {
            int opcion;
            while (true)
            {
                Console.Write("Ingrese una opcion (1-6): ");
                string entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out opcion) || opcion < 1 || opcion > 6)
                {
                    Console.WriteLine("Opcion inválida. Por favor ingrese un número entre 1 y 6.");
                    continue;
                }
                break;
            }
            return opcion;
        }

    public static bool SolicitarContinuar()
        {
            while (true)
            {
                Console.Write("\n¿Desea continuar? (S/N): ");
                string entrada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada)) continue;
                entrada = entrada.Trim().ToUpperInvariant();
                if (entrada == "S" || entrada == "SI")
                    return true;
                if (entrada == "N" || entrada == "NO")
                    return false;
                Console.WriteLine("Respuesta no reconocida. Responda 'S' para sí o 'N' para no.");
            }
        }

    public static int SolicitarEnteroPositivo()
        {
            Console.WriteLine("Ingrese el numero de terminos para la serie de Fibonacci (entero positivo):");
            int valor;
            while (true)
            {
                string entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out valor) || valor <= 0)
                {
                    Console.WriteLine("Valor inválido. Introduce un entero positivo:");
                    continue;
                }

                if (valor > 92)
                {
                    Console.WriteLine("El valor es demasiado grande para representarse en 'long'. Introduce un valor menor o igual a 92:");
                    continue;
                }
                break;
            }
            return valor;
        }


    public static long Fibonacci(int n)
        {
            if (_fibMemo.ContainsKey(n)) return _fibMemo[n];
            long resultado = Fibonacci(n - 1) + Fibonacci(n - 2);
            _fibMemo[n] = resultado;
            return resultado;
        }
    }


