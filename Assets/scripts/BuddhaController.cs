using UnityEngine;
using System;
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

    private float _value=0.5f;
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
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
        _value -= _moveSpeed * Time.deltaTime;
        if (_value < 0f)
        {
            _value = 0f;
            
        }
        UpdateBuddhaProgress();
    }
    private void UpdateBuddhaProgress()
    {
        _imageBuddha.position = Vector3.Lerp(_lowerBound.position, _upperBound.position, _value);
        _filledImage.fillAmount = _value;
    }
}