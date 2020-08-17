using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{

    public GameObject Player;
    public GameObject SpawnPoint;


    private void Start()
    {
        Player = GameObject.Find("Player");
        SpawnPoint = GameObject.Find("RespawnPoint");
    }




}
