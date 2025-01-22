using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonInit : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] protected Health _health;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button?.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();
}