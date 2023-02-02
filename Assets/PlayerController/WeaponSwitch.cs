using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public event Action<Weapon> WeaponChanged;

    private List<Weapon> weapons;

    public List<Weapon> Weapons { 
        get { 
            if(weapons == null) {
                weapons = GetComponentsInChildren<Weapon>(true).ToList();
            }
            return weapons; 
        }
    }

    private Weapon currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        EnableWeapon(0);
    }

    private void DisableAllWeapons() {
        Weapons.ForEach(weapon => weapon.gameObject.SetActive(false));
    }

    private void EnableWeapon(int index) {
        if (currentWeapon != null && currentWeapon.IsReloading)
            return;

        DisableAllWeapons();

        Debug.Log("Zmìnil jsi zbraò");
        Weapons[index].gameObject.SetActive(true);
        // nastala zmìna zbranì
        currentWeapon = Weapons[index];
        WeaponChanged?.Invoke(Weapons[index]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            EnableWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            EnableWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            EnableWeapon(2);
        }
    }
}
