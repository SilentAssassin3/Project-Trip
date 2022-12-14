using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Getting the Rigidbody, Projectile
    public GameObject projectile;
    private Rigidbody2D myRB;
    private SpriteRenderer mySprite;
    public Sprite[] spriteArray;
    public Rigidbody2D bulletRB;

    public Camera cam;

    private Vector2 mousePos;

    //Health
    public int health
     = 3;
    [SerializeField] int maxHealth = 3;
    public int MaxHP { get { return maxHealth; } }
    private Vector3 Respawn;
    private bool hasCheckPoint = false;
    public bool damaged = false;
    public float healthTimer = 0;
    public float healthCooldownTime = 0.5f;

    //Movement
    public float movementSpeed = 7.5f;
    public float speedIncrease = 12.5f;
    public float moveSpeed = 5f;//ian

    //Shooting Variables
    public bool canShoot = true;

    //this is the angle from the player to the mouse
    public float angle;

    public float bulletSpeed = 1000;
    public float fireRate = 1.0f;
    public float fireCooldown = 0;
    public float bulletLifetime = 2.5f;
    public float coolDownTimer = 0;

    public int ammo = 20;
    public int maxAmmo = 20;
    public int ammoOnYou = 0;
    public bool hasAmmo = true;
    public float reloadTime = 1.0f;
    public float reloadCoolDown;
    private int ammoTransfered;

    //PickUps 
    public bool speedBoostEnabled = false;
    public float speedTimer = 0;
    public float speedCooldownTime = 5;

    public bool fireRateBoostEnabled = false;
    public float fireRateBoostTimer = 0;
    public float fireRateBoostCooldown = 5;
    public float fireRateAmplifer = 0.5f;

    public int ammoGain = 20;

    Vector2 movement;//ian

    // Start is called before the first frame update
    void Start()
    {
        //Showing that myRB is the players Rigidbody
        myRB = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        //If the MaxHealth is adjusted, then the Health will also be adjusted
        health = maxHealth;

        bulletRB.rotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //angle is the bullet angle when shot
        angle = Mathf.Atan((mousePos.y-transform.position.y)/(mousePos.x-transform.position.x))* Mathf.Rad2Deg;
        //finding what quadrant the point is in
        //if in one, no if statments activate
        
        if ((mousePos.y - transform.position.y) > 0 && (mousePos.x - transform.position.x) > 0)
        {
            //quadrant 1
            angle = Mathf.Atan(Mathf.Abs((mousePos.y - transform.position.y) / (mousePos.x - transform.position.x)) ) * Mathf.Rad2Deg;
        }
        else if ((mousePos.y - transform.position.y) > 0 && (mousePos.x - transform.position.x) < 0)
        {
            //quadrant 2
            angle = Mathf.Atan(Mathf.Abs((mousePos.x - transform.position.x) / (mousePos.y - transform.position.y))) * Mathf.Rad2Deg + 90;
        }
        else if ((mousePos.y - transform.position.y) < 0 && (mousePos.x - transform.position.x) < 0)
        {
            //quadrant 3
            angle = Mathf.Atan(Mathf.Abs((mousePos.y - transform.position.y) / (mousePos.x - transform.position.x))) * Mathf.Rad2Deg + 180;
        }
        else if ((mousePos.y - transform.position.y) < 0 && (mousePos.x - transform.position.x) > 0)
        {
            //quadrant 4
            angle = Mathf.Atan(Mathf.Abs((mousePos.x - transform.position.x) / (mousePos.y - transform.position.y))) * Mathf.Rad2Deg + 270;
        }
        //This is here becuase the sprite for the bullet is starting stright up and down and not sideways
        angle += 90;

        if (mousePos.x > transform.position.x)
        {
            mySprite.flipX = true;
        }
        else if (mousePos.x < transform.position.x)
        {
            mySprite.flipX = false;
        }
        if (mousePos.y > transform.position.y)
        {
            mySprite.sprite = spriteArray[1];
        }
        else if (mousePos.y < transform.position.y)
        {
            mySprite.sprite = spriteArray[0];
        }

        //Respawn system
        if (health <= 0)
        {
            if (!hasCheckPoint)
            {
                transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
                health = maxHealth;
            }
            else if (hasCheckPoint)
            {
                transform.SetPositionAndRotation(Respawn, Quaternion.identity);
                health = maxHealth;
            }
        }

        //Player's health goes down, cooldown happens, player can take damage again (to make sure there is a buffer for the damage and the player doesn't die basically instantly)
        if (damaged)
        {
            if (healthTimer < healthCooldownTime)
            {
                healthTimer += Time.deltaTime;
            }

            if (healthTimer >= healthCooldownTime)
            {
                healthTimer = 0;
                damaged = false;
            }
        }

        //Showing that tempVelocity is the same as players velocity?
        Vector2 tempVelocity = myRB.velocity;

        //Shooting system
        if (hasAmmo && canShoot)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
            shoot((new Vector2(transform.position.x, transform.position.y)  - mousePos).normalized);
            }

            //Checking ammo
            if (ammo <= 0)
            {
                hasAmmo = false;
                canShoot = false;
            }
        }

        //Ammo system
        if (ammo != maxAmmo && ammoOnYou >= 1 && Input.GetKeyDown(KeyCode.R))
        {
            while (reloadCoolDown < reloadTime)
            {
                reloadCoolDown += Time.deltaTime;
            }
        }

        else if (reloadCoolDown >= reloadTime)
        {
            ammoTransfered = maxAmmo - ammo;
            ammoOnYou -= ammoTransfered;
            ammo += ammoTransfered;
            reloadCoolDown = 0;
            hasAmmo = true;
        }

        //Firerate system
        else if (!canShoot)
        {
            if (hasAmmo == true && coolDownTimer < fireRate)
            {
                coolDownTimer += Time.deltaTime;
            }

            else if (coolDownTimer >= fireRate)
            {
                canShoot = true;
                coolDownTimer = 0;
            }
        }

        /* PickUps CoolDowns (Becuase this game isn't using any of this, it isn't needed)
        if (speedBoostEnabled)
        {
            if (speedTimer < speedCooldownTime)
            {
                speedTimer += Time.deltaTime;
            }

            else
            {
                speedBoostEnabled = false;
                speedTimer = 0;
                movementSpeed -= speedIncrease;
            }
        }

        if (fireRateBoostEnabled)
        {
            if (fireRateBoostTimer < fireRateBoostCooldown)
            {
                fireRateBoostTimer += Time.deltaTime;
            }

            else
            {
                fireRateBoostEnabled = false;
                fireRateBoostTimer = 0;
                fireRate /= fireRateAmplifer;
            }
        }
        */
        
        //Movement system (This is replaced with the PlayerMovement Script, which just does the same thing)
        /*
        tempVelocity.x = Input.GetAxisRaw("Horizontal") * movementSpeed;
        tempVelocity.y = Input.GetAxisRaw("Vertical") * movementSpeed;

        //Making sure that the player keeps moving
        myRB.velocity = tempVelocity;
        */
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


    
    }





    
    //When the Player shoots this happens
    
    private void shoot(Vector2 direction)
    {
        GameObject b = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle));
        
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), b.GetComponent<Collider2D>());
        b.GetComponent<Rigidbody2D>().velocity = direction * -bulletSpeed;
        Destroy(b, bulletLifetime);
        ammo--;
        canShoot = false;
    }

    

 
    //ians stuff ()
    void FixedUpdate()
    {
        myRB.MovePosition(myRB.position + movement * moveSpeed * Time.fixedDeltaTime);

        //To stop the player sprite from rotating this is being commented out
        /*
        Vector2 lookDir = mousePos - myRB.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        myRB.rotation = angle;
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && damaged == false)
        {
            health--;
            damaged = true;
        }

        if (collision.gameObject.tag == "eBullet" && damaged == false)
        {
            Destroy(collision.gameObject);
            health--;
            damaged = true;
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && damaged == false)
        {
            health--;
            damaged = true;
        }

        if (collision.gameObject.tag == "eBullet" && damaged == false)
        {
            Destroy(collision.gameObject);
            health--;
            damaged = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Money")
        {
            Destroy(collision.gameObject);
            //MONEY++;
        }

        if (collision.gameObject.tag == "Ammo")
        {
            Destroy(collision.gameObject);
            ammoOnYou += ammoGain;
        }
    }

}
