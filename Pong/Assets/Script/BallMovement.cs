using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    private int velocity = 10;
    private Rigidbody2D rigidBody;
    private AudioSource audio;
    [SerializeField]
    private AudioClip hitSound;
    private Text info;

    void Start()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;

        audio = GetComponent<AudioSource>();
        info = GameObject.Find("InfoText").GetComponent<Text>();
        rigidBody = GetComponent<Rigidbody2D>();

        StartCoroutine(ThrowRandom());
    }

    void Update()
    {
        
    }

    IEnumerator ThrowRandom()
    {
        info.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);

        int xDirection = 10 * (-1 + 2 * Random.Range(0, 1));
        int yDirection = Random.Range(-5, 5);
        var direction = new Vector2(xDirection, yDirection).normalized;
        rigidBody.AddForce(direction * velocity);
        
        info.gameObject.SetActive(false);
    }

    public void Stop()
    {
        transform.position = new Vector2(0.0f, 0.0f);
        rigidBody.velocity = new Vector2(0.0f, 0.0f);
    }

    public void Reset()
    {
        Stop();
        StartCoroutine(ThrowRandom());
    }

    void OnCollisionEnter2D(Collision2D collideWith) {
        if (!collideWith.gameObject.name.StartsWith("Target"))
        {
            audio.PlayOneShot(hitSound);
        }
        
        if (collideWith.gameObject.name.StartsWith("Paddle"))
        {
            float angle = (transform.position.y - collideWith.transform.position.y) * 5f;
            Vector2 direction = new Vector2(rigidBody.velocity.x, angle).normalized;
            rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(direction * velocity * 2);
        }
    }
}
