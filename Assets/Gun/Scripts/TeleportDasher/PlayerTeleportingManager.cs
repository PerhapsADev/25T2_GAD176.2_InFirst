using UnityEngine;

namespace ReuseableStealthFramework.TeleportDasher
{
    public class PlayerTeleportingManager : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [Tooltip("This is the amount that the player's position will be incremented by each time the player fires the Teleport Dasher.")]
        [SerializeField] private Vector3 _amountToUpdatePositionBy;

        [Header("Component")]

        [Tooltip("The transform component of the player. We use this for updating the player's position when using the Teleport Dasher")]
        [SerializeField] private Transform _playerTransform;

        [Tooltip("The character controller component of the player. We want to have a reference to this to disable it when updting the position of the player, before enabling it again")]
        [SerializeField] private CharacterController _characterController;

        #endregion

        #region Methods

        public void TeleportDashPlayer()
        {
            Vector3 _updatedPlayerPosition = new Vector3(_playerTransform.position.x, _playerTransform.position.y, _playerTransform.position.z);

            _updatedPlayerPosition += _amountToUpdatePositionBy;

            _characterController.enabled = false;
            _playerTransform.position = _updatedPlayerPosition;
            _characterController.enabled = true;
        }

        #endregion
    }
}