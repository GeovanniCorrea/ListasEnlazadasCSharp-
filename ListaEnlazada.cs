using System;

namespace ListasEnlazadasCSharp
{
    public class ListaEnlazada
    {
        private Nodo cabeza;

        public ListaEnlazada()
        {
            cabeza = null;
        }

        public void AgregarInicio(int dato)
        {
            Nodo nuevo = new Nodo(dato);
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
        }

        public void AgregarFinal(int dato)
        {
            Nodo nuevo = new Nodo(dato);

            if (cabeza == null)
            {
                cabeza = nuevo;
                return;
            }

            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = nuevo;
        }

        public int Contar()
        {
            int contador = 0;
            Nodo actual = cabeza;

            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }

            return contador;
        }

        public void Mostrar()
        {
            Nodo actual = cabeza;

            while (actual != null)
            {
                Console.Write(actual.Dato + " -> ");
                actual = actual.Siguiente;
            }

            Console.WriteLine("null");
        }

        public void EliminarFueraDeRango(int minimo, int maximo)
        {
            while (cabeza != null && (cabeza.Dato < minimo || cabeza.Dato > maximo))
            {
                cabeza = cabeza.Siguiente;
            }

            Nodo actual = cabeza;

            while (actual != null && actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato < minimo || actual.Siguiente.Dato > maximo)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                }
                else
                {
                    actual = actual.Siguiente;
                }
            }
        }
    }
}
