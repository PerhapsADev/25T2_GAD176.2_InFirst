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
            RaycastHit[] _temporaryRaycastHitArray = Physics.SphereCastAll(_positionToCreateSphereCast.position, _sphereCastRadius, transform.forward, 0f, 6) as RaycastHit[];
            List<RaycastHit> _objectsReturnedBySphereCast = _temporaryRaycastHitArray.ToList();

            for (int listIndex = 0; listIndex < _objectsReturnedBySphereCast.Count ; listIndex++)
            {
                if (_objectsReturnedBySphereCast[listIndex].rigidbody != null)
                {
                    _objectsToForcePush.Add(_objectsReturnedBySphereCast[listIndex].rigidbody);
                }
            }

            _objectsReturnedBySphereCast.Clear();
            return _objectsToForcePush;
        }

        public void RemoveObjectsFromForcePushList()
        {
            _objectsToForcePush.Clear();
        }

        #endregion
    }
}