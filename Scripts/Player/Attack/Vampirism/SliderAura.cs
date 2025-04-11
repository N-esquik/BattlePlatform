using UnityEngine;
using UnityEngine.UI;

public class SliderAura : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Vector3 _offset;

    private float _maxValueSlider = 1f;

    private void Awake()
    {
        _slider.maxValue = _maxValueSlider;
    }

    private void Start()
    {
        _slider.gameObject.SetActive(false);
    }

    private void Update()
    {
        TrackObject();
    }

    public void ShowDuration(float maxValue, float currentValue)
    {
        _slider.value = currentValue / maxValue;
    }

    public void ShowCooldown(float maxValue, float currentValue)
    {
        _slider.value = _maxValueSlider - (currentValue /  maxValue);
    }

    public void IsActive(bool isActive)
    {
        _slider.gameObject.SetActive(isActive);
    }

    private void TrackObject()
    {
        if (_slider != null)
        {
            _slider.transform.position = transform.position + _offset;
        }
    }
}
