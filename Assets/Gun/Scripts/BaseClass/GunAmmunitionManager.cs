using UnityEngine;

namespace InFirst.ReuseableStealthFramework.Gun.Reloading
{
    /// <summary>
    /// This class contains methods and variables used for reloading the gun, that
    /// classes inheriting from this one will use
    /// </summary>
    public abstract class GunAmmunitionManager : MonoBehaviour
    {
        #region Variables
        
        // Unserialize when finished with testing
        [SerializeField] protected int currentAmmunition;
        // Unserialize when finished with testing
        [SerializeField] protected int ammunitionCapacity;

        #endregion

        #region Methods

        // This is public as we're calling this in GunShooter and classes
        // inheriting from it
        public abstract void UpdateAmmunition(int valueToUpdateBy);

        // Public as this is called in GunShooter + inheriting classes
        public int GetCurrentAmmunition()
        {
            return currentAmmunition;
        }

        protected virtual void ReloadAmmunition()
        {
            currentAmmunition = ammunitionCapacity;
        }

        #endregion
    }
}