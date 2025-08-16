using UnityEngine;

namespace ReuseableStealthFramework.TeleportDasher
{
    public class PlayerTeleportingManager : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [Tooltip("This is the amount that the player's position will be incremented by each time the player fires the Teleport Dasher. It will update the Z axis of the player, moving them forward.")]
        [SerializeField] private float _amountToUpdatePositionBy;

        [Header("Component")]

        [Tooltip("The transform component of the player. We use this for updating the player's position when using the Teleport Dasher")]
        [SerializeField] private Transform _playerTransform;

        [Tooltip("The character controller component of the player. We want to have a reference to this to disable it when updting the position of the player, before enabling it again")]
        [SerializeField] private CharacterController _characterController;

        #endregion

        #region Methods

        public void TeleportDashPlayer()
        {
            Vector3 _updatedPlayerPosition = _playerTransform.position + _playerTransform.rotation * new Vector3(0, 0, 1) * _amountToUpdatePositionBy;

            _characterController.enabled = false;
            _playerTransform.position = _updatedPlayerPosition;
            _characterController.enabled = true;
        }

        #endregion
    }
}