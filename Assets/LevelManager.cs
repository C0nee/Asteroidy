using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private float maxHorizontal , maxVertical;
    Wyjazd cs;
    public GameObject AsteroidPrefab;
    private float spawnInterval, spawnTimer;
   
    
    // Start is called before the first frame update
    void Start()
    {
        cs = Camera.main.GetComponent<Wyjazd>();

        spawnInterval = 3;
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        maxHorizontal = cs.worldWidth / 2 * 1.2f;
        maxVertical= cs.worldHeight / 2 * 1.2f;
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            Spawn();
            spawnTimer = spawnInterval;
        }
    }
    void Spawn()
    {
        float randomX, randomZ;
        if(Mathf.Round(Random.Range(0,1))== 0 )
        {
            //generujemy na liniach poziomych
            randomZ = randomSign() * maxVertical; //to do poprawki powinno byc -1* albo 1*
            randomX = Random.Range(0, maxHorizontal);
        }
        else
        {
            //generujemy na liniach pionowych
            randomX = randomSign() * maxHorizontal;
            randomZ = Random.Range(0, maxVertical);
        }
        Vector3 spawnpoint = new Vector3 (randomX,0, randomZ);
        Instantiate(AsteroidPrefab,spawnpoint,Quaternion.identity);
    }
    int randomSign()
    {
        int[] numbers = { -1, 1 };
        int randomIndex = Random.Range(0, numbers.Length);
        return numbers[randomIndex];
    }
}
