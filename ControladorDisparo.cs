using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador del disparo
/// </summary>
public class ControladorDisparo : MonoBehaviour {

    #region Variables accesibles desde el editor
    
    /// <summary>
    /// Prefab de la bala
    /// </summary>
    [Header ("Prefab de la bala")]
    public GameObject prefabBullet;

    /// <summary>
    /// Spwan de las balas en el disparo
    /// </summary>
    [Header ("Spawn de las balas")]
    public Transform spawnBullet;
    [Space]

    /// <summary>
    /// Diferencia de angulación del disparo por ejes
    /// </summary>
    [Header ("Diferencia de angulación del disparo por ejes")]
    public Vector3 diferenciaAngulacion;
    
    #endregion
    
    /// <summary>
    /// Al hacer click creamos una instancia de la bala y ajustamos su rotación con la diferencia de angulación estipulada en el editor
    /// Gastamos una bala de la munición total
    /// </summary>
    void Update()
    {
        //Al hacer click
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.Municion != 0 && !Cursor.visible)
        {
            //Creamos una instancia de la bala y ajustamos su rotación con la diferencia de angulación estipulada en el editor
            GameObject instancia = Instantiate(prefabBullet, spawnBullet.position, Camera.main.transform.rotation);
            instancia.transform.eulerAngles = new Vector3(instancia.transform.eulerAngles.x + diferenciaAngulacion.x, instancia.transform.eulerAngles.y + diferenciaAngulacion.y, instancia.transform.eulerAngles.z + diferenciaAngulacion.z);

            //Gastamos una bala de la munición total
            GameManager.Instance.Municion--;                 

        }
    }
}
