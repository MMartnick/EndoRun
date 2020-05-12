using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationDegreesPerSecond = 90;
    private float totalRotation = 0;


    // Start is called before the first frame update
    void Start()
    {
        
     
    }

    // Update is called once per frame
    void Update()
    {
            Awake();
    }

    void Awake()
    {
        float currentAngle = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.AngleAxis(currentAngle + ((Time.deltaTime * 4 ) * rotationDegreesPerSecond), Vector3.up);
        totalRotation = Time.deltaTime  * rotationDegreesPerSecond;
    }
}
