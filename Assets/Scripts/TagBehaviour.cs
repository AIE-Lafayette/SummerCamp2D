using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPoint;
    [SerializeField]
    private bool _isTagger;
    [SerializeField]
    private GameObject _tagMarker;
    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private float _spawnDelay = 3;
    [SerializeField]
    private ScreenShakeBehaviour _shakeBehaviour;
    public int Score;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isTagger = !_isTagger;

            if (_isTagger)
            {
                Instantiate(_explosion, transform.position, transform.rotation);
                _shakeBehaviour.Shake();
                Invoke("Respawn", _spawnDelay);
                gameObject.SetActive(false);
            }
        }
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
        transform.position = _spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        _tagMarker.SetActive(_isTagger);

        if (!_isTagger)
            Score++;
    }
}
