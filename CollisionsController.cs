using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script que controla las colisiones de los objetos
/// </summary>
public class CollisionsController : MonoBehaviour
{

    #region Variables accesibles desde el editor

    public enum TipoObjeto { muro }

    /// <summary>
    /// Tipo de objeto al que pertenece este objeto
    /// </summary>
    public TipoObjeto miTipo;

    /// <summary>
    /// Material que tiene el muro
    /// </summary>
    public Material muro01, muro02, muro03;

    #endregion

    #region Variables privadas

    /// <summary>
    /// Salud máxima del objeto
    /// </summary>
    byte saludMaxima;

    /// <summary>
    /// Salud actual del objeto
    /// </summary>
    byte saludActual;

    #endregion


    /// <summary>
    /// Igualamos la salud actual a la salud máxima
    /// </summary>
    void Start()
    {

        if (miTipo == TipoObjeto.muro) saludActual = saludMaxima = 8;

    }

    /// <summary>
    /// Al colisionar con una bala el objeto pierde vida y se van mostrando los diferentes materiales con el efecto de ruptura
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            saludActual -= 2;

            if (saludActual < 8)
            {
                GetComponent<Renderer>().material = muro01;

                if (saludActual < 6)
                {
                    GetComponent<Renderer>().material = muro02;

                    if (saludActual < 4)
                    {
                        GetComponent<Renderer>().material = muro03;

                        if (saludActual == 0)
                        {
                            Destroy(gameObject);
                        }
                    }
                }
            }


        }
    }
}
