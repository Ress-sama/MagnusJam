using UnityEngine;
public class Push : MonoBehaviour
{
    [SerializeField]
    float force;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(Tags.Player))
        {
            collider.gameObject.GetComponent<Rigidbody2D>()
                .AddForce(transform.up * force, ForceMode2D.Impulse);
            animator.SetBool(Tags.Push, true);
        }
    }
}
