using ReuseableStealthFramework.Gun;
using UnityEngine;

namespace ReuseableStealthFramework.PortableForcePusher
{
    /// <summary>
    /// This class handles playing sound effects for the Portable Force Pusher
    /// </summary>
    public class PortableForcePusherSoundEffectManager : GunSoundEffectManager
    {
        public override void PlaySoundEffect(int soundEffectToPlay, Vector3 positionToPlaySoundEffect)
        {
            AudioSource.PlayClipAtPoint(gunSoundEffectCollection[soundEffectToPlay], positionToPlaySoundEffect);
        }
    }
}