using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class EnemyLight : MonoBehaviour
{

    //Lights
    public GameObject eSpotScan;
    public GameObject eSpotAttack;

    EnemyHealthBar eBar;
   // public Image ealertBar;
    // Start is called before the first frame update
    void Start()
    {
        eBar = FindObjectOfType<EnemyHealthBar>();
        //eBar.ealertBar = GetComponent<Image>();
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            eBar.playerClose = true;
            while (eBar.playerClose)
            {
                //eBar.eAlertBar.SetActive(true);
                while (eBar.alertCoolDown < eBar.alertTime)
                {
                    eBar.alertCoolDown += Time.deltaTime;
                    //ealertBar.fillAmount = eBar.alertCoolDown / eBar.alertTime;
                }
            }
            if (eBar.alertCoolDown >= eBar.alertTime)
            {
                eBar.alertCoolDown = 0;
                eSpotScan.SetActive(false);
                eSpotAttack.SetActive(true);
                //eBar.eAlertBar.SetActive(false);
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
