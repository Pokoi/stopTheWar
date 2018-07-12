using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script que controla cada material del inventario
/// </summary>
public class MaterialInventarioController : MonoBehaviour {

    #region Variables accesibles desde el editor

    public enum TipoMaterial { cemento, metal }

    /// <summary>
    /// Tipo de material que es este material
    /// </summary>
    public TipoMaterial miTipo;

    /// <summary>
    /// Cantidad de material necesaria para el crafteo
    /// </summary>
    [Header("Cantidad de material necesaria para el crafteo")]
    public byte cantidadNecesaria;
    [Space]

    /// <summary>
    /// Cantidad de crafteo obtenido al realizar el crafteo
    /// </summary>
    [Header("Cantidad de crafteo obtenido al realizar el crafteo")]
    public byte cantidadCrafteo;
    
    #endregion

    #region Variables privadas

    /// <summary>
    /// Texto depuración que refleja la cantidad de material que tiene el jugador
    /// </summary>
    Text cantidadMaterialTxt;

    /// <summary>
    /// Texto depuración que refleja la cantidad de material necesaria para el crafteo
    /// </summary>
    Text cantidadNecesariaTxt;

    /// <summary>
    /// Texto depuración que refleja la cantidad de crafteo que se obtiene al realizar el crafteo
    /// </summary>
    Text cantidadCrafteoTxt;

    /// <summary>
    /// Imagen del crafteo 
    /// </summary>
    Image imagenCrafteo;

    /// <summary>
    /// Botón de crafteo
    /// </summary>
    Button miBoton;

    #endregion

    /// <summary>
    /// Inicialización del botón de crafteo
    /// </summary>
    private void Awake()
    {
        miBoton = transform.GetChild(3).GetComponent<Button>();
        cantidadMaterialTxt = transform.GetChild(2).GetComponent<Text>();
        cantidadCrafteoTxt = transform.GetChild(6).GetComponent<Text>();
        cantidadNecesariaTxt = transform.GetChild(4).GetComponent<Text>();
        imagenCrafteo = transform.GetChild(5).GetComponent<Image>();

    }

    /// <summary>
    /// Actualizamos los valores de los textos de depuración
    /// Activamos o desactivamos el botón dependiendo de si podemos o no realizar el crafteo
    /// </summary>
    void Update () {
		
        if(miTipo == TipoMaterial.cemento)
        {
            cantidadMaterialTxt.text = GameManager.Instance.Cemento.ToString();

            //Si no tenemos suficiente cantidad, la imagen del crafteo se ve oscurecida
            if (GameManager.Instance.Cemento < cantidadNecesaria) {
                imagenCrafteo.color = new Color(113 / 255, 107 / 255, 107 / 255);
                miBoton.enabled = false;
            }
            else
            {
                imagenCrafteo.color = new Color( 255/ 255, 255 / 255, 255 / 255);
                miBoton.enabled = true;
            }
        }

        if(miTipo == TipoMaterial.metal)
        {
            cantidadMaterialTxt.text = GameManager.Instance.Metal.ToString();

            //Si no tenemos suficiente cantidad o tenemos la munición máxima, la imagen del crafteo se ve oscurecida
            if (GameManager.Instance.Metal < cantidadNecesaria || GameManager.Instance.Municion == GameManager.Instance.municionMaxima)
            {
                imagenCrafteo.color = new Color(113 / 255, 107 / 255, 107 / 255);
                miBoton.enabled = false;
            }
            else
            {
                imagenCrafteo.color = new Color(255 / 255, 255 / 255, 255 / 255);
                miBoton.enabled = true;
            }
        }

        cantidadCrafteoTxt.text = cantidadCrafteo.ToString();
        cantidadNecesariaTxt.text = cantidadNecesaria.ToString();
        
    }

   
    /// <summary>
    /// Método que controla el crafteo del elemento. Es llamado al pulsar el botón del martillo
    /// </summary>
    public void Crafteo()
    {
        if (miTipo == TipoMaterial.cemento)
        {
            GameManager.Instance.Cemento -= cantidadNecesaria;
        }

        if (miTipo == TipoMaterial.metal)
        {
            GameManager.Instance.Metal -= cantidadNecesaria;
            GameManager.Instance.Municion += cantidadCrafteo;
        }

    }
}
