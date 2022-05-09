using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColliderBehaviour : MonoBehaviour
{
    public bool IsGrounded;
    delegate bool Comparison(int num1, int num2);
    private int[] _nums;
    private Comparison _comparison;

    private void Start()
    {
        _comparison = LessThan;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
            IsGrounded = true;
    }

    public bool LessThan(int num1, int num2)
    {
        return num1 < num2;
    }

    public void Sort()
    {
        for (int i = 0; i < _nums.Length; i++)
        {
            for (int j = 0; j < _nums.Length; j++)
            {
                if (_comparison.Invoke(_nums[i], _nums[j]))
                {

                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor"))
            IsGrounded = false;

    }
}
