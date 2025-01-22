using UnityEngine;

public class RoadScroller : MonoBehaviour
{
    [Header("Scroll Settings")]
    public float scrollSpeed = 0.5f; // 스크롤 속도

    [Header("References")]
    public MeshRenderer meshRenderer; // Plane의 MeshRenderer 참조

    void Start()
    {
        if (meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
    }

    void Update()
    {
        // 텍스처 오프셋 계산
        Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset.y -= scrollSpeed * Time.deltaTime; // Y축 기준으로 스크롤
        meshRenderer.material.mainTextureOffset = offset;
    }
}
