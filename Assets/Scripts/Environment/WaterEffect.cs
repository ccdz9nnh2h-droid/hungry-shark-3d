using UnityEngine;

public class WaterEffect : MonoBehaviour
{
    [SerializeField] private float waveSpeed = 1f;
    [SerializeField] private float waveAmplitude = 0.5f;
    
    private Material waterMaterial;
    private Vector2 offset = Vector2.zero;

    private void Start()
    {
        waterMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        offset += Vector2.right * waveSpeed * Time.deltaTime;
        waterMaterial.SetTextureOffset("_MainTex", offset);
    }
}
