using UnityEngine;
using System;
using UnityEngine.UI;
public class BuddhaController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; 
    [SerializeField] private float _speedDownBuddha; 
    [SerializeField] private Button _button;
    [SerializeField] private Image _filledImage;
    [SerializeField] private Transform _upperBound; 
    [SerializeField] private Transform _lowerBound; 

    private float _value=0f;
    private bool isMovingUp = false;
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }
    private void OnButtonClicked() 
    {
        Debug.Log("Кнопка нажата");
        isMovingUp = true;
    }
    private void Update() 
    {
        if (isMovingUp) 
        {
            _value += _moveSpeed * Time.deltaTime;
            if (_value >= 1f)
            {
                _value = 1f;
                isMovingUp = false;
            }
        }
        else 
        {
            _value -= _moveSpeed * Time.deltaTime;
            if (_value <= 0f)
            {
                _value = 0f;
            }
        }
        transform.position = Vector3.Lerp(_lowerBound.position, _upperBound.position, _value);
        _filledImage.fillAmount = _value;
    }
}