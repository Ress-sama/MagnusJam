using UnityEngine;

public class CameraManager : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    Vector3 offset;

    [SerializeField]
    float maxX;
    [SerializeField]
    float maxY;
    [SerializeField]
    float minX;
    [SerializeField]
    float minY;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
    }
    private void Update()
    {
        transform.position = new Vector3(
        Mathf.Clamp(player.transform.position.x, minX, maxX),
        Mathf.Clamp(player.transform.position.y, minX, maxY),
        transform.position.z);
    }
}
