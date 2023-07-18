using UnityEngine;

public class LaserWeapon : Weapon
{
    private GameObject _laserEffect;
    private float _distance = 100f;

    public LaserWeapon(
        WeaponReloader reloader,
        IDamageCalculator damageCalculator,
        Transform shootPoint, 
        GameObject hitAnimation, 
        UnityEngine.UI.Button shootButton, 
        GameObject laserEffectPrefab) 
        
        : base(reloader, damageCalculator, shootPoint, hitAnimation, shootButton)
    {
        if (!laserEffectPrefab.TryGetComponent<LineRenderer>(out LineRenderer laser))
            Debug.LogError("A laser perfab that does not have a LineRenderer was transferred to the laser weapon");
       
        _laserEffect = laserEffectPrefab;
    }

    public override void Shoot()
    {
        RaycastHit2D raycastInfo = Physics2D.Raycast(_shootPoint.position, _shootPoint.up, _distance);

        Vector2 endPoint = raycastInfo.collider != null ? raycastInfo.point : _shootPoint.position + _shootPoint.up * _distance;
        new LaserAnimation(Object.Instantiate(_laserEffect), _shootPoint.position, raycastInfo.point);

        _weaponReloader.Reload();
    }
}
