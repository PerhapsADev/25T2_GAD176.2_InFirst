using UnityEngine;

namespace ReuseableStealthFramework.Gun
{
    /// <summary>
    /// This class holds function releated to shooting that classes inheriting
    /// from must implement
    /// </summary>
    public abstract class GunShooter : MonoBehaviour
    {
        #region Variables

        [Tooltip("Our reference to the GunSoundEffectManager. We use this to play sound effects when firing our gun.")]
        [SerializeField] protected GunSoundEffectManager _gunSoundEffectManager;

        #endregion

        // Abstract is used for both methods as we want these to go with any gun,
        // and this is a specific system

        protected abstract void ShootWeapon();

        protected virtual void EnemyShotCheck(RaycastHit objectHit)
        {
            // Code here
        }
    }
}