using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    PlayerController Player;
    //int bought;

    /*
     eG = Exponential growth
     iA = intitial amount
     gR = growth rate
    */

    float eG;
    float iA;
    float gR;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire_Rate()
    {
        
         iA = 1;
         gR = 0.2f;
        Exponential_Grow();

        MoneyUIScript.MoneyAmount -= (int)eG;

        Player.fireRate -= (Player.fireRate * 0.2f);
    }

    private void Exponential_Grow()
    {
        eG = iA * (1 + gR);
    }
}
