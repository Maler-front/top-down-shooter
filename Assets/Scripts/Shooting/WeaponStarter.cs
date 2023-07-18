using UnityEngine;
using UnityEngine.UI;

public class WeaponStarter : MonoBehaviour
{
    [SerializeField] private Weapons _weapon;
    [SerializeField] private Reloaders _reloadType;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _hitAnimation;
    [SerializeField] private Button _shootButton;
    [SerializeField] private GameObject _shootPrefab;

    private void Awake()
    {
        IDamageCalculator damageCalculator = new InstantDamageCalculator();
        WeaponReloader reloader = new StandartReload(_shootButton);

        /*switch (_reloadType)
        {
            case Reloaders.Standart:
                {
                    reloader = new StandartReload(_shootButton);
                    break;
                }
            case Reloaders.WithACounter:
                {

                    break;
                }
        }*/

        switch (_weapon)
        {
            case Weapons.Laser:
                {
                    new LaserWeapon(reloader, damageCalculator, _shootPoint, _hitAnimation, _shootButton, _shootPrefab);
                    break;
                }
            case Weapons.Bullet:
                {
                    new BulletWeapon(reloader, damageCalculator, _shootPoint, _hitAnimation, _shootButton, _shootPrefab);
                    break;
                }
        }
    }

    public enum Weapons
    {
        Laser,
        Bullet
    }

    public enum Reloaders
    {
        Standart,
        WithACounter
    }
}
