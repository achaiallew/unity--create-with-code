using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Declare Variables
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -8);
    
    private void LateUpdate() {
        transform.position = player.transform.position + offset;
    }
}
