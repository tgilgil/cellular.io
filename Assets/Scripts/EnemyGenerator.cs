using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public GameObject EnemyPrefab;

    public float SpawnIntervalInSecs = 1.0f;
    private float WaitTimeUntilSpawn;

    void Start()
    {
        WaitTimeUntilSpawn = SpawnIntervalInSecs;
    }
    
	void Update () {
        if (Time.timeSinceLevelLoad >= WaitTimeUntilSpawn)
        {
            Instantiate(EnemyPrefab);
            WaitTimeUntilSpawn = Time.timeSinceLevelLoad + SpawnIntervalInSecs;
        }
	}
}
