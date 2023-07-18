using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeapon : Weapon
{
    private GameObject _bulletPrefab;

    public BulletWeapon(
        WeaponReloader reloader,
        IDamageCalculator damageCalculator,
        Transform shootPoint,
        GameObject hitAnimation,
        UnityEngine.UI.Button shootButton,
        GameObject bulletPrefab)

        : base(reloader, damageCalculator, shootPoint, hitAnimation, shootButton)
    {
        _bulletPrefab = bulletPrefab;
    }

    public override void Shoot()
    {
        _weaponReloader.Reload();
        throw new System.NotImplementedException();
    }
}
