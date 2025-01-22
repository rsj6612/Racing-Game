using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Car Settings")]
    public float moveSpeed = 10f; // 자동차 속도

    [Header("References")]
    public GameManager gameManager; // 게임 상태를 관리하는 GameManager

    private void Update()
    {
        HandleCarMovement();
    }

    void HandleCarMovement()
    {
        // 왼쪽/오른쪽 화살표 입력 처리
        float horizontalInput = Input.GetAxis("Horizontal"); // -1 (왼쪽), 1 (오른쪽)
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            gameManager.RechargeGas(gameManager.gasRechargeAmount); // 가스 충전
            Destroy(other.gameObject); // 충돌한 가스 아이템 제거
        }
    }
}
