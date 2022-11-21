using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth = 3f;
    PlayerController Player;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = Player.health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
