using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
namespace LeightonCode
{

    public class BaseAutomatedAI : MonoBehaviour
    {
        public float viewRadius;
        public float viewAngle;

        [SerializeField] protected int damageValue = 10;
        [SerializeField] protected int healthValue = 10;

        
    }

}
