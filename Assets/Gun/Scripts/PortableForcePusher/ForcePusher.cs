using UnityEngine;

namespace ReuseableStealthFramework.PortableForcePusher
{
    /// <summary>
    /// This class handles the actuall pushing of objects when the gun is fired
    /// </summary>
    public class ForcePusher : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [Tooltip("The direction the objects will be force pushed into. For the purpose of this gun, it should be in a forward direction.")]
        [SerializeField] private Vector3 _directionForForcePush;

        [Tooltip("The type of force we want to apply to our objects being force pushed. This may be changed depending on what feeling is desired.")]
        [SerializeField] private ForceMode _forceModeForForcePush;

        private bool _isForcePushing = false;

        [Header("Class References")]

        [Tooltip("We reference this script to get the objects we need to force push through a list.")]
        [SerializeField] private ObjectCacher _objectCacher;

        #endregion

        #region Methods

        public bool GetIsForcePushingValue()
        {
            return _isForcePushing;
        }

        public void ToggleIsForcePushing(bool value)
        {
            _isForcePushing = value;
        }

        private void ForcePushObjects(Vector3 directionToPush, ForceMode forceModeToUse)
        {
            // Code here
        }

        #endregion

        #region Unity Methods

        private void FixedUpdate()
        {
            ForcePushObjects(_directionForForcePush, _forceModeForForcePush);
        }

        #endregion
    }
}