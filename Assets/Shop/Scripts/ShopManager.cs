using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject ShopMenu;
    [SerializeField] private bool ShopMenuOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (ShopMenuOpen == true)
        {

        }
    }

    public void CloseShop()
    {
        ShopMenu.SetActive(false);
    }
}
