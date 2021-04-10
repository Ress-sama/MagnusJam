using UnityEngine;
public class Push : MonoBehaviour
{
    [SerializeField]
    float force;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Tags.Player))
        {
            collision.collider.gameObject.GetComponent<Rigidbody2D>()
                .AddForce(transform.up * force, ForceMode2D.Impulse);
        }
    }
}
