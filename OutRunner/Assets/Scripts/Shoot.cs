using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public bool mobileAtk;

    // Update is called once per frame
    void Update()
    {
        if (mobileAtk == true)                     //(Input.GetMouseButtonDown(0)))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            mobileAtk = false;
        }
    }

    public void MblAttk()
    {
        mobileAtk = true;
    }
}
