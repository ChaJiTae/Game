using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] float Speed = 4.0f; // 걷기 속도
    [SerializeField] float jumpForce = 7.5f; // 점프 힘
    //[SerializeField] float rollForce = 6.0f; // 롤링 힘 (사용되지 않음)

    private bool isGrounded; // 땅에 있는지 확인
    private Rigidbody2D rb; // Rigidbody2D 컴포넌트
    private Animator animator; // Animator 컴포넌트

    // Ground 체크를 위한 변수들
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask whatIsGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
        animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기
    }
bool Rightmove = false;
bool Leftmove = false;
bool JumpAndFall = false;
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            Rightmove = true;
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("PlayerMove", true);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Leftmove = true;
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("PlayerMove", true);
        }
        if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("PlayerMove", false);
            Rightmove = false; Leftmove = false;
        }
        // Ground 체크
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        // 점프 입력 처리
        if (Input.GetKeyDown(KeyCode.Space) && !JumpAndFall)
        {
            JumpAndFall = true;
        }
        if(rb.velocity.y > 0)
        {
            animator.SetBool("Jump", true);
        }
        if(rb.velocity.y < 0)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", true);
        }
        if(rb.velocity.y == 0 && animator.GetBool("Fall"))
        {
            animator.SetBool("Fall", false);
            JumpAndFall = false;
        }
    }
    void FixedUpdate()
    {
        if(Rightmove)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            Rightmove = false;
        }
        if(Leftmove)
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            Leftmove = false;
        }
        if(JumpAndFall)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            JumpAndFall = false;
        }
    }
}
