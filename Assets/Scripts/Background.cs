using UnityEngine;

public class Background : MonoBehaviour
{
    private Renderer _renderer;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        _renderer.material.mainTextureOffset = new Vector2(0, Time.time * 0.25f);
    }
}
