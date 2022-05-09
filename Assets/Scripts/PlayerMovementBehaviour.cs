using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public GroundColliderBehaviour GroundCollider;
    [SerializeField]
    private float _moveSpeed;
    private Vector3 _moveDirection;
    [SerializeField]
    private float _jumpForce;

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
        if (GroundCollider.IsGrounded)
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += _moveDirection * _moveSpeed * Time.fixedDeltaTime;
    }
}
