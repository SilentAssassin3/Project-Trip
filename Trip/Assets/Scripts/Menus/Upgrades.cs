using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    PlayerController Player;
    EnemyController EnemyCon;
    Enemy EnemyPF;

    /*
     FR = Fire Rate
     QR = Quick Reload
     F = Fire
     I = Ice
     */
    int boughtFR = 0;
    int boughtQR = 0;
    int boughtF = 0;
    int boughtI = 0;

    /*
     eG = Exponential growth
     iA = intitial amount
     gR = growth rate
    */
    float eG;
    float iA;
    float gR;

    float fireDuration = 1f;
    float fireCoolDown = 0;
    float fireInterval = 0.2f;
    float fireICoolDown = 0;

    float iceDuration = 1f;
    float iceCoolDown = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<PlayerController>();
        EnemyCon = GetComponent<EnemyController>();
        EnemyPF = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire_Rate()
    {
        
         iA = boughtFR;
         gR = 0.2f;
        Exponential_Grow();
        MoneyUIScript.MoneyAmount -= (int)Mathf.Ceil(eG);

        Player.fireRate -= (Player.fireRate * 0.2f);

        boughtFR++;
    }

    public void Quick_Reload()
    {
        iA = boughtQR;
        gR = 0.2f;
        Exponential_Grow();
        MoneyUIScript.MoneyAmount -= (int)Mathf.Ceil(eG);

        Player.reloadTime -= (Player.reloadTime * 0.2f);

        boughtQR++;
    }

    public void Fire()
    {
        iA = boughtF;
        gR = 0.5f;
        Exponential_Grow();
        MoneyUIScript.MoneyAmount -= (int)Mathf.Ceil(eG);

        //using eG as the fireDamage growth
        iA = boughtF;
        gR = 1;
        Exponential_Grow();

        //When the Player's Bullet hits an Enemy
        if (EnemyCon.hit == true)
        {
            while (fireCoolDown < fireDuration)
            {
                fireCoolDown += Time.deltaTime;
            }
        }
        while (fireCoolDown > 0)
        {
            while (fireICoolDown < fireInterval)
            {
                fireICoolDown += Time.deltaTime;
            }
        }
        if (fireICoolDown >= fireInterval)
        {
            fireICoolDown = 0;
            EnemyCon.health -= (int)Mathf.Floor(eG);
        }
        if (fireCoolDown >= fireDuration)
        {
            fireCoolDown = 0;
        }

        boughtF++;
    }

    public void Ice()
    {
        iA = boughtI;
        gR = 0.5f;
        Exponential_Grow();
        MoneyUIScript.MoneyAmount -= (int)Mathf.Ceil(eG);

        iA = boughtI;
        gR = 0.2f;
        Exponential_Grow();


        //When the Player's Bullet hits an Enemy
        if (EnemyCon.hit == true)
        {
            EnemyPF.moveSpeed -= eG;

            while (iceCoolDown < iceDuration)
            {
                iceCoolDown += Time.deltaTime;
            }
        }
        if (iceCoolDown >= iceDuration)
        {
            iceCoolDown = 0;
        }

        boughtI++;
    }

    private void Exponential_Grow()
    {
        /*
         To graph the growth of something, use this equation:
         f(x) = i(1+r)^x
         i = initial
         r = growth rate
         */
        eG = iA * (1 + gR);
    }
}
