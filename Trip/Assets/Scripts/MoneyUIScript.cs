using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class MoneyUIScript : MonoBehaviour
{
    TextElement text;
    public static int MoneyAmount;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextElement>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = MoneyAmount.ToString();
    }
}
