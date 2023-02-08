using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyLight eLight;
    public Vector3 direction;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        eLight = FindObjectOfType<EnemyLight>();
        rb = this.GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (eLight.eSpotScan == false)
        {
            direction = player.position - transform.position;
        }
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        movecharacter(movement);
    }
    public void movecharacter(Vector2 direction) 
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}

