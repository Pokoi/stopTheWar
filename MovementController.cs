 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador del movimiento en base a wheel collider 
/// </summary>
public class MovementController : MonoBehaviour {

    #region Variables accesibles desde el editor 

    /// <summary>
    /// Altura del centro de gravedad del vehículo
    /// </summary>
    [Header ("Altura del centro de gravedad del coche")]
    public float cog = 0;
    [Space]

    /// <summary>
    /// Transform del centro de gravedad del vehículo
    /// </summary>
    [Header("Transform del centro de gravedad del vehículo")]
    public Transform COG;
    [Space]

    /// <summary>
    /// Lista de ruedas. Depende de la clase contenedora Grupo Motor. 
    /// </summary>
    [Header ("Lista de ruedas")]
    public List<GrupoMotor> ruedas;
    [Space]

    /// <summary>
    /// Velocidad máxima de traslación 
    /// </summary>
    [Header ("Velocidad mázima de traslación")]
    public float maxSpeed = 300;

    #endregion

    #region Variables privadas

    /// <summary>
    /// Rigidbody de mi objeto
    /// </summary>
    Rigidbody rb;

    /// <summary>
    /// Velocidad del tanque
    /// </summary>
    float speed;

    /// <summary>
    /// Angulación del tanque
    /// </summary>
    float steer;

    /// <summary>
    /// Ángulo máximo de giro
    /// </summary>
    const float maxAngle = 35;
    
    #endregion
    

    /// <summary>
    /// Inicializamos el rigidbody
    /// Asignamos la altura del centro de gravedad en base al valor pasado en el editor
    /// </summary>
    void Start () {

        //Inicializamos el rigidbody
        rb = GetComponent<Rigidbody>();

        //Asignamos la altura del centro de gravedad en base al valor pasado en el editor
        rb.centerOfMass = new Vector3(rb.centerOfMass.x, cog, rb.centerOfMass.z);
        COG.transform.InverseTransformDirection(rb.centerOfMass);
        COG.position = new Vector3(COG.position.x, cog, COG.position.z);   
             
	}

    /// <summary>
    /// Obtenemos la velocidad y la dirección del vehículo
    /// </summary>
    private void Update()
    {
        //Obtiene la velocidad del mando del usuario
        speed = Input.GetAxis("Vertical") * maxSpeed;

        //Obtiene la dirección del mando del usuario
        steer = Input.GetAxis("Horizontal") * maxAngle;

        //Al pulsar el Shift izquierdo frenamos el rigidbody
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.velocity = new Vector3 (0, 0, 0);
        }
    }

    /// <summary>
    /// Establecemos la posición y dirección de las ruedas visuales en base a las ruedas físicas
    /// </summary>
    void FixedUpdate () {

        foreach(GrupoMotor rueda in ruedas)
        {
            Vector3 position;
            Quaternion rotation;

            //Obtiene la posición y la rotación de la rueda física 
            rueda.ruedaFisica.GetWorldPose(out position, out rotation);

            //Establece la posición y la rotación de la rueda visual 
            rueda.ruedaVisual.position = position;
            rueda.ruedaVisual.rotation = rotation;

            //Establece la fuerza rotacional si procede
            if (rueda.esMotriz)
                rueda.ruedaFisica.motorTorque = speed;

            //Establece la dirección si procede
            if (rueda.esDirectriz)
                rueda.ruedaFisica.steerAngle = steer;
        }
        
    }
}


[System.Serializable]
/// <summary>
/// Agrupa una rueda físical y una visual
/// </summary>
public class GrupoMotor { 

    /// <summary>
    /// Referencia a la rueda física 
    /// </summary>
    public WheelCollider ruedaFisica;

    /// <summary>
    /// Referencia a la rueda visual 
    /// </summary>
    public Transform ruedaVisual;

    /// <summary>
    /// Indica si es una rueda motriz
    /// </summary>
    public bool esMotriz;

    /// <summary>
    /// Indica si es una rueda directriz
    /// </summary>
    public bool esDirectriz;
}
