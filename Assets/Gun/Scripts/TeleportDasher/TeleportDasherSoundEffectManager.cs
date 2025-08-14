using UnityEngine;
using ReuseableStealthFramework.Gun;

namespace ReuseableStealthFramework.TeleportDasher
{
    /// <summary>
    /// This class is used to play sound effects from the Teleport Dasher
    /// </summary>
    public class TeleportDasherSoundEffectManager : GunSoundEffectManager
    {
        public override void PlaySoundEffect(int soundEffectToPlay, Vector3 positionToPlaySoundEffect)
        {
            AudioSource.PlayClipAtPoint(gunSoundEffectCollection[soundEffectToPlay], positionToPlaySoundEffect);
        }
    }
}