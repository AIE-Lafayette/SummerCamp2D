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
    [SerializeField]
    private HoverBehaviour _hoverBehaviour;

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
        _moveDirection.Normalize();

        float speed = _moveSpeed;

        if (!GroundCollider.IsGrounded)
            _moveDirection.x /= 2;

        _rigidbody.AddForce(_moveDirection * speed * Time.fixedDeltaTime,ForceMode.VelocityChange);

        _hoverBehaviour.enabled = _rigidbody.velocity.x != 0 && GroundCollider.IsGrounded;
    }
}
