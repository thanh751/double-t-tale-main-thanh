using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObj
        {
            public GameObject prefab;
            public float spawnChance; //Spawn chance tu 0-1
        }
    public SpawnableObj[] objects;
    private void Spawn()
        {
            float chance = Random.Range(0f,1f);
            foreach (var obj in objects)
                {   
                    if (chance<obj.spawnChance)
                        {
                            GameObject Spawning = Instantiate(obj.prefab);
                            //Spawning.transform.position = Spawning.transform.position + transform.position;
                            break;
                        }
                    chance -= obj.spawnChance;
                }
            Invoke("Spawn", Random.Range(1.4f,2f));
        }
    private void OnEnable()
        {
            Invoke("Spawn", Random.Range(1.4f,2f));
        }
    private void OnDisable()
        {
            CancelInvoke();
        }
}
