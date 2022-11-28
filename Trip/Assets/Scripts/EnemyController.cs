using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 1;
    public float speed = 2.0f;

    public bool advMode = true;
    public bool isFollowing = false;
    public bool ranged = false;

    //Strafing Variables (maxDistance doesn't equal follow distance)
    public bool strafeOnY = false;
    public bool strafeOnX = false;
    public float maxDistance = 5.0f;

    Vector2 origin;
    Vector2 maxPos;
    Vector2 minPos;

    public Transform playerTarget;
    public GameObject ammo;
    Rigidbody2D myRB;

    public float dis;
    private Vector3 lookPos;
    // Start is called before the first frame update
    void Start()
    {
        //Calling myRB the Enemies Rigidbody
        myRB = GetComponent<Rigidbody2D>();

        //Calling origin the position of the Enemy
        origin = transform.position;

        //If strafing on the y-axis
        if (strafeOnY)
        {
            myRB.constraints = RigidbodyConstraints2D.FreezePositionX & RigidbodyConstraints2D.FreezeRotation;

            maxPos = new Vector2(origin.x, origin.y + maxDistance);
            minPos = new Vector2(origin.x, origin.y - maxDistance);

            if (strafeOnX)
            {
                myRB.velocity = Vector2.up * speed;
            }
            else
            {
                myRB.velocity = Vector2.up * -speed;
            }
        }
        else
        {
            myRB.constraints = RigidbodyConstraints2D.FreezePositionY & RigidbodyConstraints2D.FreezeRotation;

            maxPos = new Vector2(origin.x + maxDistance, origin.y);
            minPos = new Vector2(origin.x - maxDistance, origin.y);

            if (strafeOnX)
            {
                myRB.velocity = Vector2.right * speed;
            }
            else
            {
                myRB.velocity = Vector2.right * -speed;
            }
        }
        playerTarget = GameObject.Find("Player").transform;

        dis = Vector3.Distance(playerTarget.position, transform.position);
        Vector3 lookPos = playerTarget.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy death
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject a = Instantiate(ammo, transform.position, Quaternion.identity);
        }

        if (advMode == false)
        {
            if (strafeOnY)
            {
                if (transform.position.y >= maxPos.y)
                {
                    myRB.velocity = Vector2.up * -speed;
                }
                else if (transform.position.y <= minPos.y)
                {
                    myRB.velocity = Vector2.up * speed;
                }
            }
            else
            {
                if (transform.position.x >= maxPos.x)
                {
                    myRB.velocity = Vector2.right * -speed;
                }
                else if (transform.position.x <= minPos.x)
                {
                    myRB.velocity = Vector2.right * speed;
                }
            }
        }

        else
        {
            if (isFollowing == false)
            {
                myRB.velocity = Vector2.zero;
            }

            else
            {
                Vector3 lookPos = playerTarget.position - transform.position;

                myRB.rotation = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
                if (!ranged)
                {
                    myRB.velocity = lookPos * speed;
                }
                if (ranged)
                {
                    if (Vector3.Distance(lookPos, transform.position) <= 6.0)
                    {
                        myRB.velocity = Vector2.zero;
                    }
                    if (Vector3.Distance(lookPos, transform.position) > 6.0)
                    {
                        myRB.velocity = lookPos * speed;
                    }
                }
            }
        }
    }

    //Enemy take damage from Player's bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerBullet")
        {
            Destroy(collision.gameObject);
            health--;
        }

        if (collision.gameObject.tag == "Player")
        {
            //Player's health goes down, cooldown happens, player can take damage again
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player") && advMode)
            isFollowing = true;

        if ((collision.gameObject.tag == "Player") && advMode)
        {
            isFollowing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player") && advMode)
            isFollowing = false;
    }

}
