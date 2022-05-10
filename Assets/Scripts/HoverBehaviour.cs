using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBehaviour : MonoBehaviour
{
    public float Speed;
    [SerializeField]
    private float _maxHeight;
    private Vector3 _startPos;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float lerpTime = Mathf.Clamp(Mathf.Sin(Time.time * Speed), 0, 1);
        transform.localPosition = Vector3.Lerp(_startPos, _startPos + Vector3.up * _maxHeight, lerpTime);
    }
}
