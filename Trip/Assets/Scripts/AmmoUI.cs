using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    private Image Ammo;
    PlayerController Player;

    // Start is called before the first frame update
    void Start()
    {
        Ammo = GetComponent<Image>();
        Player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Ammo.fillAmount = (float)Player.ammo / (float)Player.maxAmmo;
    }
}