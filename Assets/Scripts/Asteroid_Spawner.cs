using UnityEngine;
using System.Collections;
public class Asteroid_Spawner : MonoBehaviour
{
    private GameObject asteroidPrefab;
    public GameObject asteroidPrefab1;
    public GameObject asteroidPrefab2;
    public GameObject asteroidPrefab3;
    public float spawnInterval = 4.0f;
    private float timer;
    public Vector2 spawnAreaMin = new Vector2(-19, 11);
    public Vector2 spawnAreaMax = new Vector2(19, 15);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IEnumerator method = SpawnAsteroid();
        Debug.Log("Asteroid Spawner started");
        StartCoroutine(method);
    }

    // Update is called once per frame
    IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );
            asteroidPrefab = Random.Range(0, 3) switch
            {
                0 => asteroidPrefab1,
                1 => asteroidPrefab2,
                2 => asteroidPrefab3,
                _ => asteroidPrefab1
            };
            GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
}
