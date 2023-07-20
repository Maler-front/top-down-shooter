using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _hitAnimation;
    private IDamageCalculator _damageCalculator;

    public void Inject(IDamageCalculator damageCalculator)
    {
        if (damageCalculator == null)
            Debug.LogError("You don't have a damageCalculator on the bullet prefab");
        _damageCalculator = damageCalculator;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Dealing Damage
        //Set hit animation
        Debug.Log("hit");
        Destroy(gameObject);
    }
}
