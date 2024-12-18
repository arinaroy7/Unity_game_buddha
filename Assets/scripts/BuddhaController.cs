using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuddhaController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; 
    [SerializeField] private float _speedDownBuddha;
    [SerializeField] private float _speedUpIncrement; 
    [SerializeField] private Button _button;
    [SerializeField] private Image _filledImage;
    [SerializeField] private Transform _upperBound; 
    [SerializeField] private Transform _lowerBound; 
    [SerializeField] private Transform _imageBuddha;
    [SerializeField] private TextMeshProUGUI _ProgressBar;
    [SerializeField] private Material backgroundMaterial; 
    [SerializeField] private float _scrollSpeed = 0.8f;  

    private Vector2 _offset;
    private float _value = 0.5f;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
        ResetGame();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked() 
    {
        _value += _speedUpIncrement;
        if (_value > 1f)
        {
            _value = 1f;
        }
    }

    private void Update() 
    {
        float previousValue = _value;
        _value -= _moveSpeed * Time.deltaTime;
        _value = Mathf.Clamp(_value, 0f, 1f);

        _offset.y += _scrollSpeed * Time.deltaTime;
        backgroundMaterial.mainTextureOffset = _offset;

        UpdateBuddhaProgress();
    }

    private void UpdateBuddhaProgress()
    {
        _imageBuddha.position = Vector3.Lerp(_lowerBound.position, _upperBound.position, _value);
        _filledImage.fillAmount = _value;
    }

    private void ResetGame()
    {
        _value = 0.2f;
        _offset = Vector2.zero;
        backgroundMaterial.mainTextureOffset = _offset;
        UpdateBuddhaProgress();
    }
}

