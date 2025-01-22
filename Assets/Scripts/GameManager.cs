using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public float gas = 100f; // 초기 가스량
    public float gasConsumptionRate = 2f; // 초기 가스 소모량
    public float gasConsumptionRateIncrease = 0.1f; // 가스 소모량 증가 비율
    public float maxGasConsumptionRate = 6f; // 최대 가스 소모량
    public float gasRechargeAmount = 30f;


    [Header("UI References")]
    public TMP_Text gasText; // 가스량 표시
    public GameObject gameOverPanel; 


    void Start()
    {
        Time.timeScale = 1; // 게임을 다시 시작할 때 시간 흐름 복원
    }
    void Update()
    {
        HandleGasConsumption();
        CheckGameOver();
        UpdateGasUI();
    }

    void HandleGasConsumption()
    {
        // 가스 소모량 증가 (최대 소모량 제한)
        if (gasConsumptionRate < maxGasConsumptionRate)
        {
            gasConsumptionRate += gasConsumptionRateIncrease * Time.deltaTime;
        }

        // 1초당 가스 소모
        gas -= gasConsumptionRate * Time.deltaTime;

        // 가스가 음수로 내려가지 않도록 고정
        if (gas < 0)
        {
            gas = 0;
        }
    }

    void UpdateGasUI()
    {
        // 가스량을 UI에 업데이트
        if (gasText != null)
        {
            gasText.text = "Gas: " + Mathf.RoundToInt(gas).ToString();
        }
    }

    void CheckGameOver()
    {
        if (gas <= 0f) // 게임 오버
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0; // 게임 멈춤
        }
    }

    public void RechargeGas(float amount)
    {
        gas += gasRechargeAmount;
        if (gas > 100f) gas = 100f; // 최대 가스량 100으로 제한
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬을 다시 로드
    }
}
