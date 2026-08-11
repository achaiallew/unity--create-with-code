using UnityEngine;

public class DestroyOOB : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -30)
        {
            Destroy(gameObject);
        }
    }
}
