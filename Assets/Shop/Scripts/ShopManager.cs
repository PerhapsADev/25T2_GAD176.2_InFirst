using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ReusableStealthFramework
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private GameObject ShopMenu;
        [SerializeField] public TextMeshProUGUI output;

        private int Scraps = 0;

        // Update is called once per frame
        void Update()
        {
            output.text = "Scrap: " + Scraps;

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (Scraps >= 250);
                {
                    Scraps -= 250;
                    //Add code that will active script for purchaseble item
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (Scraps >= 50);
                {
                    Scraps -= 50;
                    //Add code that will active script for purchaseble item
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (Scraps >= 100) ;
                {
                    Scraps -= 100;
                    //Add code that will active script for purchaseble item
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (Scraps >= 150) ;
                {
                    Scraps -= 150;
                    //Add code that will active script for purchaseble item
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (Scraps >= 200) ;
                {
                    Scraps -= 200;
                    //Add code that will active script for purchaseble item
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                if (Scraps >= 250) ;
                {
                    Scraps -= 250;
                    //Add code that will active script for purchaseble item
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                if (Scraps >= 100) ;
                {
                    Scraps -= 100;
                    //Add code that will active script for purchaseble item
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                if (Scraps >= 0) ;
                {
                    Scraps -= 0;
                    //Add code that will active script for purchaseble item
                }
            }
        }

        public void CloseShop()
        {
            ShopMenu.SetActive(false);
        }

        public void CollectScrap()
        {
            Scraps += Random.Range(10, 61);
        }
    }
}
