using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _timeBetweenShakes;
    [SerializeField]
    private float _strength;
    [SerializeField]
    private float _duration;
    private Vector3 _startPosition;
    [SerializeField]
    private bool _shakeEnabled;
    private float _shakeStartTime;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    public void Shake()
    {
        _shakeStartTime = Time.time;
        StartCoroutine(StartShake());
    }

    private IEnumerator StartShake()
    {
        while (Time.time - _shakeStartTime < _duration)
        {
            Vector3 position = new Vector3(Random.Range(0, _strength), Random.Range(0, _strength), 0);

            transform.position = _startPosition + position;

            yield return new WaitForSeconds(_timeBetweenShakes);
        }

        transform.position = _startPosition;

        yield return null;
    }
}
