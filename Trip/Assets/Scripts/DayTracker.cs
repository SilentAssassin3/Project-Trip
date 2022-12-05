using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTracker : MonoBehaviour
{
    public bool end = false;
    public bool time = false;
    private int waveNum = 1;
    private int dayNum = 1;
    public float eneSpawnNum;
    PlayerController Player;

    //Variables for calculating the difficulty increasing
    float exponentedDay;
    float dividedNum;
    float percentageNum;
    float remainingPercentage;
    float almostOverNum;
    float overNum;


    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (time == true)
        {
            //reset health
            //Health = maxhealth;

            if (end == true)
            {
                dayNum = 1;
            }

            else if (end == false)
            {

                dayNum++;

                while ( waveNum  < dayNum)
                {
                    exponentedDay = Mathf.Pow(dayNum, 2);
                    dividedNum = exponentedDay / 2;
                    percentageNum = dividedNum / 100;
                    remainingPercentage = 1 - percentageNum;


                     almostOverNum = exponentedDay * 0.2f;

                    //this will do i^dayNum
                    //eneSpawnNum = Math.Pow(i, dayNum);

                    //take ⅔ of eneSpawnNum
                    //make that 
                    //put enemies in random places on the map
                    //GameObject e = Instantiate(enemy, transform.position, Quaternion.identity);
                    waveNum++;
                }
                /*
                 9/2 9*2
                 /=
                 *=
                 +=
                 -=
                 Mathf.Pow for exponents
                 Mathf.Floor for rounding down
                 Mathf.Ceil For rounding up
                 */
            }

        }
    }

}
