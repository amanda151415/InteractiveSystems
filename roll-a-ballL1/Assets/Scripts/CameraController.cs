using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    //Se usa LateUpdate en vez de Update a secar para que al trabajar con otras acciones del objeto no afecten a la camara,
    //por ejemplo si hay alguna colision con un objeto
    //la idea es que se ejecute esto despues todos los demas updates
    void LateUpdate() {

        transform.position = player.transform.position + offset;
    }

}
