using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace InFirst.ReuseableStealthFramework.Gun.TeleportDasher
{
    public class PlayerTeleportingManager : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [Tooltip("This is the amount that the player's position will be incremented by each time the player fires the Teleport Dasher.")]
        [SerializeField] private Vector3 _amountToUpdatePositionBy;

        [Header("Class Instances")]

        [Tooltip("Our reference to PlayerTransformHolder. We use this to obtain a reference to the transform component on the player.")]
        [SerializeField] private PlayerTransformHolder _playerTransformHolder;

        #endregion

        #region Methods

        public void TeleportDashPlayer()
        {
            Vector3 _updatedPlayerPosition = new Vector3(_playerTransformHolder.PlayerTransformPosition.x, _playerTransformHolder.PlayerTransformPosition.y, _playerTransformHolder.PlayerTransformPosition.z);

            _updatedPlayerPosition += _amountToUpdatePositionBy;

            _playerTransformHolder.PlayerTransformPosition = _updatedPlayerPosition;
        }

        #endregion
    }
}