using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;

    [Header("References")]
    public GameObject gasPrefab; // 생성할 가스 아이템 프리팹

    void OnEnable()
    {
        // 스폰 호출
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }

    void OnDisable()
    {
        CancelInvoke(); // 스폰 중지
    }

    void Spawn()
    {
        // 가스 아이템 생성
        Instantiate(gasPrefab, transform.position, Quaternion.identity);

        // 다음 스폰 예약
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
