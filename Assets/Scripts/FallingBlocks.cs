using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocks : MonoBehaviour
{
    public Vector2 speedMinMax;

    float visibleHeightThreshold;
    float speed;

    void Start()
    {
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
        speed = Mathf.Lerp (speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent ());
    }

    void Update()
    {
        


        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D (Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
