using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float speed;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    float slideForce;

    bool isGround = true;
    public bool CanSlide { get; set; } = true;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        MouseEvent();
    }
    void MouseEvent()
    {
        if (Input.GetMouseButton(0))
        {
            Invoke(GameManager.LeftButton, 0f);
        }
        if (Input.GetMouseButton(1))
        {
            Invoke(GameManager.RightButton, 0f);
        }
        if (!Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            animator.SetFloat(StaticFields.VelocityX, 0f);
        }
    }
    void Left()
    {
        spriteRenderer.flipX = true;
        animator.SetFloat(StaticFields.VelocityX, 1f);
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    void Right()
    {
        spriteRenderer.flipX = false;
        animator.SetFloat(StaticFields.VelocityX, 1f);
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    void Jump()
    {
        if (CheckStatus())
        {
            animator.SetTrigger(StaticFields.Jump);
            isGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void JumpRight()
    {
        if (CheckStatus())
        {
            spriteRenderer.flipX = false;
            animator.SetTrigger(StaticFields.Jump);
            isGround = false;
            rb.AddForce(Vector2.one * jumpForce, ForceMode2D.Impulse);
        }
    }
    void JumpLeft()
    {
        if (CheckStatus())
        {
            spriteRenderer.flipX = true;
            animator.SetTrigger(StaticFields.Jump);
            isGround = false;
            rb.AddForce(new Vector2(-1, 1) * jumpForce, ForceMode2D.Impulse);
        }
    }
    void SlideRight()
    {
        if (CheckStatus())
        {
            CanSlide = false;
            spriteRenderer.flipX = false;
            animator.SetTrigger(StaticFields.Slide);
            rb.AddForce(Vector2.right * slideForce, ForceMode2D.Impulse);
        }
    }
    void SlideLeft()
    {
        if (CheckStatus())
        {
            CanSlide = false;
            spriteRenderer.flipX = true;
            animator.SetTrigger(StaticFields.Slide);
            rb.AddForce(Vector2.left * slideForce, ForceMode2D.Impulse);
        }
    }


    bool CheckStatus()
    {
        if (!CanSlide || !isGround)
        {
            return false;
        }
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Tags.Ground))
            isGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Tags.Ground))
            isGround = false;
    }
}
