using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Declare Variables
    public GameObject player;
    [SerializeField]private Vector3 offset = new Vector3(0, 5, -8);
    
    void LateUpdate() {
        transform.position = player.transform.position + offset;
    }
}
