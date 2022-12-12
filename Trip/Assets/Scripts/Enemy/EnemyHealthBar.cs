using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public GameObject eHealthBar;
    private Image ehealthBar;
    EnemyController Enemy;

    // Start is called before the first frame update
    void Start()
    {
        ehealthBar = GetComponent<Image>();
        Enemy = FindObjectOfType<EnemyController>();
        eHealthBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.health < Enemy.maxHealth)
        {
            eHealthBar.SetActive(true);
            ehealthBar.fillAmount = Enemy.health / (float)Enemy.maxHealth;
        }

    }
}
