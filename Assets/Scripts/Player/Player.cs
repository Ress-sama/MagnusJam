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
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        else if (Input.GetMouseButton(1))
        {
            Invoke(GameManager.RightButton, 0f);
        }
    }
    void Left()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    void Right()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    void Jump()
    {
        if (!isGround)
        {
            return;
        }
        isGround = false;
        rb.AddForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
    }
    void RightSlide()
    {
        Debug.Log("RightSlide");
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
