using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controlador del HUD
/// </summary>
public class HUDManager : MonoBehaviour {


    #region Singleton

    /// <summary>
    /// Campo privado que referencia a esta instancia
    /// </summary>
    static HUDManager instance;

    /// <summary>
    /// Propiedad pública que devuelve una referencia a esta instancia
    /// Pertenece a la clase, no a esta instancia
    /// Proporciona un punto de acceso global a esta instancia
    /// </summary>
    public static HUDManager Instance
    {
        get { return instance; }
    }

    #endregion

    #region Variables accesibles desde el editor

    /// <summary>
    /// Texto depurador de la cantidad de munición actual
    /// </summary>
    [Header("Texto depurador de la cantidad de munición actual")]
    public Text municion;

    /// <summary>
    /// Texto depurador del loot conseguido
    /// </summary>
    [Header("Texto depurador del loot conseguido")]
    public Text loot;
    [Space]

    /// <summary>
    /// GameObject del inventario
    /// </summary>
    [Header("GameObject del inventario")]
    public GameObject inventario;

    #endregion

    /// <summary>
    /// Inicializamos instance
    /// </summary>
    void Awake()
    {
        //Asigna esta instancia al campo instance
        if (instance == null)
            instance = this;
        else
            Destroy(this);  //Garantiza que sólo haya una instancia de esta clase
              
    }

    /// <summary>
    /// Mostramos la cantidad de munición del jugador
    /// Al pulsar tabulación se muestra o cierra el inventario
    /// Al tener el invenario abierto se activa la visión del cursor
    /// </summary>
    void Update () {

        municion.text = GameManager.Instance.Municion.ToString();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventario.activeSelf)
            {
                inventario.SetActive(false);
                Cursor.visible = false;
            }

            else
            {
                inventario.SetActive(true);
                Cursor.visible = true;
            }

        }

	}

    /// <summary>
    /// Reproduce el mensaje que recibe como parámetro
    /// Se usa para mostrar el loot obtenido al destruir un objeto
    /// </summary>
    /// <param name="mensaje"></param>
    public void showLoot(string mensaje)
    {
        loot.gameObject.SetActive(true);
        loot.text = mensaje;
        Invoke("hideLoot", 1.5f);

    }

    /// <summary>
    /// Método que oculta el gameObject del texto depurador del loot
    /// </summary>
    private void hideLoot()
    {
        loot.gameObject.SetActive(false);
    }
    
}
