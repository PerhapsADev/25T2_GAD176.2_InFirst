using UnityEngine;

namespace InFirst.ReuseableStealthFramework.Gun.Audio
{
    /// <summary>
    /// This class handles the sound effect functionality of the gun. Other
    /// classes inheriting from it use these functions and variables
    /// </summary>
    public abstract class GunSoundEffectManager : MonoBehaviour
    {
        #region Variables

        [Header("Data (Base class)")]

        [Tooltip("The sound effects that the gun has to use. When calling the PlaySoundEffect method, a number should be given that corresponds to the index of the soundeffect in this array to play it.")]
        // An array is used as our sounds effects we use are predetermined
        [SerializeField] protected int[] gunSoundEffectCollection;

        #endregion

        #region Methods

        public abstract void PlaySoundEffect(int soundEffectToPlay, Vector3 positionToPlaySoundEffect);

        #endregion
    }
}