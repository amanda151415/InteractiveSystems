using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private float movementX;
    private float movementY;
    //si ponemos como publica la variable, seremos capaz de modificar desde unity su valor
    public float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(speed * movement);
    }

    void OnTriggerEnter(Collider other)
    {
        //si nuestro jugador colisiona con un objeto que tiene el tag PickUp (sera entonces un prefab)
        if (other.gameObject.CompareTag("PickUp"))
        {
            //se desactiva el objeto PickUp y cuenta
            other.gameObject.SetActive(false);
            count ++;
            SetCountText();
        }
    }

    void OnMove(InputValue value) {

        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;
    }

    void SetCountText() {

        countText.text = "Count: " + count.ToString();
        if (count >= 8) {
            winTextObject.SetActive(true);
        }
    }   

    /*// Update is called once per frame
    void Update()
    {
        
    }*/
}
