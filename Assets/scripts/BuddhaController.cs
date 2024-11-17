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
    [SerializeField] private AudioClip _SoundDown;
    [SerializeField] private AudioClip _SoundUp;

    private float _value=0.5f;
    private AudioSource _audioSource;
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnButtonClicked() 
    {
        _value += _speedUpIncrement;
        if (_value > 1f)
        {
            _value = 1f;
        }
        if (_audioSource && _SoundUp)
        {
            _audioSource.PlayOneShot(_SoundUp);  // Воспроизведение звука увеличения
        }
    }
    private void Update() 
    {
        _value -= _moveSpeed * Time.deltaTime;
        if (_value < 0f)
        {
            _value = 0f;
            
        }
        if (_audioSource && _SoundDown)
        {
            _audioSource.PlayOneShot(_SoundDown);  // Воспроизведение звука уменьшения
        }
        UpdateBuddhaProgress();
    }
    private void UpdateBuddhaProgress()
    {
        _imageBuddha.position = Vector3.Lerp(_lowerBound.position, _upperBound.position, _value);
        _filledImage.fillAmount = _value;
    }
}