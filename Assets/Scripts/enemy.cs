using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void enemyMove()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        Transform player = playerObject.transform;

        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        Debug.DrawLine(transform.position, player.position, Color.red);
    }
}
