using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador del movimiento de la cámara
/// </summary>
public class CameraController : MonoBehaviour {

    #region Variables

    #region Variables accesibles desde el editor

    /// <summary>
    /// ¿Es la cámara del minimapa?
    /// </summary>
    [Header("¿Es la cámara del minimapa?")]
    public bool MinimapCamera;
    [Space]

    /// <summary>
    /// Distancia entre la cámara y el objetivo en los tres ejes
    /// </summary>
    [Header("Distancia entre la cámara y el objetivo en los tres ejes")]
    public Vector3 distanciaAlObjetivo;
    [Space]

    /// <summary>
    /// Transform del objeto que va a seguir la cámara
    /// </summary>
    [Header("Transform del objeto que va a seguir la cámara")]
    public Transform objetoASeguir;

    
    #endregion

    #region Variables privadas

    /// <summary>
    /// Transform de la cámara
    /// </summary>
    Transform miTransform;

    #endregion

    #endregion

    /// <summary>
    /// Inicializamos mi transform y hacemos que el cursor sea invisible
    /// </summary>
    void Start () { 
        
        //Inicializamos mi transform
        miTransform = transform;

        //Hacemos invisible el cursor
        Cursor.visible = false;

    }

    /// <summary>
    /// Lo hacemos en el LateUpdate en vez de en el Update para asegurarnos que se ha posicionado el objeto al que seguimos
    /// Calculamos la posición de la cámara en función de la posición del objeto a seguir y la distancia a la que se encuentra 
    /// Aplicamos la rotación horizontal y la elevación de la cámara en base a los inputs calculados en el GameManager
    /// </summary>
    private void LateUpdate()
    {
        //Calculamos la posición de la cámara en función de la posición del objeto a seguir y la distancia a la que se encuentra

        //Si es la del minimapa no movemos la cámara en la coordenada Y
        if (MinimapCamera) miTransform.position = new Vector3(objetoASeguir.position.x + distanciaAlObjetivo.x, miTransform.position.y, objetoASeguir.position.z + distanciaAlObjetivo.z);        
        else miTransform.position = new Vector3(objetoASeguir.position.x + distanciaAlObjetivo.x, objetoASeguir.position.y + distanciaAlObjetivo.y, objetoASeguir.position.z + distanciaAlObjetivo.z);


        //Si no es la cámara del minimapa se aplican las rotaciones a la cámara
        if (!MinimapCamera)
        {
            if (Mathf.Abs(Input.GetAxis("Mouse Y")) < Mathf.Abs(Input.GetAxis("Mouse X")))
            {
                miTransform.rotation = Quaternion.Euler(miTransform.eulerAngles.x, Mathf.Clamp(GameManager.Instance.RotacionMouseX, -GameManager.Instance.clampAngleHorizontal, GameManager.Instance.clampAngleHorizontal), miTransform.eulerAngles.z);

            }

            if (Mathf.Abs(Input.GetAxis("Mouse Y")) > Mathf.Abs(Input.GetAxis("Mouse X")))
            {
                miTransform.rotation = Quaternion.Euler(Mathf.Clamp(GameManager.Instance.RotacionMouseY, -GameManager.Instance.clampAngleVertical, GameManager.Instance.clampAngleVertical), miTransform.eulerAngles.y, miTransform.eulerAngles.z);
            }
        }
    }
    

   
}
