using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public GameObject fallingBlockPrefab;

    public Vector2 secondsBetweenSpawnsMinMax;
    float nextSpawnTime;
    public Vector2 spawnSizeRange;
    public float spawnAngleMax;

    Vector2 halfScreenWidth;

    void Start()
    {
        halfScreenWidth = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent ());
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float spawnAngle = Random.Range(spawnAngleMax, -spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeRange.x, spawnSizeRange.y);
            Vector2 spawnPosition = new Vector2(Random.Range(-halfScreenWidth.x, halfScreenWidth.x), halfScreenWidth.y + spawnSize);
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));

            newBlock.transform.localScale = Vector3.one * spawnSize;

        }


    }


}
