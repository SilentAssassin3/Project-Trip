using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : MonoBehaviour
{
    private Rigidbody2D lightRB;

    public GameObject eSpotScan;
    public GameObject eSpotAttack;

    // Start is called before the first frame update
    void Start()
    {
        lightRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eSpotAttack)
        {
            //Enemy starts attacking (aka. enemy pathfinding and attack)
        }

        if (eSpotScan)
        {
            //Enemy starts wandering slowly (aka. enemy pathfinding)
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            eSpotScan.SetActive(false);
            eSpotAttack.SetActive(true);
        }
    }

}
