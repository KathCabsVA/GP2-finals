using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(this.gameObject.name);
            Debug.Log("EnemyHIt");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(this.gameObject.name);
            Debug.Log("EnemyHIt ontrigger");
        }
    }
}
