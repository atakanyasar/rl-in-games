using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomBehaviorScript : MonoBehaviour
{   

    public float Speed = 1f;
    public Vector3 TargetPosition;
    private float BorderLength;

    void Start()
    {
        BorderLength = GetComponentInParent<CollectibleScript>().BorderLength;
        
        TargetPosition = new(Random.Range(-BorderLength, BorderLength), Random.Range(-BorderLength, BorderLength), Random.Range(-BorderLength, BorderLength));   
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, TargetPosition) < 0.1f) {
            TargetPosition = new(Random.Range(-BorderLength, BorderLength), Random.Range(-BorderLength, BorderLength), Random.Range(-BorderLength, BorderLength)); 
        }

        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Player")) {
            return;
        }
        Destroy(gameObject);
        GetComponentInParent<CollectibleScript>().Collectibles.Remove(gameObject);
        GetComponentInParent<CollectibleScript>().ScoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + ++GetComponentInParent<CollectibleScript>().Score;
    }

}
