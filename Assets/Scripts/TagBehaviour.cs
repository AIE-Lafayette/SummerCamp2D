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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isTagger = !_isTagger;

            if (_isTagger)
                transform.position = _spawnPoint.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _tagMarker.SetActive(_isTagger);
    }
}
