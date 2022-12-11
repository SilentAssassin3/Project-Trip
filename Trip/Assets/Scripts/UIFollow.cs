using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollow : MonoBehaviour
{
    public Transform objectToFollow;
    RectTransform rectTransform;

    private void Awake()
    {
       rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow != null)
        {
            rectTransform.anchoredPosition = objectToFollow.localPosition;
            rectTransform.anchoredPosition += new Vector2(-3.26353f, -2.064117f);
            rectTransform.anchoredPosition += new Vector2(4.657063f, 1.838353f);
        }

    }
}
