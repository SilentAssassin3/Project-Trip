using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoneyUIScript.MoneyAmount += 1;
        Destroy(gameObject);
    }
}
