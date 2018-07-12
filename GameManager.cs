using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManager del juego
/// Calcula las rotaciones en base al input del mouse
/// </summary>
public class GameManager : MonoBehaviour {


    #region Singleton

    /// <summary>
    /// Campo privado que referencia a esta instancia
    /// </summary>
    static GameManager instance;

    /// <summary>
    /// Propiedad pública que devuelve una referencia a esta instancia
    /// Pertenece a la clase, no a esta instancia
    /// Proporciona un punto de acceso global a esta instancia
    /// </summary>
    public static GameManager Instance
    {
        get { return instance; }
    }

    #endregion
    
    #region Variables accesibles en el editor

    /// <summary>
    /// Límite angulación levantamiento del cañón
    /// </summary>
    [Header("Límite angulación levantamiento del cañón")]
    public float clampAngleVertical = 60;
    [Space]

    /// <summary>
    /// Límite angulación levantamiento del cañón
    /// </summary>
    [Header("Límite angulación rotación del cañón")]
    public float clampAngleHorizontal = 60;
    [Space]

    /// <summary>
    /// Velocidad de rotación
    /// </summary>
    [Header("Velocidad de rotación")]
    public float rotationSpeed = 10;

    [Space]

    /// <summary>
    /// Velocidad de elevación
    /// </summary>
    [Header("Velocidad de elevación")]
    public float elevationSpeed;

    /// <summary>
    /// Munición máxima que puede tener el jugador
    /// </summary>
    [Header("Munición máxima que puede tener el jugador")]
    public byte municionMaxima;

    #endregion

    #region Propiedades

    /// <summary>
    /// Ángulo de rotación de la torreta al desplazar horizontalmente el ratón
    /// </summary>
    public float RotacionMouseX
    {
        get
        {
            return rotacionMouseX;
        }

        set
        {
            rotacionMouseX = value;
        }
    }

    /// <summary>
    /// Ángulo de elevación del cañón al desplazar verticalmente el ratón
    /// </summary>
    public float RotacionMouseY
    {
        get
        {
            return -rotacionMouseY;
        }

        set
        {
            rotacionMouseX = value;
        }
    }

    /// <summary>
    /// Cantidad de cemento que tiene que el jugador
    /// </summary>
    public byte Cemento
    {
        get
        {
            return cemento;
        }

        set
        {
            cemento = value;
        }
    }

    /// <summary>
    /// Cantidad de metal que tiene el jugador
    /// </summary>
    public byte Metal
    {
        get
        {
            return metal;
        }
        set
        {
            metal = value;
        }
    }

    /// <summary>
    /// Munición del tanque
    /// </summary>
    public byte Municion
    {
        get
        {
            return municionActual;
        }

        set
        {
            municionActual = value;
        }
    }

    #endregion

    #region Variables privadas

    /// <summary>
    /// Ángulo de rotación de la torreta al desplazar horizontalmente el ratón
    /// </summary>
    private float rotacionMouseX;

    /// <summary>
    /// Ángulo de elevación del cañón al desplazar verticalmente el ratón
    /// </summary>
    private float rotacionMouseY;

    /// <summary>
    /// Cantidad de cemento que tiene el jugador
    /// </summary>
    private byte cemento;

    /// <summary>
    /// Cantidad de metal que tiene el jugador
    /// </summary>
    private byte metal;

    /// <summary>
    /// Cantidad actual de munición que tiene el tanque
    /// </summary>
    private byte municionActual;

    #endregion


    /// <summary>
    /// Inicializamos instance y la munición actual
    /// </summary>
    void Awake()
    {
        //Asigna esta instancia al campo instance
        if (instance == null)
            instance = this;
        else
            Destroy(this);  //Garantiza que sólo haya una instancia de esta clase

        //Inicilizamos la munición actual
        municionActual = municionMaxima;
    }

    /// <summary>
    /// Si el cursor no está visible se permite el cálculo de las rotaciones en función del movimiento del ratón
    /// Si está visible significa que tiene el invenario abierto
    /// Limitamos el movimiento dependiendo de si predomina el movimiento horizontal o el vertical del ratón
    /// Si la munición es mayor que la munición máxima se iguala a la máxima    /// 
    /// </summary>
    void Update () {

        //Si el cursor no está visible se permite el cálculo del movimiento. 
        //Si está visible significa que tiene el invenario abierto
        if (!Cursor.visible)
        {
            //Calculamos las rotaciones en función del movimiento del ratón
            rotacionMouseY += (Input.GetAxis("Mouse Y") * elevationSpeed);
            rotacionMouseX += (Input.GetAxis("Mouse X") * rotationSpeed);
        }

        //Si la munición es mayor que la munición máxima se iguala a la máxima
        if (municionActual > municionMaxima) municionActual = municionMaxima;     

    }

    
}
