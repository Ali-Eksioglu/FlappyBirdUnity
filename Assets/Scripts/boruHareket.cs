using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boruHareket : MonoBehaviour
{

    public float speed;

    private void Start() {
        Destroy(gameObject,6);
    }

    private void FixedUpdate() {
        
        transform.position += Vector3.left * speed * Time.deltaTime ;
        
    }
}
