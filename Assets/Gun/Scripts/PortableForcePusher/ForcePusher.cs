using System.Collections.Generic;
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

        [Tooltip("The multiplier for the amount of force applied to objects. Increasing this value will make the force push more powerful.")]
        [SerializeField] private float _forceAmount;

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
            //Debug.Log("ForcePushObjects method called!");

            if (_isForcePushing)
            {
                Debug.Log("We are currently force pushing objects");

                List<Rigidbody> _objectsToForcePush = new List<Rigidbody>();
                _objectsToForcePush = _objectCacher.GetObjectsToForcePush();
                Debug.Log("We are force pushing [" + _objectsToForcePush.Count + "] objects.");

                for (int objectToAddForceTo = 0; objectToAddForceTo < _objectsToForcePush.Count; objectToAddForceTo++)
                {
                    _objectsToForcePush[objectToAddForceTo].AddForce(directionToPush * _forceAmount, forceModeToUse);
                }

                _objectCacher.RemoveObjectsFromForcePushList();
                _isForcePushing = false;
            }
        }

        #endregion

        #region Unity Methods

        private void FixedUpdate()
        {
            ForcePushObjects(transform.forward, _forceModeForForcePush);
        }

        #endregion
    }
}