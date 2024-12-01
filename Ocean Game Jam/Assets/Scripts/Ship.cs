using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    [Header("Ship Settings")]
    [SerializeField] bool isDead = false;

    SpriteRenderer sr;
    Rigidbody2D rb;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Move(Vector3 movement)
    {
        transform.localPosition += movement * 12 * Time.deltaTime;
    }

    
}
