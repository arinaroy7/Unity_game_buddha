using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private BuddhaController _buddhaController;
    [Space]
    [Header("Parametrs")]
    [SerializeField] private float _upperBound;
    [SerializeField] private float _lowerBound;
    private float _currentLevitationSpeed;
    private float _currentMoveSpeed;
    private Rigidbody2D _currentPlayer;
    private float _value;
    private void Start() 
    {
        SetBound();
    }
    private void SetBound() 
    {
        _currentLevitationSpeed = _buddhaController.LlevitationSpeed;
        _currentMoveSpeed = _buddhaController.MoveSpeed;
        _currentPlayer = _buddhaController.Player;
    }
    public static void GameOver() 
    {
        if (_currentPlayer )
    }
}

