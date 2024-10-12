using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBehaviorScript : MonoBehaviour
{   

    public float Speed = 0.5f;
    public Vector3 TargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        TargetPosition = new Vector3(Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(0f, 10f));   
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, TargetPosition) < 0.1f) {
            TargetPosition = new Vector3(Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(0f, 10f));
        }

        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Player") {
            return;
        }
        Destroy(gameObject);
        GetComponentInParent<CollectibleScript>().Collectibles.Remove(gameObject);
    }

}
