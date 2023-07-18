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
        var bullet = Object.Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);

        if(!bullet.TryGetComponent<Bullet>(out Bullet bulletComponent))
        {
            Debug.LogError($"You don't have Bullet component in your bullet prefab called {bullet.name}");
            return;
        }
        bulletComponent.Inject(_damageCalculator);

        if (!bullet.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
        {
            Debug.LogError($"You don't have Rigidbody2D component in your bullet prefab called {bullet.name}");
            return;
        }
        rigidbody.AddForce(_shootPoint.up * 50f, ForceMode2D.Impulse);

        _weaponReloader.Reload();
    }
}
