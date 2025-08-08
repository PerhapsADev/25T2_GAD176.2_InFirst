using System.Collections;
using System.Collections.Generic;
using ReusableStealthFramework.enemies;
using UnityEngine;
namespace ReusableStealthFramework.enemies
{

    public class Turret : BaseAutomatedAI
    {
        protected override void TargetSpotted()
        {
            base.TargetSpotted();
            // Add gun script to hurt player
        }

    }


}
