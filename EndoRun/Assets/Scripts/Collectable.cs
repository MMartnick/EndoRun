using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D mainObject)
    {
        PlayerController player = mainObject.GetComponent<PlayerController>();
        if (player != null)
        {
            ScoringSystem.updateScore = 5;
            Destroy(gameObject);
        }
    }

}
