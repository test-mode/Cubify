using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float halfScreenWidth;
    float halfPlayerWidth;
    public int playerHealth;

    public event System.Action OnPlayerDeath;
    public GameObject player;

    void Start()
    {

        halfPlayerWidth = transform.localScale.x / 2f;

        halfScreenWidth = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;


    }


    void Update()
    {


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(touchDeltaPosition.x * .005f, 0, 0);
        }



        if (transform.position.x < -halfScreenWidth)
        {
            transform.position = new Vector2(-halfScreenWidth, transform.position.y);
        }

        if (transform.position.x > halfScreenWidth)
        {
            transform.position = new Vector2(halfScreenWidth, transform.position.y);
        }



        if (playerHealth == 0)
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }


    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Enemy")
        {
            playerHealth --;
        }

        if (triggerCollider.tag == "Friend")
        {
            playerHealth ++;
        }

    }

}