using UnityEngine;
using ReuseableStealthFramework.Gun;

namespace ReuseableStealthFramework.TeleportDasher
{
    /// <summary>
    /// This class handles registering shooting, and calling the needed methods
    /// for it.
    /// </summary>
    public class TeleportDashShooter : GunShooter
    {
        #region Variables

        [Header("Class Instances")]

        [Tooltip("Our reference to the PlayerTeleportingManager. We use this for calling teleporting functionality.")]
        [SerializeField] private PlayerTeleportingManager _playerTeleportingManager;

        #endregion

        #region Methods

        protected override void ShootWeapon()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_playerTeleportingManager != null)
                {
                    _playerTeleportingManager.TeleportDashPlayer();
                }
                if (_gunSoundEffectManager != null)
                {
                    _gunSoundEffectManager.PlaySoundEffect(0, transform.position);
                }
            }
        }

        #endregion

        #region Unity Methods

        void Update()
        {
            ShootWeapon();
        }

        #endregion
    }
}