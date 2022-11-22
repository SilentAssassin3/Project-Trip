using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Inventory inventory = new Inventory(4, 2, 10f, transform.position);
    }
}
