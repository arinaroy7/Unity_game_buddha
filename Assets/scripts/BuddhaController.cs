using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System;
public class BuddhaController : MonoBehaviour
{
    public event Action Dead;

    [SerializeField] private float _moveSpeed; 
    [SerializeField] private float _levitationSpeed; 
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private Button _button;

    public float MoveSpeed => _moveSpeed;
    public float LlevitationSpeed => _levitationSpeed;
    public Rigidbody2D Player => _player; 

    private void Update() 
    {
        MovePlayer();
    }
    private void MovePlayer() 
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<GameManager>().GetLevel();
        }
        else if (GameManager.Instance._value == 0)
        {
            FindObjectOfType<GameManager>().GameOver(); // тут в логике запуталась
        }*/
    }
    private void PlayerDead() 
    {
        Dead?.Invoke();
    }
}
