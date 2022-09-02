using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    private const int MaxSpawnCnt = 10;

    private const float MaxSpawnTime = 4.5f;
    private const float MinSpawnTime = 3.5f;

    private const float MaxSpawnDistance = 20.0f;
    private const float MinSpawnDistance = 10.0f;

    [SerializeField] Queue<GameObject> MonsterList = new Queue<GameObject>();
    [SerializeField] List<GameObject> SpawnList = new List<GameObject>();

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

            float PosX = Random.Range(MinSpawnDistance, MaxSpawnDistance);
            float PosY = this.gameObject.transform.position.y;
            float PosZ = Random.Range(MinSpawnDistance, MaxSpawnDistance);

            Vector3 SpawnPos = new Vector3(PosX, PosY, PosZ);

            Monster = Instantiate(MonsterList.Dequeue(), SpawnPos, Quaternion.identity);
            SpawnList.Add(Monster);

            Debug.Log(MonsterList.Count);

            yield return new WaitForSeconds(Random.Range(MinSpawnTime, MaxSpawnTime));
        }
    }
}
