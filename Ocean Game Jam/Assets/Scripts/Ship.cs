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


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            HandleCollisionWithRock(collision);
        }
    }


    void HandleCollisionWithRock(Collision2D collision)
    {
        if (isDead) return;

        Debug.Log("Ship collided with rock!");

        Die();

        // Destroy the rock
        Destroy(collision.gameObject);
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("Ship is dead!");
    }


   public void Move(Vector3 movement)
    {
        // Apply movement
        transform.localPosition += movement * 12 * Time.deltaTime;

        // Get the camera's vertical bounds
        Camera mainCamera = Camera.main;
        float screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y; // Top of the screen
        float screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y; // Bottom of the screen

        //padding
        screenTop -= 0.6f;
        screenBottom += 0.8f;


        // Clamp the ship's position within the screen's bounds
        Vector3 clampedPosition = transform.localPosition;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, screenBottom, screenTop);

        // Apply the clamped position
        transform.localPosition = clampedPosition;
    }

    
}
