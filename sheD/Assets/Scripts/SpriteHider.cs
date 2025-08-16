using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHider : MonoBehaviour
{
    private SpriteRenderer _sprite;
    
    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        _sprite.enabled = false;
    }


}
