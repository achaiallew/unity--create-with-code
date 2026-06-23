using UnityEngine;

public class DestroyOnExit : MonoBehaviour
{

    public float topBounds;
    public float lowerBounds;
 
     void Update()
    {
        if (transform.position.z >= topBounds)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z <= lowerBounds)
        {
            Debug.Log("GameOver");
            Destroy(gameObject);
        }
    }
}
