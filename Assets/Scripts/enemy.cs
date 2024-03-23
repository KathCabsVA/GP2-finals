using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemy : MonoBehaviour
{

    //for healthbar
    public int damage;
    public Player playerScript;
    //public Player player;

    public NavMeshAgent agent;
    public Transform playerTransform;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        enemyMove();
    }

    void enemyMove()
    {
        //GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        //Transform newplayer = playerObject.transform;

        //transform.position = Vector3.MoveTowards(transform.position, newplayer.position, moveSpeed * Time.deltaTime);
        //Debug.DrawLine(transform.position, newplayer.position, Color.red);
        agent.SetDestination(playerTransform.position);
    }
    //pag nag collide sa player destroy enemy object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            playerScript.TakeDamage(damage);
        }
    }
}
