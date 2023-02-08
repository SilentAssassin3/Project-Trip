using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//Becuase of Time, and problems with the not being able to use UnityEngine.UI NameSpace this is not going to be used
public class EnemyHealthBar : MonoBehaviour
{
    //public GameObject eHealthBar;
    //public Image ehealthBar;
    EnemyController Enemy;

    //Alert Bar
    //public GameObject eAlertBar;
    //public Image ealertBar;
    public float alertTime = 0.5f;
    public float alertCoolDown = 0;
    public bool playerClose = false;

    // Start is called before the first frame update
    void Start()
    {
        //ehealthBar = GetComponent<Image>();
        Enemy = FindObjectOfType<EnemyController>();
       // eHealthBar.SetActive(false);

        //ealertBar = GetComponent<Image>();
        //eAlertBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Enemy.health < Enemy.maxHealth)
        {
           // eHealthBar.SetActive(true);
            //ehealthBar.fillAmount = Enemy.health / (float)Enemy.maxHealth;
        }
        */
    }
}
