using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;
    public float Acceleration;
    public float MaxSpeed;
    public float JumpPower;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetMoveDirection(Vector3 moveDirection)
    {
        _moveDirection = moveDirection;
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.AddForce(_moveDirection * Acceleration * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (_rigidbody.velocity.magnitude > MaxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * MaxSpeed;
        }
    }
}
