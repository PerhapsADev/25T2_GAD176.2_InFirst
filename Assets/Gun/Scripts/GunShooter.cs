using UnityEngine;

namespace InFirst.ReuseableStealthFramework.Gun.Shooting
{
    /// <summary>
    /// This class holds function releated to shooting that classes inheriting
    /// from must implement
    /// </summary>
    public abstract class GunShooter : MonoBehaviour
    {
        // Abstract is used for both methods as we want these to go with any gun,
        // and this is a specific system

        protected abstract void ShootWeapon();

        protected abstract void EnemyShotCheck(RaycastHit objectHit);
    }
}