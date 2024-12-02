using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rock : MonoBehaviour
{
    Rigidbody2D rb; 
    [SerializeField] float speed = 5f; // Rock speed    

    public Stopwatch stopwatch;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        rb.velocity = new Vector2(-speed, 0f); // Rock moves leftwards
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }
    }

}
