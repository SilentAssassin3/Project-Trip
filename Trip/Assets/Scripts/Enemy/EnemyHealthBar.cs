using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    //EnemyLight eLight;
    EnemyController Enemy;

    //Health Bar
    public GameObject eHealthBar;
    private Image ehealthBar;

    //Alert Bar
    public GameObject eAlertBar;
    public Image ealertBar;
    public float alertTime = 0.5f;
    public float alertCoolDown = 0;
    public bool playerClose = false;

    // Start is called before the first frame update
    void Start()
    {
        //eLight = FindObjectOfType<EnemyLight>();
        Enemy = FindObjectOfType<EnemyController>();

        ehealthBar = GetComponent<Image>();
        eHealthBar.SetActive(false);

        ealertBar = GetComponent<Image>();
        eAlertBar.SetActive(false);
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
