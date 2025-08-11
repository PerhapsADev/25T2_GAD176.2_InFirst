using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRadiusManager : MonoBehaviour
{
    [SerializeField] private bool InShopRadius = false;
    [SerializeField] private GameObject UiPressE;
    [SerializeField] private GameObject ShopMenu;
    [SerializeField] private GameObject QuitShopButton;

    // Start is called before the first frame update
    void Start()
    {
        UiPressE.SetActive(false);
        ShopMenu.SetActive(false);
        QuitShopButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        InShopRadius = true;


        //This triggers Ui 'Press E' to appear on screen
        if (other.CompareTag("Player") == true)
        {
            UiPressE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InShopRadius = false;

        if (other.CompareTag("Player") == true)
        {
            UiPressE.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InShopRadius == true) ;
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ShopMenu.SetActive(true);
                QuitShopButton.SetActive(true);
            }
        }
    }
}
