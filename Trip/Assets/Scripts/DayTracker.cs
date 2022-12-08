using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DayTracker : MonoBehaviour
{
    public bool end = false;
    public bool time = false;
    private int waveNum = 1;
    private int dayNum = 1;
    public float eneSpawnNum;
    PlayerController Player;

    Scene Scene;

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
        Scene = SceneManager.GetActiveScene();

        if (time == true)
        {
            //reseting health
            Player.health = Player.MaxHP;

            if (end == true)
            {
                dayNum = 1;
            }

            else if (end == false)
            {

                dayNum++;

                while ( waveNum  < dayNum)
                {
                    //percentageNum is the percentage of enemies, ramainingPercentage is the percentage of the non attacking npc's
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

                    //Make a condition to know when the Player is in the forest so that the for loop could work
                    if (Scene == SceneManager.GetSceneByBuildIndex(2))
                    {
                        //If we are adding more than one enemy type then make a thing that randomly makes an amount of them different types
                        for (int i = 0; i < enemieNum; i++)
                        {
                            //Make a Enemy PreFab!!! So that this can work
                            var ePosition = new Vector2(Random.Range(0f, 100f), Random.Range(0f, 100f));
                            //Instantiate(EnemyPreFabName, eposition, Quaternion.identity);
                        }

                        //This is only for one non attacking npc, if we want more we have to make a thing that randomly makes an amount of them differenty types of non attacking npc's
                        for (int j = 0; j < runnerNum; j++)
                        {
                            var rPosition = new Vector2(Random.Range(0f, 100f), Random.Range(0f, 100f));
                            //Instantiate(RunnerPreFabName, rPosition, Quaternion.identity);
                        }
                    }

                    waveNum++;
                }
                /*

                These are just notes about how to do math in c#

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
