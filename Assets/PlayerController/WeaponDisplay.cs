using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponDisplay : MonoBehaviour
{
    // reference na grafické objekty UI
    [SerializeField]
    Image weaponImage;

    [SerializeField]
    TMP_Text weaponName;

    [SerializeField]
    TMP_Text ammoCount;

    [SerializeField]
    Image reloadProgress;

    // reference na objekty, které potøebujeme pro registraci na události

    [SerializeField]
    WeaponSwitch weaponSwitch;

    // Start is called before the first frame update
    void Awake()
    {
        weaponSwitch.WeaponChanged += OnWeaponChanged;
        foreach(var weapon in weaponSwitch.Weapons) {
            weapon.AmmoChanged += OnAmmoChanged;
            weapon.ReloadStarted += OnReloadStarted;
            weapon.ReloadProgressChanged += OnReloadProgressChanged;
            weapon.ReloadEnded += OnReloadEnded;
        }
    }

    private void OnAmmoChanged(Weapon weapon) {
        SetAmmo(weapon);
    }

    private void OnWeaponChanged(Weapon weapon) {
        weaponImage.sprite = weapon.Sprite;
        weaponName.text = weapon.Nazev;

        // ammo change
        SetAmmo(weapon);
    }

    private void SetAmmo(Weapon weapon) {
        ammoCount.text = $"{weapon.CurrPocetNaboju}/{weapon.MaxPocetNaboju}";
    }

    private void OnReloadStarted() {
        reloadProgress.gameObject.SetActive(true);
        ammoCount.gameObject.SetActive(false);
    }

    private void OnReloadProgressChanged(float perc) { // 30% -> 0.3
        reloadProgress.fillAmount = perc;
    }

    private void OnReloadEnded() {
        reloadProgress.gameObject.SetActive(false);
        ammoCount.gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
