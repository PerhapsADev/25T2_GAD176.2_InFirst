using ReuseableStealthFramework.Gun;
using UnityEngine;

namespace ReuseableStealthFramework.PortableForcePusher
{
    /// <summary>
    /// This class registers input from the player to know when to fire a
    /// force push.
    /// </summary>
    public class PortableForcePushShooter : GunShooter
    {
        #region Variables

        [Header("Class References")]

        [Tooltip("We reference this class to get access to the isForcingPushing variable through public methods. We use them to tell the script when to start and stop force pushing functionality.")]
        [SerializeField] private ForcePusher _forcePusher;

        [Tooltip("We have a reference to this to access the UpdateAmmunition() function ")]
        [SerializeField] private PortableForcePusherAmmunitionManager _portableForcePusherAmmunitionManager;

        #endregion

        #region Methods

        protected override void ShootWeapon()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!_forcePusher.GetIsForcePushingValue())
                {
                    _forcePusher.ToggleIsForcePushing(true);
                    _portableForcePusherAmmunitionManager.UpdateAmmunition(-1);
                    _gunSoundEffectManager.PlaySoundEffect(0, transform.position);
                }
            }
        }

        #endregion

        #region Unity Methods

        private void Update()
        {
            ShootWeapon();
        }

        #endregion
    }
}