using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour
{

    public GameObject platformModel;
    public GameObject platformModelTwo;
    public GameObject platformModelThree;
    public GameObject platformModelFour;

    public GameObject randomPlatform;

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
        RandomPlatformGen();
    }

    // Update is called once per frame
    void Update()
    {
        RandomPlatformGen();

        if (transform.position.x < genPoint.position.x )
        {

            float platformWidthRand = Random.Range(0.1f, 2.5f);
            float platformHeightRand = Random.Range(-3000.0f, -1000.0f);

            transform.position = new Vector3(transform.position.x + (platformWidth + platformWidthRand) + distanceBetween, platformModel.transform.position.y + platformHeightRand, 0);

            //print("rand = "+ platformHeightRand);

            newPlatform = Instantiate(randomPlatform, transform.position, transform.rotation);
            Destroy(newPlatform, secondsToDestroy);
            Destroy(startPlatform, secondsToDestroy);
        }

    }

    void RandomPlatformGen()
    {
        int randNum = Random.Range(0, 6);

        if (randNum == 0)
        {
            randomPlatform = platformModel;
        }

        if (randNum == 1 || randNum == 2)
        {
            randomPlatform = platformModelTwo;
        }

        if (randNum == 3 || randNum == 4 || randNum == 5)
        {
            randomPlatform = platformModelThree;
        }

        if (randNum == 6)
        {
            randomPlatform = platformModelFour;
        }

    }

}
