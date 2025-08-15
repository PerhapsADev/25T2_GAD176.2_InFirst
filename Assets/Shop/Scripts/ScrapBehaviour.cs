using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReusableStealthFramework
{
    public class ScrapBehaviour : MonoBehaviour
    {
        [SerializeField] ShopManager Shop;

        private void OnTriggerEnter(Collider other)
        {
            //This scrap to be collected
            if (other.CompareTag("Player") == true)
            {
                Debug.Log("Scrap collected");
                Destroy(gameObject);
                Shop.GetComponent<ShopManager>().CollectScrap();
            }
        }

    }
}