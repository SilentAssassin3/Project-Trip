using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
//Problems with not being able to use UnityEngine.UI
public class AmmoUI : MonoBehaviour
{
    //private Image Ammo;
    PlayerController Player;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        //Ammo = GetComponent<Image>();
        Player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       // Ammo.fillAmount = (float)Player.ammo / (float)Player.maxAmmo;
    }
}

