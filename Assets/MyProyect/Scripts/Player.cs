using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components Player")] 
    private GatherInputs _mGatherInputs;
    private Transform _mPlayerTransform;
    private Rigidbody2D _mPlayerRigidbody;
    
    [Header("Move Settings")] 
    [SerializeField] private float speed;
    private int _direction = 1;
   private void Awake()
   {
       _mGatherInputs = this.GetComponent<GatherInputs>();
       _mPlayerTransform = this.GetComponent<Transform>();
       _mPlayerRigidbody = this.GetComponent<Rigidbody2D>();
   }

   // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        flip();
        
            _mPlayerRigidbody.linearVelocity = new Vector2(speed * _mGatherInputs.Value.x,
                _mGatherInputs.Value.y * speed);
    }

    private void flip()
    {
        if (_mGatherInputs.Value.x * _direction < 0)
        {
            HandleDirection();
        }
    }

    private void HandleDirection()
    {
        _mPlayerTransform.localScale = new Vector3(-_mPlayerTransform.localScale.x, 
            _mPlayerTransform.localScale.y, _mPlayerTransform.localScale.z);
        _direction *= -1;
    }
}
