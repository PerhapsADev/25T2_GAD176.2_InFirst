using UnityEngine;
using ReuseableStealthFramework.Gun;
using Unity.VisualScripting;

namespace ReuseableStealthFramework.PortableForcePusher
{
    /// <summary>
    /// This class handles the reloading of ammo for the Portable Force Pusher
    /// </summary>
    public class PortableForcePusherAmmunitionManager : GunAmmunitionManager
    {
        public override void UpdateAmmunition(int _valueToUpdateBy, bool isStarting)
        {
            if (currentAmmunition > 0 && currentAmmunition <= ammunitionCapacity || isStarting)
            {
                currentAmmunition += _valueToUpdateBy;
                Debug.Log("currentAmmunition has been updated to: " + currentAmmunition);
            }
        }

        #region Unity Methods

        private void Start()
        {
            UpdateAmmunition(ammunitionCapacity, true);
        }

        void Update()
        {
            base.ReloadAmmunition();
        }

        #endregion
    }
}