using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Getting the Rigidbody, Projectile
    public GameObject projectile;
    private Rigidbody2D myRB;
    //public GameObject Locked_Doors;
    public Camera cam;

    private Vector2 mousePos;

    //Health
    public int health
     = 3;
    [SerializeField] int maxHealth = 3;
    public int MaxHP { get { return maxHealth; } }
    private Vector3 Respawn;
    private bool hasCheckPoint = false;

    //Movement
    public float movementSpeed = 7.5f;
    public float speedIncrease = 12.5f;

    //Shooting Variables
    public bool canShoot = true;

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

    // Start is called before the first frame update
    void Start()
    {
        //Showing that myRB is the players Rigidbody
        myRB = GetComponent<Rigidbody2D>();
        //If the MaxHealth is adjusted, then the Health will also be adjusted
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

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

        //Showing that tempVelocity is the same as players velocity?
        Vector2 tempVelocity = myRB.velocity;

        //Shooting system
        if (hasAmmo && canShoot)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                shoot(Vector2.right);
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                shoot(Vector2.left);
            }

            else if (Input.GetKey(KeyCode.UpArrow))
            {
                shoot(Vector2.up);
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                shoot(Vector2.down);
            }

            else if (Input.GetKey(KeyCode.Mouse0))
            {
                shoot(mousePos);
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

        //PickUps CoolDowns (This will need to be changed)
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

        //Movement system
        tempVelocity.x = Input.GetAxisRaw("Horizontal") * movementSpeed;
        tempVelocity.y = Input.GetAxisRaw("Vertical") * movementSpeed;

        //Making sure that the player keeps moving
        myRB.velocity = tempVelocity;

    }

    //When the Player shoots this happens (Change the rotation if the mouse is used)
    private void shoot(Vector2 direction)
    {
        GameObject b = Instantiate(projectile, transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(GetComponent<PolygonCollider2D>(), b.GetComponent<CapsuleCollider2D>());

        if (direction == Vector2.left || direction == Vector2.right)
            b.GetComponent<Rigidbody2D>().rotation = 90;

        b.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed);
        Destroy(b, bulletLifetime);
        canShoot = false;
        ammo--;
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - myRB.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        myRB.rotation = angle;
    }
}
