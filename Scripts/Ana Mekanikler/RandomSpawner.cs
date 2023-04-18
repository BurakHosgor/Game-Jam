using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] foods;
    public float spawnTime = 5f;
    public int maxApples = 5;
    public EdgeCollider2D spawnArea;

    private void Start()
    {
        InvokeRepeating("SpawnApples", 5f, spawnTime);
    }

    void SpawnApples()
    {
        for (int i = 0; i < maxApples; i++)
        {
            Vector2 spawnPosition = RandomPointInBounds(spawnArea.bounds);
            int randomIndex = Random.Range(0, foods.Length);
            GameObject apple = Instantiate(foods[randomIndex], spawnPosition, Quaternion.identity);
            Destroy(apple, 4f);
        }
    }

    Vector2 RandomPointInBounds(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }
}
