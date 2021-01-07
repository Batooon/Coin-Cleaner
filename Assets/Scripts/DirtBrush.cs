using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBrush : MonoBehaviour
{
    [SerializeField] private CustomRenderTexture _dirtHeightmap;
    [SerializeField] private Material _heightMapUpdate;

    private readonly int DrawPosition = Shader.PropertyToID("_DrawPosition");

    private Camera _camera;

    private void Start()
    {
        _dirtHeightmap.Initialize();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Paint(hit.textureCoord);
            }
        }
    }

    private void Paint(Vector2 texturePos)
    {
        Vector2 hitTextureCoord = texturePos;

        _heightMapUpdate.SetVector(DrawPosition, hitTextureCoord);
    }
}
