using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InFirst.ReuseableStealthFramework.Gun.TeleportDasher
{
    /// <summary>
    /// This class holds access to the transform component on the player controller.
    /// It is responsible for changes done to it as well.
    /// </summary>
    public class PlayerTransformHolder : MonoBehaviour
    {
        #region Variables

        [Header("Components")]

        [Tooltip("Our reference to the transform component on the player controller.")]
        [SerializeField] private Transform _playerTransform;

        #endregion

        // No particular reason for using getter over method.
        // Just wanted to try it out + doesn't seem like it
        // makes too much of a difference
        public Vector3 PlayerTransformPosition
        {
            get 
            { 
                return new Vector3(_playerTransform.position.x, _playerTransform.position.y, _playerTransform.forward.z); 
            }
            set
            {
                _playerTransform.position = value;
            }
        }
    }
}