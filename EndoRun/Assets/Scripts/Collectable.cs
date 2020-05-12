using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {

        ScoringSystem.updateScore = 1;
        Destroy(gameObject);
    }

}
