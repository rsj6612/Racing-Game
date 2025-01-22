using UnityEngine;

public class GasItem : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f; // 초기 이동 속도
    public float moveSpeedIncreaseRate = 0.1f; // 속도 증가 비율
    public float maxMoveSpeed = 15f; // 최대 속도

    void Update()
    {
        // 이동 속도 증가 (최대 속도 제한)
        if (moveSpeed < maxMoveSpeed)
        {
            moveSpeed += moveSpeedIncreaseRate * Time.deltaTime;
        }

        // 아래로 이동
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // 화면 밖으로 나가면 제거
        if (transform.position.z < -45f)
        {
            Destroy(gameObject);
        }
    }
}
