using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private BuddhaController _buddhaController;
    [Space]
    [Header("Parametrs")]
    [SerializeField] private Transform _upperBound;
    [SerializeField] private Transform _lowerBound;
    //public static GameManager Instance {get; private set;} Было надо для Instance
    public Transform UpperBound => _upperBound;
    private float _currentLevitationSpeed;
    private float _currentMoveSpeed;
    private float _value;
    private Rigidbody2D _rb;
    private Rigidbody2D _currentPlayer;
    private void OnEnable() 
    {
       _buddhaController.Dead += GameOver;
    }
    private void OnDisable() 
    {
       _buddhaController.Dead -= GameOver;
    }
    private void Start() 
    {
        SetBound();
    }
    private void SetBound() 
    {
        _currentLevitationSpeed = _buddhaController.LlevitationSpeed;
        _currentMoveSpeed = _buddhaController.MoveSpeed;
        _currentPlayer = _buddhaController.Player;
        _rb = _currentPlayer;
    }
    private void Update() 
    {
        CheckBounds();
    }
    private void CheckBounds()
    {
        if (_currentPlayer.position.y > _upperBound.position.y || _currentPlayer.position.y < _lowerBound.position.y) 
        {
            GameOver();
        }
        else 
        {
            GetLevel();
        }
    }
    public void GameOver() 
    {
        Debug.Log("Игра закончилась");
    }
    public void GetLevel() 
    {
        if (_value == 0) 
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _currentLevitationSpeed);
            _value = Mathf.Clamp01(_value + 0.1f); 
            float targetY = Mathf.Lerp(_lowerBound.position.y, _upperBound.position.y, _value);
            _rb.position = new Vector2(_rb.velocity.x, targetY);
        }
        if (_value == 1)
        {
            Debug.Log("Победа");
        }
    }
}

