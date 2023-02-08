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

    public GameObject enemy;

    Enemy Enemy;
    private Vector3 startPos;
    private Vector3 roamPos;

   // public Image ealertBar;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = FindObjectOfType<Enemy>();
        startPos = transform.position;
        roamPos = RoamingPos();

        enemy = GameObject.Find("000");
        eBar = FindObjectOfType<EnemyHealthBar>();
        eSpotScan.SetActive(true);
        //eBar.ealertBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy starts attacking

        if (eSpotScan)
        {
            //Enemy starts wandering slowly
            MoveTo(roamPos);
            float atRoamDis = 1f;
            if (Vector3.Distance(transform.position, roamPos) < atRoamDis)
            {
                roamPos = RoamingPos();
            }
        }
    }

    private Vector3 RoamingPos()
    {
        return startPos + new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized * Random.Range(10f, 70f);
    }

    private void MoveTo(Vector3 targetPos)
    {
        Enemy.direction = roamPos;
        Enemy.movecharacter(roamPos);
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
                    //ealertBar.fillAmount = eBar.alertCoolDown / eBar.alertTime; (UI for Trip doesn't work)
                }
            }
            if (eBar.alertCoolDown >= eBar.alertTime)
            {
                eBar.alertCoolDown = 0;
                eSpotScan.SetActive(false);
                eSpotAttack.SetActive(true);
                //eBar.eAlertBar.SetActive(false); (UI for Trip doesn't work)
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
