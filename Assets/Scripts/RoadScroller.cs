using UnityEngine;

public class RoadScroller : MonoBehaviour
{
    [Header("Scroll Settings")]
    public float scrollSpeed = 0.08f; // 초기 스크롤 속도
    public float scrollSpeedIncreaseRate = 0.03f; // 스크롤 속도 증가 비율
    public float maxScrollSpeed = 1f; // 최대 스크롤 속도

    [Header("References")]
    public MeshRenderer meshRenderer; 

    void Start()
    {
        if (meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
    }

    void Update()
    {
        // 스크롤 속도 증가 (최대 속도 제한)
        if (scrollSpeed < maxScrollSpeed)
        {
            scrollSpeed += scrollSpeedIncreaseRate * Time.deltaTime;
        }

        // 텍스처 오프셋 계산
        Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset.y -= scrollSpeed * Time.deltaTime; // Y축 기준으로 스크롤
        meshRenderer.material.mainTextureOffset = offset;
    }
}
