using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour
{
    [SerializeField]
    private TagBehaviour _tagBehaviour;
    [SerializeField]
    private Text _text;
    private string _startText;

    private void Start()
    {
        _startText = _text.text;    
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _startText + " " + _tagBehaviour.Score;
    }
}
