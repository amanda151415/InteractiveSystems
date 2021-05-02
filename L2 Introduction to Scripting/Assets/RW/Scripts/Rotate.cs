using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 50 * Time.deltaTime, 0); // afecta solo al eje y, para rotar las aspas
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
