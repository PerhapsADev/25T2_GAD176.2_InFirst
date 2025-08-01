using UnityEngine;

namespace InFirst.ReuseableStealthFramework.BoxHiding.Equipper
{
    /// <summary>
    /// This class handles the equipping and unequipping of the box. 
    /// </summary>
    public class BoxEquipper : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private bool isHidingUnderBox; // Unserialise after testing

        [Header("Components")]

        [SerializeField] private Transform currentBoxHeld; //Unserialise after testing

        [SerializeField] private Transform positionToSpawnBoxOnPlayer;

        [Header("Scripts")]

        [SerializeField] private BoxReachDistance boxReachDistance;

        #endregion

        #region Methods

        private void CheckForEquipButtonPressed()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Equipping and unequipping is split into two methods to attempt to follow first principle of SOLID
                EquipBox();
                UnequipBox();
            }
        }

        private void EquipBox()
        {
            if (!CheckIfBoxHasBeenEquipped())
            {
                if (boxReachDistance.GetCurrentBoxInReach() != null)
                {
                    currentBoxHeld = boxReachDistance.GetCurrentBoxInReach();

                    currentBoxHeld.position = new Vector3(positionToSpawnBoxOnPlayer.position.x, positionToSpawnBoxOnPlayer.position.y + 2, positionToSpawnBoxOnPlayer.position.z);

                    currentBoxHeld.parent = positionToSpawnBoxOnPlayer;

                    isHidingUnderBox = true;
                }
                else
                {
                    Debug.Log("Either there is no box in reach recognised, or you forgot to initialise the boxReachDistance field");
                }
            }
        }

        private void UnequipBox()
        {
            if (CheckIfBoxHasBeenEquipped())
            {
                currentBoxHeld.position = new Vector3(currentBoxHeld.position.x, currentBoxHeld.position.y, currentBoxHeld.position.z + 2.5f);

                currentBoxHeld.parent = null;

                currentBoxHeld = null;

                isHidingUnderBox = false;
            }
        }

        private bool CheckIfBoxHasBeenEquipped()
        {
            switch (isHidingUnderBox)
            {
                case true:
                    Debug.Log("The player is already hiding underneath a box!");
                    return true;
                case false:
                    return false;
            }
        }

        #endregion

        #region Unity Methods

        void Update()
        {
            CheckForEquipButtonPressed();
        }

        #endregion
    }
}