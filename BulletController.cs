using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador de las balas
/// </summary>
public class BulletController : MonoBehaviour {

    #region Variables accesibles en el editor

    /// <summary>
    /// Fuerza del disparo
    /// </summary>
    public float fuerzaDisparo;

    #endregion

    #region Variables privadas

    /// <summary>
    /// Rigidbody de la bala
    /// </summary>
    Rigidbody rb;

    #endregion
        

	/// <summary>
    /// Inicializamos el rigidbody
    /// Añadimos una fuerza a la bala en su forward
    /// Pasados dos segundos se destruye la bala
    /// </summary>
	void Start () {

        //Inicializamos el rigidbody
        rb = GetComponent<Rigidbody>();

        //Añadimos una fuerza a la bala en su forward
        rb.AddForce(transform.forward * fuerzaDisparo, ForceMode.Impulse);

        //Pasados dos segundos se destruye la bala
        Destroy(gameObject, 2);

	}

    /// <summary>
    /// Al colisionar con un objeto la bala se destruye
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
