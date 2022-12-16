using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class UIFollow : MonoBehaviour
{
    public Transform objectToFollow;
    //RectTransform rectTransform;
    private GameObject healthBar;
    private GameObject alertBar;

     void Start()
    {
        //rectTransform = GetComponent<RectTransform>();
        healthBar = GameObject.Find("/Canvas/HealthBar");
        alertBar = GameObject.Find("/Canvas/AlertBar");
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow != null)
        {
           // healthBar.GetComponent<RectTransform>().anchoredPosition = objectToFollow.localPosition;
            //healthBar.GetComponent<RectTransform>().anchoredPosition += new Vector2(-3.26353f, -2.064117f);
            //healthBar.GetComponent<RectTransform>().anchoredPosition += new Vector2(4.657063f, 1.838353f);

            //alertBar.GetComponent<RectTransform>().anchoredPosition = objectToFollow.localPosition;
            //alertBar.GetComponent<RectTransform>().anchoredPosition += new Vector2(-3.26353f, -2.064117f);
            //alertBar.GetComponent<RectTransform>().anchoredPosition += new Vector2(4.657063f, 1.838353f);
            /*
            healthBar.RectTransform.anchoredPosition = objectToFollow.localPosition;
            rectTransform.anchoredPosition += new Vector2(-3.26353f, -2.064117f);
            rectTransform.anchoredPosition += new Vector2(4.657063f, 1.838353f);
            */
        }

    }
}
