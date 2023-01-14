using System;

public class Nodo
{
    private String Informacion;
    private Nodo Liga;

    /// <summary>
    /// Constructor de la clase Nodo
    /// </summary>
    /// <param name="dato">Variable de tipo string que almacena un valor en el nodo</param>
    public Nodo(String dato)
    {
        this.Datos = dato;
        this.Enlace = null;
    }

    /// <summary>
    /// Propiedad que obtiene y establece el valor del campo Informacion
    /// </summary>
    public String Datos
    {
        get
        {
            return Informacion;
        }

        set
        {
            Informacion = value;
        }
    }

    /// <summary>
    /// Propiedad que obtiene y establece el valor por referencia del nodo Liga
    /// </summary>
    public Nodo Enlace
    {
        get
        {
            return Liga;
        }

        set
        {
            Liga = value;
        }
    }

}