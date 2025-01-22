public class ButtonHeal : ButtonInit
{
    private float _healthRegen = 20f;

    protected override void OnButtonClick()
    {
        _health.TakeHeal(_healthRegen);
    }
}
