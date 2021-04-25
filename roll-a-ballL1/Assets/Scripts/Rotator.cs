using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //deltaTime nos calcula los segundos de diferencia entre un frame y el siguiente
        //se usa para que un movimiento rotativo sea suave y constante

        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
