using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
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
        healthBar.fillAmount = Player.health / (float)Player.MaxHP;
    }
}