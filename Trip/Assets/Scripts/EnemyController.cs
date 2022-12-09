using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D  myRB;

    public GameObject ammo;
    public GameObject money; 

    public bool deadAmmo = false;
    public int health = 2;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 )
        {
            deadAmmo = Random.Range(0f, 100f) <= 50f;
            if (deadAmmo == true)
            {
                GameObject a = Instantiate(ammo, transform.position, Quaternion.identity);
            }

            GameObject m = Instantiate(money, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            health--;
        }


    }

}
