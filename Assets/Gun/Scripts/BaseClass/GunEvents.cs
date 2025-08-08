using System;
using UnityEngine;

namespace ReuseableStealthFramework.Gun
{
    /// <summary>
    /// This class holds events used by the Gun system, that are accessed by
    /// other classes
    /// </summary>
    public static class GunEvents
    {
        public static Action<Transform> OnEnemyHit;
    }
}