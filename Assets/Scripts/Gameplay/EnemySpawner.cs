using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject enemy;
    private float timer;
    protected Timer SpawnerTimer;
    [SerializeField]
    private GameObject player;
    private Player playerScript;


    void Start()
    {
        SpawnerTimer = gameObject.AddComponent<Timer>();
        SpawnerTimer.Initialize(ConfigurationData.EnemySpawnTime, ConfigurationData.IsSpawnerDestroyable);
        playerScript = player.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!playerScript.isDead)
        {
            timer += Time.deltaTime;
            if (!SpawnerTimer.IsCooldown)
            {
                SpawnZombie();
                SpawnerTimer.StartCooldown();
            }
        }
        
    }
    void SpawnZombie()
    {
        DataManager.Instance.GetCameraPositions();
        int randomDirection = Random.Range(0, 2);
        if (randomDirection == 0)
        {
            List<float> myList = new List<float>() { DataManager.Instance.lowerBound.y - ConfigurationData.EnemySpawnerVerticalPadding, DataManager.Instance.upperBound.y + ConfigurationData.EnemySpawnerVerticalPadding };
            int randomPosition = Random.Range(0, myList.Count);
            Instantiate(enemy, new Vector2(Random.Range(DataManager.Instance.lowerBound.x, DataManager.Instance.upperBound.x), myList[randomPosition]), Quaternion.identity);
        }
        else
        {
            List<float> myList = new List<float>() { DataManager.Instance.lowerBound.x - ConfigurationData.EnemySpawnerHorizontalPadding, DataManager.Instance.upperBound.x + ConfigurationData.EnemySpawnerHorizontalPadding };
            int randomPosition = Random.Range(0, myList.Count);
            Instantiate(enemy, new Vector2(myList[randomPosition], Random.Range(DataManager.Instance.lowerBound.y, DataManager.Instance.upperBound.y)), Quaternion.identity);
        }
    }

}
