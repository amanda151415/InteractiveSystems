using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed; // 1
    public float gotHayDestroyDelay; // 2
    private bool hitByHay; // 3

    public float dropDestroyDelay; // 1
    private Collider myCollider; // 2
    private Rigidbody myRigidbody; // 3

    private SheepSpawner sheepSpawner;

    public float heartOffset; // 1
    public GameObject heartPrefab; // 2

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }

    private void HitByHay()
    {
        //contador de ovejas
        GameStateManager.Instance.SavedSheep();

        //borrar la oveja de la lista de ovejas
        sheepSpawner.RemoveSheepFromList(gameObject);
        
        //audio
        SoundManager.Instance.PlaySheepHitClip();

        //generar un corazon
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        //agrega una animacion de tweening a la oveja antes de ser eliminada
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>(); ; // 1
        //si se le da un target sclae de 0, la oveja se encogera hacia abajo
        tweenScale.targetScale = 0; // 2
        tweenScale.timeToReachTarget = gotHayDestroyDelay; // 3

        hitByHay = true; // 1
        runSpeed = 0; // 2
        //esta vez, hay agregado un delay de destruccion, para que no sea inmediato
        Destroy(gameObject, gotHayDestroyDelay); // 3
    }

    private void Drop()
    {
        //audio
        SoundManager.Instance.PlaySheepDroppedClip();
        //contador de ovejas
        GameStateManager.Instance.DroppedSheep();

        sheepSpawner.RemoveSheepFromList(gameObject);

        myRigidbody.isKinematic = false; // 1
        myCollider.isTrigger = false; // 2
        Destroy(gameObject, dropDestroyDelay); // 3
    }

    private void OnTriggerEnter(Collider other) // 1
    {
        if (other.CompareTag("Hay") && !hitByHay) // 2
        {
            Destroy(other.gameObject); // 3
            HitByHay(); // 4
        }
        else if (other.CompareTag("DropSheep"))
        {
            Drop();
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }
}
