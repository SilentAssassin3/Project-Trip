using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Image ehealthBar;
    EnemyController Enemy;

    // Start is called before the first frame update
    void Start()
    {
        ehealthBar = GetComponent<Image>();
        Enemy = FindObjectOfType<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        ehealthBar.fillAmount = Enemy.health / (float)Enemy.maxHealth;
    }
}
