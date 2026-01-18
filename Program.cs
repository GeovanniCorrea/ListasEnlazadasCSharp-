using System;
using ListasEnlazadasCSharp;

namespace ListasEnlazadasCSharp
{
    class Program
    {
        // =========================
        // Función para verificar si un número es primo
        // =========================
        static bool EsPrimo(int numero)
        {
            if (numero <= 1) return false;

            for (int i = 2; i <= Math.Sqrt(numero); i++)
                if (numero % i == 0)
                    return false;

            return true;
        }

        // =========================
        // Función para verificar si un número es Armstrong
        // =========================
        static bool EsArmstrong(int numero)
        {
            int original = numero;
            int suma = 0;
            int digitos = numero.ToString().Length;

            while (numero > 0)
            {
                int digito = numero % 10;
                suma += (int)Math.Pow(digito, digitos);
                numero /= 10;
            }

            return suma == original;
        }

        // =========================
        // Main
        // =========================
        static void Main(string[] args)
        {
            Random random = new Random();

            // ===============================
            // EJERCICIO 1: Lista filtrada por rango
            // ===============================
            Console.WriteLine("=====================================");
            Console.WriteLine("EJERCICIO 1: Lista enlazada con rango");
            Console.WriteLine("=====================================\n");

            ListaEnlazada lista = new ListaEnlazada();

            // Crear 50 números aleatorios entre 1 y 999
            for (int i = 0; i < 50; i++)
            {
                lista.AgregarFinal(random.Next(1, 1000));
            }

            Console.WriteLine("Lista original:");
            lista.Mostrar();

            Console.Write("\nIngrese el valor mínimo del rango: ");
            int minimo = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el valor máximo del rango: ");
            int maximo = int.Parse(Console.ReadLine());

            lista.EliminarFueraDeRango(minimo, maximo);

            Console.WriteLine("\nLista después de eliminar valores fuera del rango:");
            lista.Mostrar();

            Console.WriteLine("\nPresione Enter para continuar al Ejercicio 2...");
            Console.ReadLine();

            // ===============================
            // EJERCICIO 2: Primos y Armstrong
            // ===============================
            Console.WriteLine("\n=====================================");
            Console.WriteLine("EJERCICIO 2: Listas de primos y Armstrong");
            Console.WriteLine("=====================================\n");

            ListaEnlazada listaPrimos = new ListaEnlazada();
            ListaEnlazada listaArmstrong = new ListaEnlazada();

            // Crear 50 números aleatorios y distribuir en listas
            for (int i = 0; i < 50; i++)
            {
                int numero = random.Next(1, 1000);

                if (EsPrimo(numero))
                    listaPrimos.AgregarFinal(numero);

                if (EsArmstrong(numero))
                    listaArmstrong.AgregarInicio(numero);
            }

            int cantidadPrimos = listaPrimos.Contar();
            int cantidadArmstrong = listaArmstrong.Contar();

            Console.WriteLine("Cantidad de números primos: " + cantidadPrimos);
            Console.WriteLine("Cantidad de números Armstrong: " + cantidadArmstrong);

            if (cantidadPrimos > cantidadArmstrong)
                Console.WriteLine("La lista de números primos contiene más elementos.");
            else if (cantidadArmstrong > cantidadPrimos)
                Console.WriteLine("La lista de números Armstrong contiene más elementos.");
            else
                Console.WriteLine("Ambas listas contienen la misma cantidad de elementos.");

            Console.WriteLine("\nLista de números primos:");
            listaPrimos.Mostrar();

            Console.WriteLine("\nLista de números Armstrong:");
            listaArmstrong.Mostrar();

            Console.WriteLine("\nFIN DEL PROGRAMA. Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
