using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public GameObject CollectiblePrefab;
    public GameObject Planes;
    public GameObject ScoreText;

    public int TotalCollectibles = 5;
    public List<GameObject> Collectibles = new();
    public int Score { get; set; } = 0;

    public float BorderLength { get; private set; }

    void Start() {
        
        BorderLength = Planes.GetComponent<PlaneScript>().BorderLength;

        while(Collectibles.Count < TotalCollectibles) {
            CreateCollectible();
        }
    }

    void CreateCollectible() {
        Vector3 position = new(Random.Range(-BorderLength, BorderLength), Random.Range(-BorderLength, BorderLength), Random.Range(-BorderLength, BorderLength));
        GameObject collectible = Instantiate(CollectiblePrefab, position, Quaternion.identity, transform);
        Collectibles.Add(collectible);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.J)) {
            CreateCollectible();
        }
        if (Collectibles.Count == 0) {
            Debug.Log("All collectibles collected!");
            Application.Quit();
        }
    }
}

