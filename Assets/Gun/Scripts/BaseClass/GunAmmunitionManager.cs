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

        [Header("Data")]

        [Tooltip("The current amount of ammunition we have. This has been serialized so we can see this number update from the inspector as well.")]
        [SerializeField] protected int currentAmmunition;

        [Tooltip("The ammount of ammunition this gun can hold. We use this as the starting value, and what value to reset to when reloading.")]
        [SerializeField] protected int ammunitionCapacity;

        #endregion

        #region Methods

        // This is public as we're calling this in GunShooter and classes
        // inheriting from it. We want to only have true passed in for isStarting
        // when setting values at statr of game. Otherwise, it should be false
        public abstract void UpdateAmmunition(int valueToUpdateBy, bool isStarting);

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