using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloudysad : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Weirdwall z = other.collider.GetComponent<Weirdwall>();

        if (z != null)
        {
            Destroy(gameObject);
        }
        
    }

}