using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon
{
    protected WeaponReloader _weaponReloader;
    protected IDamageCalculator _damageCalculator;
    protected Transform _shootPoint;
    protected GameObject _hitAnimation;
    private Button _shootButton;

    public Weapon(WeaponReloader weaponReloader, IDamageCalculator damageCalculator, Transform shootPoint, GameObject hitAnimation, Button shootButton)
    {
        _weaponReloader = weaponReloader;
        _damageCalculator = damageCalculator;
        _shootPoint = shootPoint;
        _hitAnimation = hitAnimation;
        _shootButton = shootButton;

        _shootButton.onClick.AddListener(Shoot);
    }

    public abstract void Shoot();

    public void HitAnimate(Vector2 position)
    {
        var obj = GameObject.Instantiate(_hitAnimation, position, Quaternion.identity);
        GameObject.Destroy(obj, 3f);
    }

    ~Weapon()
    {
        _shootButton.onClick.RemoveListener(Shoot);
    }
}
