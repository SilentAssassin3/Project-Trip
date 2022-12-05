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
    int overAllNum;
    float almostEnemieNum;
    int enemieNum;
    float almostRunnerNum;
    int runnerNum;

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

                    //overallnum is the overall number of npc's that spawn
                    almostOverNum = exponentedDay * 0.2f;
                    overNum = exponentedDay + almostOverNum;
                    overAllNum = (int)Mathf.Ceil(overNum);

                    //EnemieNum is the number of attacking npc's that spawn
                    almostEnemieNum = overAllNum* percentageNum;
                    enemieNum = (int)Mathf.Ceil(almostEnemieNum);

                    //RunnerNum is the number of non attacking npc's that spawn
                    almostRunnerNum = overAllNum * remainingPercentage;
                    runnerNum = (int)Mathf.Ceil(almostRunnerNum);


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
