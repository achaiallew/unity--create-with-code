using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    public Vector3 position;
    public float scale;
    public float speed;
    
    void Start()
    {
        transform.position = position;
        transform.localScale = Vector3.one * scale;
    
    }
    
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime, 0.0f, 0.0f);
 

        Material material = Renderer.material;
        float hue = Mathf.Repeat(Time.time * 0.1f, 1f); // cycles 0-1 over time
        material.color = Color.HSVToRGB(hue, 1f, 1f);
    }
}
