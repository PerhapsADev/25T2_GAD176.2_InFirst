using UnityEngine;

namespace InFirst.ReuseableStealthFramework.BoxHiding.Equipper
{
    /// <summary>
    /// This class manages the caching and removal of references to boxes the player can interact with
    /// </summary>
    public class BoxReachDistance : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform currentBoxInReach; // Unserialise after testing

        #endregion

        #region Methods

        public Transform GetCurrentBoxInReach()
        {
            return currentBoxInReach;
        }

        private void InitialiseCurrentBoxInReach(Collider box)
        {
            if (box.gameObject.CompareTag("Box"))
            {
                currentBoxInReach = box.GetComponent<Transform>();
            }
        }

        private void SetCurrentBoxInReachToNull(Collider box)
        {
            if (box.gameObject.CompareTag("Box"))
            {
                currentBoxInReach = null;
            }
        }

        #endregion

        #region Unity Events

        private void OnTriggerEnter(Collider other)
        {
            // Called in method rather writing code here to further compartmentalise code
            InitialiseCurrentBoxInReach(other);
        }

        private void OnTriggerExit(Collider other)
        {
            // Called in method rather writing code here to further compartmentalise code
            SetCurrentBoxInReachToNull(other);
        }

        #endregion
    }
}