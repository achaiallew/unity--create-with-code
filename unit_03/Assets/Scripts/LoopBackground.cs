using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float width;
     void Start()
    {
        startPos = transform.position;
        width = GetComponent<BoxCollider>().size.x/2;
    }

     void Update()
    {
        if (transform.position.x < (startPos.x - width))
        {
            transform.position = startPos;
        }
    }
}
