using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public event Action<Weapon> AmmoChanged;
    public event Action ReloadStarted;
    public event Action ReloadEnded;
    public event Action<float> ReloadProgressChanged;


    [SerializeField]
    protected int maxPocetNaboju;

    public int MaxPocetNaboju => maxPocetNaboju;

    protected int currPocetNaboju;

    public int CurrPocetNaboju {
        get { return currPocetNaboju; }
        protected set {
            currPocetNaboju = value;
            AmmoChanged?.Invoke(this);
        }
    }

    [SerializeField]
    private string nazev;
    public string Nazev => nazev;

    [SerializeField]
    protected float shootCooldown;
    protected float currShootCooldown;

    protected int damage;

    [SerializeField]
    protected float reloadTime;
    protected float currReloadTime;

    public bool IsReloading => currReloadTime > 0;

    [SerializeField]
    protected GameObject bulletPrefab;

    [SerializeField]
    protected Transform shootingPoint;

    [SerializeField]
    protected float bulletSpeed;

    [SerializeField]
    protected Sprite sprite;

    public Sprite Sprite => sprite;


    void Start()
    {
        CurrPocetNaboju = maxPocetNaboju;
    }

    protected virtual void Update()
    {
        TimeUpdate();

        ProcessReloadInput();
        ProcessShootingInput();
    }

    protected void TimeUpdate()
    {
        if (currReloadTime > 0) // pokud pøebíjím
        { 
            currReloadTime -= Time.deltaTime;
            
            ReloadProgressChanged?.Invoke(currReloadTime / reloadTime);

            if (currReloadTime <= 0)
                Reload();
        }

        if (currShootCooldown > 0) // pokud bych pøekroèil max kadenci
            currShootCooldown -= Time.deltaTime;
    }

    protected void ProcessReloadInput()
    {
        if(Input.GetKeyDown(KeyCode.R) && currReloadTime <= 0)
        {
            currReloadTime = reloadTime;
            ReloadStarted?.Invoke();
        }
    }

    protected virtual void ProcessShootingInput()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(CurrPocetNaboju > 0 && currShootCooldown <= 0 && currReloadTime <= 0)
            {
                Shoot();
            }
        }
    }

    protected void Reload()
    {
        CurrPocetNaboju = maxPocetNaboju;
        ReloadEnded?.Invoke();
    }

    protected virtual void Shoot()
    {
        currShootCooldown = shootCooldown;
        CurrPocetNaboju--;

        var bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    
    }
}
