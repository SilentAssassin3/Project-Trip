using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D  myRB;

    public GameObject ammo;
    public GameObject money;
    public GameObject[] ammoList;
    public GameObject[] moneyList;
    public Vector3 moneyPos;
    public Vector3 ammoPos;

    public bool deadAmmo = false;

    public bool hit = false;
    public float hitTimer = 0.2f;
    public float hitCoolDown = 0;

    public int health = 2;
    public int maxHealth = 2;

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

        if (hit)
        {
            while (hitCoolDown < hitTimer)
            {
                hitCoolDown += Time.deltaTime;
            }
        }
        if (hitCoolDown >= hitTimer)
        {
            hitCoolDown = 0;
            hit = false;
        }

        ammoList = GameObject.FindGameObjectsWithTag("Ammo");
        moneyList = GameObject.FindGameObjectsWithTag("Money");

        //Comparing all of the money gameobjects to see if they overlap with any of the ammo gameobjects, then moving the ammo up by 2
        foreach (GameObject Money in moneyList)
        {
            moneyPos = Money.transform.position;
        }

        foreach (GameObject Ammo in ammoList)
        {
            if (Ammo.transform.position == moneyPos)
            {
                ammoPos = Ammo.transform.position;
                ammoPos.y += 2;
                Ammo.transform.position = ammoPos;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && hit == false)
        {
            Destroy(collision.gameObject);
            health--;
            hit = true;
        }
    }

}
