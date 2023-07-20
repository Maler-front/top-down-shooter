public class InstantDamageCalculator : IDamageCalculator
{
    private float _damage = 10f;

    public float CalculateDamage()
    {
        return _damage;
    }
}
