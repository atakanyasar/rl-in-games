using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    // boundaries
    public float BorderLength = 100f;

    public GameObject plane;

    // Start is called before the first frame update
    void Start()
    {
        plane.transform.localScale = new Vector3(BorderLength * 2, 1, BorderLength * 2);

        // set boundaries
        Instantiate(plane, new Vector3(0, -BorderLength, 0), Quaternion.identity, transform);
        Instantiate(plane, new Vector3(0, BorderLength, 0), Quaternion.identity, transform);
        Instantiate(plane, new Vector3(-BorderLength, 0, 0), Quaternion.Euler(0, 0, 90), transform);
        Instantiate(plane, new Vector3(BorderLength, 0, 0), Quaternion.Euler(0, 0, 90), transform);
        Instantiate(plane, new Vector3(0, 0, -BorderLength), Quaternion.Euler(90, 0, 0), transform);
        Instantiate(plane, new Vector3(0, 0, BorderLength), Quaternion.Euler(90, 0, 0), transform);
    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
