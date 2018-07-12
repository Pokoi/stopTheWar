using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controlador del loot de los objetos
/// </summary>
public class LootController : MonoBehaviour {

    #region Variables accesibles desde el editor
    
    /// <summary>
    /// Cantidad de loot de metal
    /// </summary>
    [Header("Cantidad de loot de metal")]
    public byte lootMetal;
    
    /// <summary>
    /// Cantidad de loot de cemento
    /// </summary>
    [Header("Cantidad de loot de metal")]
    public byte lootCemento;

    #endregion

    /// <summary>
    /// Modificamos los valores de cemento y metal del GameManager en función del loot
    /// Pasamos al HUDManager el mensaje que reproducir en función del loot obtenido
    /// </summary>
    private void OnDestroy()
    {
        GameManager.Instance.Cemento += lootCemento;
        GameManager.Instance.Metal += lootMetal;
        HUDManager.Instance.showLoot("+" + lootMetal + " de metal" + "\n" + "+" + lootCemento + " de cemento");
    }
}
