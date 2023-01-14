using System;

// Estas son listas simplemente ligadas

public class Pruebas_con_listas
{
    private Nodo primero; // creación del primer nodo
    private int cantidad; // variable opcional para controlar la cantidad de nodos en la lista
    private Nodo Auxiliar, Auxiliar2; // nodos auxiliares para el desarrollo de algoritmos

    /// <summary>
    /// Constructor que inicializa las variables de instancia de esta clase
    /// </summary>
    public Pruebas_con_listas()
    {
        this.primero = null; // el primer nodo siempre apuntará a null
        this.Auxiliar = null;
        this.Auxiliar2 = null;
        this.cantidad = 0;
    }

    // Métodos adicionales

    /// <summary>
    /// Compruba si la lista está vacía
    /// </summary>
    public void ListaVacia()
    {
        if (primero == null)
            Console.Write("La lista está vacía."); // aquí también se puede retornar true
        else
            Console.Write("La lista contiene datos.");
    }

    /// <summary>
    /// Determina la cantidad nodos de lista
    /// </summary>
    /// <returns>Devuelve un entero que indica la cantidad de nodos en la lista</returns>
    public int Cantidad()
    {
        return this.cantidad;
    }

    /// <summary>
    /// Recorre la lista de forma iterativa y muestra sus elementos
    /// </summary>
    public void RecorrerIterativo()
    {
        Nodo aux = primero;

        while (aux != null)
        {
            Console.Write("{0}\t", aux.Datos);
            Console.Beep();
            aux = aux.Enlace;
        }
    }

    // Metodos para agregar nodos

    /// <summary>
    /// Ingresa un nodo al incio de la lista
    /// </summary>
    /// <param name="dato">Variable de tipo string que se ingresará en el primer nodo</param>
    public void InsertaInicio(string dato)
    {
        Nodo nuevo = new Nodo(dato);

        nuevo.Enlace = primero;
        primero = nuevo;

        cantidad++;

    }

    /// <summary>
    /// Ingresa un nodo al final de la lista
    /// </summary>
    /// <param name="dato">Variable de tipo string que se ingresará en el último nodo</param>
    public void InsertaFinal(string dato)
    {
        Auxiliar = primero;

        while (Auxiliar.Enlace != null)
            Auxiliar = Auxiliar.Enlace;

        Nodo nuevo = new Nodo(dato);
        nuevo.Enlace = null;
        Auxiliar.Enlace = nuevo;

        cantidad++;

    }

    /// <summary>
    /// Ingresa un nodo antes de un nodo referenciado
    /// </summary>
    /// <param name="dato">Variable de tipo string que se ingresará antes del nodo referenciado</param>
    /// <param name="referencia">Variable de tipo string que representa la referencia a un nodo en lista</param>
    public void Inserta_Antes_X(string dato, string referencia)
    {
        Nodo nuevo = primero;
        int bandera = 1;

        while (nuevo.Datos != referencia && bandera == 1) // para buscar la referencia en la lista, si la encuetra bandera será 1 de lo contrario será 0.
        {
            if (nuevo.Enlace != null)
            {
                Auxiliar = nuevo;
                nuevo = nuevo.Enlace;
            }
            else
                bandera = 0;
        }

        if (bandera == 1)
        {
            Nodo nuevo_x = new Nodo(dato);

            if (primero == nuevo) // para verificar si el nodo dado como referencia es el primero
            {
                nuevo.Enlace = primero;
                primero = nuevo;
            }
            else
            {
                Auxiliar.Enlace = nuevo_x;
                nuevo_x.Enlace = nuevo; // el nuevo nodo ingresado apuntará el nuevo nodo que tiene la referencia
            }
        }
        else
            Console.Write("\n\nEl nodo dado como referencia no se encuentra en la lista\n\n");

        cantidad++;
    }

    /// <summary>
    /// Ingresa un nodo después de un nodo referenciado
    /// </summary>
    /// <param name="dato">Variable de tipo string que se ingresará después del nodo referenciado</param>
    /// <param name="referencia">Variable de tipo string que representa la referencia a un nodo en lista</param>
    public void Inserta_Despues_X(string dato, string referencia)
    {
        Nodo nuevo = primero;
        int bandera = 1;

        while (nuevo.Datos != referencia && bandera == 1)
        {
            if (nuevo.Enlace != null)
                nuevo = nuevo.Enlace;
            else
                bandera = 0;
        }

        if (bandera == 1) // si se encuentra esa referencia en la lista
        {
            Nodo nuevo_x = new Nodo(dato);
            nuevo_x.Enlace = nuevo.Enlace; // copio la referencia en memoria de nuevo a nuevo_x
            nuevo.Enlace = nuevo_x; // poner nuevo_x delante de nuevo
        }

        cantidad++;
    }

    // Métodos para eliminar nodos

    /// <summary>
    /// Elimina el primer elemento de la lista
    /// </summary>
    public void Eliminar_Primero()
    {
        Nodo nuevo = primero;
        primero = nuevo.Enlace;
        nuevo = null;
        cantidad--;
    }

    /// <summary>
    /// Elimina el último de la lista
    /// </summary>
    public void Eliminar_Ultimo()
    {
        Nodo nuevo = primero;

        if (primero.Enlace == null)
            primero = null;
        else
        {
            while (nuevo.Enlace != null)
            {
                Auxiliar = nuevo;
                nuevo = nuevo.Enlace;
            }
        }

        Auxiliar.Enlace = null; // aquí se establece el último como null
        cantidad--;
    }

    /// <summary>
    /// Elimina el elemento especificado como referencia
    /// </summary>
    /// <param name="referencia">Variable de tipo string la cual representa el nodo a eliminar</param>
    public void Eliminar_En_X(string referencia)
    {
        Nodo nuevo = primero;
        int bandera = 1;
        while (nuevo.Datos != referencia && bandera == 1)
        {
            if (nuevo.Enlace != null)
            {
                Auxiliar = nuevo;
                nuevo = nuevo.Enlace;
            }
            else
                bandera = 0;
        }

        if (bandera == 0)
            Console.Write("\n\nNo se encontró la referencia para eliminar\n\n");
        else
        {
            if (primero == nuevo)
                primero = nuevo.Enlace;
            else
            {
                Auxiliar.Enlace = nuevo.Enlace;
            }
        }

        nuevo = null;
        cantidad--;
    }

    /// <summary>
    /// Elimina un nodo anterior a una referencia dada
    /// </summary>
    /// <param name="referencia">Variable de tipo string la cual representa al nodo anterior a eliminar</param>
    public void Eliminar_Antes_X(string referencia)
    {
        if (primero.Datos == referencia)
            Console.Write("No existe un nodo que preceda a este, porque es el primero.");
        else
        {
            Nodo nuevo = primero;
            Auxiliar = primero;
            int bandera = 1;

            while (nuevo.Datos != referencia && bandera == 1)
            {
                if (nuevo.Enlace != null)
                {
                    Auxiliar2 = Auxiliar;
                    Auxiliar = nuevo;
                    nuevo = nuevo.Enlace;
                }
                else
                    bandera = 0;
            }

            if (bandera == 0)
                Console.Write("No se encontró el elemento referenciado.");
            else
            {
                if (primero.Enlace == nuevo) // esto es para eliminar el primer nodo
                    primero = nuevo;
                else
                    Auxiliar2.Enlace = nuevo;
            }

            Auxiliar = null;
        }

        cantidad--;
    }

    /// <summary>
    /// Elimina un elemento después de una referencia dada
    /// </summary>
    /// <param name="referencia">Variable de tipo string la cual representa al nodo anterior a eliminar</param>
    public void Eliminar_Despues_X(string referencia)
    {
        if (primero.Datos == referencia && primero.Enlace == null) // cuando solo hay un elemento
            Console.Write("Solo hay un nodo, no hay ninguno posterior a él.");
        else
        {
            Nodo nuevo = primero;
            while (nuevo.Datos != referencia)
            {
                if (nuevo.Enlace != null)
                {
                    nuevo = nuevo.Enlace;
                    Auxiliar = nuevo;
                    Auxiliar2 = Auxiliar.Enlace;
                }
            }

            if (primero.Datos == referencia) // se seleccionó al primero como referencia
            {
                Auxiliar2 = nuevo.Enlace;
                primero.Enlace = Auxiliar2.Enlace;
                cantidad--;
            }
            else
            {
                if (Auxiliar2 == null) // se seleccionó al último como referencia
                    Console.Write("No se puede establecer al último nodo como una referencia");
                else  // se seleccionó al cualquier nodo intermedio
                {
                    Auxiliar.Enlace = Auxiliar2.Enlace;
                    cantidad--;
                }
            }

            Auxiliar2 = null;
        }

        
    }

    // Algoritmos de búsqueda


    public void Busqueda_Desordenada(string elemento)
    {
        Nodo nuevo = primero;

        while (nuevo != null && nuevo.Datos != elemento)
            nuevo = nuevo.Enlace;

        if (nuevo == null)
            Console.Write("\nEl elemento no se encuentra \"{0}\" en la lista\n", elemento);
        else
            Console.Write("\nEl elemento si se encuentra \"{0}\" en la lista\n", elemento);
    }

    // Busqueda_ordenada

    public void Busqueda_Recursiva(Nodo siguiente, string elemento)
    {
        if (primero != null)
        {
            if (primero.Datos == elemento)
                Console.Write("\nEl elemento {0} sí se encuentra en la lista\n", elemento);
            else
                Busqueda_Recursiva(primero.Enlace, elemento);
        }
        else
            Console.Write("\nEl elemento {0} no se encuentra en la lista\n", elemento);
    }

    public static void Main(string[] args)
    {
        Console.Title = "Prueba con listas";
        Console.SetWindowSize(160, 50);

        Pruebas_con_listas lista = new Pruebas_con_listas();

        // Insertando al inicio

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Inserciones al inicio:");
        Console.Write("\n\n");
        lista.InsertaInicio("Wilmer");
        lista.InsertaInicio("Jose");
        lista.InsertaInicio("Palacios");
        lista.InsertaInicio("López");
        lista.RecorrerIterativo();
        Console.Write("\n\n");

        Console.Write("Hay {0} elementos en la lista actualmente.", lista.Cantidad());
        Console.Write("\n\n");

        lista.ListaVacia();

        Console.Write("\n\n");

        //Insertando al final

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Inserciones al final:");
        Console.Write("\n\n");
        lista.InsertaFinal("John");
        lista.InsertaFinal("Paul");
        lista.InsertaFinal("Ringo");
        lista.InsertaFinal("George");
        lista.RecorrerIterativo();
        Console.Write("\n\n");

        Console.Write("Hay {0} elementos en la lista actualmente.", lista.Cantidad());
        Console.Write("\n\n");

        lista.ListaVacia();

        Console.Write("\n\n");

        // Insertando antes de un nodo X dado por referencia.
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Inserciones antes de un nodo X:");

        Console.Write("\n\n");
        Console.Write("Insertando el elemento \"Maiden\" antes de \"Ringo\". \n\n");
        lista.Inserta_Antes_X("Maiden", "Ringo");
        lista.RecorrerIterativo();

        Console.Write("\n\n");
        Console.Write("Insertando el elemento \"Nirvana\" antes de \"John\". \n\n");
        lista.Inserta_Antes_X("Nirvana", "John");
        lista.RecorrerIterativo();

        Console.Write("\n\n");
        Console.Write("Hay {0} elementos en la lista actualmente.", lista.Cantidad());
        Console.Write("\n\n");

        // Insertando despues de un nodo X dado por referencia

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Inserciones despues de un nodo X:");

        Console.Write("\n\n");
        Console.Write("Insertando el elemento \"MANAGUA\" después de \"Palacios\". \n\n");
        lista.Inserta_Despues_X("MANAGUA", "Palacios");
        lista.RecorrerIterativo();

        Console.Write("\n\n");
        Console.Write("Insertando el elemento \"BLUEFIELDS\" después de \"Nirvana\". \n\n");
        lista.Inserta_Despues_X("BLUEFIELDS", "Nirvana");
        lista.RecorrerIterativo();

        Console.Write("\n\n");
        Console.Write("Hay {0} elementos en la lista actualmente.", lista.Cantidad());
        Console.Write("\n\n");

        // Para eliminar el primer elemento de la lista

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("\n\n");
        Console.Write("Se ha eliminado el primer elemento");
        Console.Write("\n\n");
        lista.Eliminar_Primero();
        lista.RecorrerIterativo();

        Console.Write("\n\n");
        Console.Write("Hay {0} elementos en la lista actualmente.", lista.Cantidad());
        Console.Write("\n\n");

        // Para eliminar el último elemento de la lista
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("\n\n");
        Console.Write("Se ha eliminado el último elemento");
        Console.Write("\n\n");
        lista.Eliminar_Ultimo();
        lista.RecorrerIterativo();

        Console.Write("\n\n");
        Console.Write("Hay {0} elementos en la lista actualmente.", lista.Cantidad());
        Console.Write("\n\n");

        // Para eliminar un valor x de la lista
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("\n\n");
        Console.Write("Se ha eliminado el elemento \"Wilmer\" de la lista");
        Console.Write("\n\n");
        lista.Eliminar_En_X("Wilmer");
        lista.RecorrerIterativo();

        Console.Write("\n\n");
        Console.Write("Hay {0} elementos en la lista actualmente.", lista.Cantidad());
        Console.Write("\n\n");

        // Para eliminar un valor anterior a un nodo referenciado
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("\n\n");
        Console.Write("Se ha eliminado el elemento anterior a \"John\" de la lista");
        Console.Write("\n\n");
        lista.Eliminar_Antes_X("John");
        lista.RecorrerIterativo();

        Console.Write("\n\n");
        Console.Write("Hay {0} elementos en la lista actualmente.", lista.Cantidad());
        Console.Write("\n\n");
         
        // Para eliminar un valor posterior a un nodo referenciado
        
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\n\n");
        Console.Write("Se ha eliminado el elemento posterior a \"Palacios\" de la lista");
        Console.Write("\n\n");
        lista.Eliminar_Despues_X("Palacios");
        Console.Write("\n\n");
        lista.RecorrerIterativo();

        Console.Write("\n\n");
        Console.Write("Hay {0} elementos en la lista actualmente.", lista.Cantidad());
        Console.Write("\n\n");
        
        // Para realizar una búsqueda desordenada

        lista.Busqueda_Desordenada("Nirvana");
        Console.Write("\n\n");

        lista.Busqueda_Desordenada("Toño");
        Console.Write("\n\n");


        // Para realizar búsqueda recursiva

        lista.Busqueda_Recursiva(lista.primero, "Palacios");
        lista.Busqueda_Recursiva(lista.primero, "Albertiño");

        Console.ReadKey();

    }
}