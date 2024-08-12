using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class BuddhaController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; 
    [SerializeField] private float _levitationSpeed; 
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private Vector2  _vectro2;
    private Rigidbody2D rb; 
    public float MoveSpeed => _moveSpeed;
    public float LlevitationSpeed => _levitationSpeed;
    public Rigidbody2D Player => _player; 
    private void Update() 
    {
        MovePlayer();
    }
    private void MovePlayer() 
    {
        rb = GetComponent<Rigidbody2D>(); 
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, _moveSpeed); 
        }
        else 
        {
            GameManager.GameOver();
        }
    }
}
