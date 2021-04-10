using UnityEngine;
public class PortalEnterance : MonoBehaviour
{
    [SerializeField]
    GameObject exit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Tags.Player))
        {
            collision.collider.transform.position = exit.transform.position;
        }
    }
}
