using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Action<Vector2> _hitAnimation;
    private IDamageCalculator _damageCalculator;

    public void Inject(Action<Vector2> hitAnimation, IDamageCalculator damageCalculator)
    {
        if (damageCalculator == null)
            Debug.LogError("You don't have a damageCalculator on the bullet prefab");
        _damageCalculator = damageCalculator;

        if (hitAnimation == null)
            Debug.LogError("You don't have a hitAnimation on the bullet prefab");
        _hitAnimation = hitAnimation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Dealing Damage

        _hitAnimation.Invoke(transform.position);
        Destroy(gameObject);
    }
}
