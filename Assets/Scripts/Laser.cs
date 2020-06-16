using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    void Start()
    {
        
    }

    
    void Update()
    {
        LaseMovement();
    }

    void LaseMovement()
    {
        transform.Translate(Vector3.up * (_speed * Time.deltaTime));

        if (transform.position.y >= 8f)
        {
            Destroy(this.gameObject);
        }
    }
}
