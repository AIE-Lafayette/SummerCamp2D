using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagBehaviour : MonoBehaviour
{
    public Transform SpawnPoint;
    public bool IsTagger;
    public float SpawnDelay = 3;
    public float ScoreMultiplier = 3;
    public float Score;
    public GameObject TagMarker;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") == false)
            return;

        if (IsTagger == true)
        {
            IsTagger = false;
            TagMarker.SetActive(false);
        }
        else
        {
            IsTagger = true;
            TagMarker.SetActive(true);
        }

        if (IsTagger == true)
        {
            Invoke("Respawn", SpawnDelay);
            gameObject.SetActive(false);
        }
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
        transform.position = SpawnPoint.position;
    }

    private void Update()
    {
        if (!IsTagger)
            Score += ScoreMultiplier * Time.deltaTime;
    }
}
