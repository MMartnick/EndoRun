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

    public bool delay;

    public int secondsToDestroy;

    public float distanceBetween;
    private float platformWidth;
    private float platformHeight;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDelay());

        platformWidth = platformModel.GetComponent<BoxCollider2D>().size.x;
        platformHeight = platformModel.GetComponent<BoxCollider2D>().size.y;
        RandomPlatformGen();

       // delay = true;
    }

    // Update is called once per frame
    void Update()
    {
        RandomPlatformGen();

        if ((transform.position.x < genPoint.position.x) && (delay == false))
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
        int randNum = Random.Range(0, 11);

        if (randNum == 0 || randNum == 8)
        {
            randomPlatform = platformModel;
        }

        if (randNum == 1 || randNum == 2 || randNum == 9 || randNum == 10)
        {
            randomPlatform = platformModelTwo;
        }

        if (randNum == 3 || randNum == 4 || randNum == 5 || randNum == 7 )
        {
            randomPlatform = platformModelThree;
        }

        if (randNum == 6 || randNum == 11)
        {
            randomPlatform = platformModelFour;
        }

    }

    public IEnumerator SpawnDelay()
    {

        yield return new WaitForSeconds(5);

        delay = false;

    }

}
