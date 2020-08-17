using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationDegreesPerSecond = 1;
    private float totalRotation = 0;


    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(90, 0, -180, Space.World);

    }

    // Update is called once per frame
    void Update()
    {
            Awake();
    }

    void Awake()
    { 


        transform.Rotate(0, 2, 0, Space.World);
    }
}
