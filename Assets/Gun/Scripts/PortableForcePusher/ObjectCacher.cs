using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ReuseableStealthFramework.PortableForcePusher
{
    /// <summary>
    /// This class handles the obtaining and removing of references to objects
    /// that the player uses to force push.
    /// </summary>
    public class ObjectCacher : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [Tooltip("How large the radius of our sphere cast will be. This sphere cast is the one used to grab references to the objects we will force push infront of the player.")]
        [SerializeField] private float _sphereCastRadius;

        [Tooltip("This is the layermask we look for when knowing which objects should be affected by the force push.")]
        [SerializeField] private LayerMask _layerMask;

        [Header("Components")]

        [Tooltip("This should refer to the transform component where we would want to create our sphere cast. In this case, in front of us.")]
        [SerializeField] private Transform _positionToCreateSphereCast;

        [Tooltip("This list is where the objects we can force push that are obtained by our sphere cast will go. New objects will be added and removed through the game time.")]
        [SerializeField] private List<Rigidbody> _objectsToForcePush = new List<Rigidbody>();

        #endregion

        #region Methods

        public List<Rigidbody> GetObjectsToForcePush()
        {
            // We use SphereCastAll here rather than CheckSphere or other related
            // methods, as SphereCastAll can detect colliders already colliding
            // with it when created.
            Collider[] _temporaryRaycastHitArray = Physics.OverlapSphere(_positionToCreateSphereCast.position, _sphereCastRadius, _layerMask);
            Debug.Log("_temporaryRaycastHitArray is equal to [" + _temporaryRaycastHitArray.Length + "]");
            //Collider[] _objectsReturnedBySphereCast = _temporaryRaycastHitArray;

            for (int arrayIndex = 0; arrayIndex < _temporaryRaycastHitArray.Length ; arrayIndex++)
            {
                if (_temporaryRaycastHitArray[arrayIndex].gameObject.GetComponent<Rigidbody>() != null)
                {
                    _objectsToForcePush.Add(_temporaryRaycastHitArray[arrayIndex].gameObject.GetComponent<Rigidbody>());
                    Debug.Log("[" + arrayIndex + "]x time adding rigidbody to list!");
                }
                Debug.Log("[" + arrayIndex + "]x for loop is looped through!");
            }

            Debug.Log("objectsToForcePush has [" + _objectsToForcePush.Count + "]");
            //_objectsReturnedBySphereCast = null;
            //Debug.Log("objectsToForcePush now has [" + _objectsToForcePush.Count + "] after clearing objectsReturnedBySphereCast");
            return _objectsToForcePush;
        }

        public void RemoveObjectsFromForcePushList()
        {
            _objectsToForcePush.Clear();
        }

        #endregion

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_positionToCreateSphereCast.position, _sphereCastRadius);
        }
    }
}