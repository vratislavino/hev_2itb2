using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smg : Weapon
{
    protected override void ProcessShootingInput()
    {
        if (Input.GetButton("Fire1"))
        {
            if (CurrPocetNaboju > 0 && currShootCooldown <= 0 && currReloadTime <= 0)
            {
                Shoot();
            }
        }
    }

}
