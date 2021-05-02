using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    //Para que la maquina de heno no se salga del limete del rail, le ponemos un limite
    public float horizontalBoundary = 22;

    //Variables para disparar fardos de heno
    public GameObject hayBalePrefab; // 1
    public Transform haySpawnpoint; // 2
    public float shootInterval; // 3
    private float shootTimer; // 4

    //para "cambiar el color" de la maquina
    public Transform modelParent; // 1
    // 2
    public GameObject blueModelPrefab;
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;


    // Start is called before the first frame update
    void Start()
    {
        LoadModel();
    }

    //metodo para "cambiar la maquina de color"
    private void LoadModel()
    {
        Destroy(modelParent.GetChild(0).gameObject); // 1

        switch (GameSettings.hayMachineColor) // 2
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
                break;
        }
    }

    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // 1

        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) // 2 
        {
            //Movimiento a la izquierda
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) // 3
        {
            //Movimiento a la derecha
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }

    //metodo para disparar heno
    private void ShootHay()
    {
        //audio
        SoundManager.Instance.PlayShootClip();

        //el metodo Instantiate crea una instancia de un prefab para ponerlo en escena
        //Quaternion.identity determina una rotacion por defecto de 0,0,0
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }
    //metodo para hacer update de los disparos y controlar el tiempo entre ellos
    private void UpdateShooting()
    {
        //quita el tiempo entre un frame y otro
        shootTimer -= Time.deltaTime; // 1
        //el shoortimer debe ser igual menor a 0 para disparar
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) // 2
        {
            shootTimer = shootInterval; // 3
            ShootHay(); // 4
        }
    }




    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }
}
