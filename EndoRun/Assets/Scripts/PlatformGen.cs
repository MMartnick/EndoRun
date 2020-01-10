using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour
{

    public GameObject platformModel;
    public GameObject newPlatform;
    public GameObject startPlatform;
    public Transform genPoint;
    public float distanceBetween;
    public int secondsToDestroy;

    private float platformWidth;
    private float platformHeight;



    // Start is called before the first frame update
    void Start()
    {
        platformWidth = platformModel.GetComponent<BoxCollider2D>().size.x;
        platformHeight = platformModel.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < genPoint.position.x)
        {

         float platformWidthRand = Random.Range(0.1f, 2.5f);
         float platformHeightRand = Random.Range(-5.0f, 0.0f);

            transform.position = new Vector3(transform.position.x + (platformWidth + platformWidthRand) + distanceBetween, platformModel.transform.position.y + platformHeightRand, 0);


            print("rand = "+ platformHeightRand);

            newPlatform = Instantiate(platformModel, transform.position, transform.rotation);
            Destroy(newPlatform, secondsToDestroy);
            Destroy(startPlatform, secondsToDestroy);
        }
    }
}
