using UnityEngine;
using ReuseableStealthFramework.Gun;

namespace ReuseableStealthFramework.PortableForcePusher
{
    /// <summary>
    /// This class handles the reloading of ammo for the Portable Force Pusher
    /// </summary>
    public class PortableForcePusherAmmunitionManager : GunAmmunitionManager
    {
        public override void UpdateAmmunition(int _valueToUpdateBy)
        {
            currentAmmunition += _valueToUpdateBy;
            Debug.Log("currentAmmunition has been updated to: " + currentAmmunition);
        }

        void Update()
        {
            base.ReloadAmmunition();
        }
    }
}