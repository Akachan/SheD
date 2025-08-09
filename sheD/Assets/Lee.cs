using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Lee : MonoBehaviour
{
    [SerializeField] private GameObject lee;

    [SerializeField] private float timeToSpawn = 5f;
    
    private float _currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        lee.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= timeToSpawn)
        {
            lee.SetActive(true);
        }
    }
}
