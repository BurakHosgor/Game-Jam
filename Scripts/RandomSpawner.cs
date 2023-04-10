using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
   
    public GameObject elmalar_1;
    
    public float spawnTime=5;
    
    public EdgeCollider2D spawnArea;

    private void Start()
    {
        InvokeRepeating("SpawnApple", 5f, spawnTime);

    }

    void SpawnApple()
    {
        Vector2 spawnPosition = RandomPointInBounds(spawnArea.bounds);
        GameObject apple = Instantiate(elmalar_1, spawnPosition, Quaternion.identity);
        Destroy(apple, 4f);
    }

    Vector2 RandomPointInBounds(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );

    }
}