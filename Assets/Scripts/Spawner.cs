using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObj
        {
            public GameObject prefab;
            public float spawnChance; 
        }
    public SpawnableObj[] obstacles;
    public SpawnableObj[] items;
    private float obstacleTimer;
    private float itemTimer;

    private void Update()
    {
        obstacleTimer -= Time.deltaTime;
        itemTimer -= Time.deltaTime;

        if (obstacleTimer <= 0)
        {
            SpawnObject(obstacles);
            obstacleTimer = Random.Range(1.5f, 2.5f);
        }

        if (itemTimer <= 0)
        {
            SpawnObject(items);
            itemTimer = Random.Range(2.0f, 7.0f);
        }
    }

    private void SpawnObject(SpawnableObj[] objects)
    {
        float chance = Random.Range(0f, 1f);
        foreach (var obj in objects)
        {
            if (chance < obj.spawnChance)
            {
                GameObject spawning = Instantiate(obj.prefab);
                // ... (your spawning logic)
                break;
            }
            chance -= obj.spawnChance;
        }
    }
    // private void Spawn()
    // {
    //     float chance = Random.Range(0f,1f); //Set spawn chance tu 0 den 1
    //     foreach (var obj in obstacles)
    //     {   
    //         if (chance<obj.spawnChance)
    //         {
    //             GameObject Spawning = Instantiate(obj.prefab);
    //             //Spawning.transform.position = Spawning.transform.position + transform.position;
    //             break;
    //         }
    //         chance -= obj.spawnChance;
    //     }
    //     chance = Random.Range(0f,1f);
    //     foreach (var item in items)
    //     {
    //         if (chance<item.spawnChance)
    //         {
    //             GameObject Spawning = Instantiate(item.prefab);
    //             break;
    //         }
    //         chance -= item.spawnChance;
    //     }
    //     Invoke("Spawn", Random.Range(1.4f,2f));
    // }
    // private void OnEnable()
    // {
    //     Invoke("Spawn", Random.Range(1.4f,2f));
    // }
    // private void OnDisable()
    // {
    //     CancelInvoke(nameof(Spawn));
    // }
}
