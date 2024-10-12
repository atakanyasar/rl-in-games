using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public GameObject CollectiblePrefab;

    public int TotalCollectibles = 5;
    public List<GameObject> Collectibles = new();

    void Start() {
        while(Collectibles.Count < TotalCollectibles) {
            Vector3 position = new Vector3(Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(0f, 10f));
            GameObject collectible = Instantiate(CollectiblePrefab, position, Quaternion.identity, transform);
            Collectibles.Add(collectible);
        }
    }

    void Update() {
        if (Collectibles.Count == 0) {
            Debug.Log("All collectibles collected!");
            Application.Quit();
        }
    }
}

