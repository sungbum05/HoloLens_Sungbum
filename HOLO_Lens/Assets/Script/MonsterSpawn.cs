using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public static List<GameObject> SpawnList = new List<GameObject>();

    private const int MaxSpawnCnt = 10;

    private const float MaxSpawnTime = 1.5f;
    private const float MinSpawnTime = 0.5f;

    private const float MaxSpawnDistance = 10.0f;

    private Queue<GameObject> MonsterList = new Queue<GameObject>();

    [SerializeField] List<GameObject> MonsterPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        BasicEnemySetting();

        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BasicEnemySetting()
    {
        if (MonsterList != null)
            MonsterList.Clear();

        for (int i = 0; i < 30; i++)
        {
            MonsterList.Enqueue(MonsterPrefabs[Random.Range(0, MonsterPrefabs.Count)]);
        }
    }

    IEnumerator EnemySpawn()
    {
        GameObject Monster = null;

        yield return null;

        while (true)
        {
            yield return null;

            if (SpawnList.Count >= MaxSpawnCnt) // 스폰 제한
                continue;

            if (MonsterList.Count <= 0) // 몬스터가 리스트에서 없어졌을 때 다시 추가
                BasicEnemySetting();

            float PosX = Random.Range(-MaxSpawnDistance, MaxSpawnDistance);
            float PosY = this.gameObject.transform.position.y;
            float PosZ = Random.Range(-MaxSpawnDistance, MaxSpawnDistance);

            PosX += PosX > 0 ? 15.0f : -15.0f;
            PosZ += PosZ > 0 ? 15.0f : -15.0f;

            Vector3 SpawnPos = new Vector3(PosX, PosY, PosZ);

            Monster = Instantiate(MonsterList.Dequeue(), SpawnPos, Quaternion.identity);
            SpawnList.Add(Monster);

            Debug.Log(MonsterList.Count);

            yield return new WaitForSeconds(Random.Range(MinSpawnTime, MaxSpawnTime));
        }
    }
}
