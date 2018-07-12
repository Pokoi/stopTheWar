using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador del movimiento de la torreta
/// </summary>
public class TurretController : MonoBehaviour {
    
    #region Variables privadas

    /// <summary>
    /// Transform del cannonPivot 
    /// </summary>
    Transform cannonPivot;

    /// <summary>
    /// Transform de mi objeto
    /// </summary>
    Transform miTransform;

    #endregion

    /// <summary>
    /// Inicializamos mi transform y cannonPivot
    /// </summary>
    void Start () {

        //Asignamos mi transform
        miTransform = transform; 
        
        //Asignamos el transform del primer hijo de la torreta a cannonPivot
        cannonPivot = miTransform.GetChild(0).transform; 

	}
		
    /// <summary>
    /// Aplicamos la rotación horizontal de la torreta y la elevación del cañón en base a los inputs calculados en el GameManager
    /// </summary>
	void Update () {

        //Limitamos el movimiento dependiendo de si predomina el movimiento horizontal o el vertical del ratón
        if (Mathf.Abs(Input.GetAxis("Mouse Y")) < Mathf.Abs(Input.GetAxis("Mouse X")))
        {
            //Aplicamos la rotación horizontal de la torreta en base al input calculado en el GameManager
            miTransform.rotation = Quaternion.Euler(-90, Mathf.Clamp(GameManager.Instance.RotacionMouseX, -GameManager.Instance.clampAngleHorizontal, GameManager.Instance.clampAngleHorizontal) + miTransform.parent.localEulerAngles.y, miTransform.eulerAngles.z);
            
        }
        
        if(Mathf.Abs(Input.GetAxis("Mouse Y")) > Mathf.Abs(Input.GetAxis("Mouse X")))
        {
            //Aplicamos la elevación del cañón en base al input calculado en el GameManager
            cannonPivot.rotation = Quaternion.Euler(-Mathf.Clamp(GameManager.Instance.RotacionMouseY, -GameManager.Instance.clampAngleVertical, GameManager.Instance.clampAngleVertical), cannonPivot.eulerAngles.y, cannonPivot.eulerAngles.z);
            
        }           

    }

   
}
