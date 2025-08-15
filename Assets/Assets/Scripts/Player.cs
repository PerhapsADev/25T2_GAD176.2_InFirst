using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int playerHealthValue = 1;
    public void TakesDamage()
    {
        Debug.Log("Player wouldve taken damage");
    }

}
