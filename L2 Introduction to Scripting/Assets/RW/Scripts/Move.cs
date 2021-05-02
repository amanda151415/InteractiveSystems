using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 movementSpeed; //1
    public Space space; //2

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //en translate, la primera componente toma la direccion y la velocidad, la segunda
        //es el espacio en el cual ocurre el movimiento
        transform.Translate(movementSpeed * Time.deltaTime, space);
    }
}
