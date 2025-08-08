using UnityEngine;

namespace ReuseableStealthFramework.Gun
{
    /// <summary>
    /// This class contains methods and variables used for reloading the gun, that
    /// classes inheriting from this one will use
    /// </summary>
    public abstract class GunAmmunitionManager : MonoBehaviour
    {
        #region Variables
        
        // Unserialize when finished with testing
        protected int currentAmmunition;
        // Unserialize when finished with testing
        protected int ammunitionCapacity;

        #endregion

        #region Methods

        // This is public as we're calling this in GunShooter and classes
        // inheriting from it
        public abstract void UpdateAmmunition(int valueToUpdateBy);

        // Public as this is called in GunShooter + inheriting classes
        public int GetCurrentAmmunition()
        {
            Debug.Log("Returning currentAmmunition value: " + currentAmmunition);
            return currentAmmunition;
        }

        protected virtual void ReloadAmmunition()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (currentAmmunition <= 0)
                {
                    currentAmmunition = ammunitionCapacity;
                    Debug.Log("currentAmmunition is now: " + currentAmmunition);
                }
                else
                {
                    Debug.Log("currentAmmunition is: " + currentAmmunition + ". Use more!");
                }
            }
        }

        #endregion
    }
}