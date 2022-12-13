using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyLight : MonoBehaviour
{
    EnemyHealthBar eBar;

    //Lights
    public GameObject eSpotScan;
    public GameObject eSpotAttack;


    // Start is called before the first frame update
    void Start()
    {
        eBar = FindObjectOfType<EnemyHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eSpotAttack)
        {
            //Enemy starts attacking (aka. enemy pathfinding and attack)
        }

        if (eSpotScan)
        {
            //Enemy starts wandering slowly (aka. enemy pathfinding)
        }

        if (eBar.alertCoolDown > eBar.alertTime)
        {
                eBar.alertCoolDown = 0;
                eBar.eAlertBar.SetActive(false);
                eSpotScan.SetActive(false);
                eSpotAttack.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            eBar.playerClose = true;
            while (eBar.playerClose)
            {
                eBar.eAlertBar.SetActive(true);
                while (eBar.alertCoolDown <= eBar.alertTime)
                {
                    eBar.alertCoolDown += Time.deltaTime;
                    eBar.ealertBar.fillAmount = eBar.alertCoolDown / eBar.alertTime;
                }
            }

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (eBar.alertCoolDown > 0 && eBar.playerClose)
            {
                eBar.playerClose = false;
            }
        }
    }
}
