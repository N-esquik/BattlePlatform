public class ButtonDamage : ButtonInit
{
    private float _damage = 20f;

    protected override void OnButtonClick()
    {
        _health.TakeDamage(_damage);
    }
}
