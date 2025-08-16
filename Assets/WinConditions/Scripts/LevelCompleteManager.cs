using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReusableStealthFramework
{
    public class LevelCompleteManager : MonoBehaviour
    {
        [SerializeField] GameObject WinText;

        void OnTriggerEnter(Collider other)
        {
            WinText.SetActive(true);
        }


    }
}