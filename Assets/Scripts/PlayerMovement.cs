using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _runningSpeed = 4f;
    [SerializeField] private float _jumpForce = 5f;

    //private Rigidbody2D rb;
    private Animator animator;
    private Vector3 moveDirection;

    private bool isFaceRight = true;


    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0);

        if (Input.GetKey(KeyCode.LeftShift))
            transform.position += _runningSpeed * Time.deltaTime * moveDirection;
        else
            transform.position += _moveSpeed * Time.deltaTime * moveDirection;
        // Либо поменять на rb.velocity

        ChangeAnimationState();
    }

    private void ChangeAnimationState()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);

            FlipPlayerSprite();
        }
        else if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isWalking", false);

            FlipPlayerSprite();
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }   
    }

    private void FlipPlayerSprite()
    {
        if ((moveDirection.x > 0 && isFaceRight == false) || (moveDirection.x < 0 && isFaceRight == true))
        {
            transform.localScale *= new Vector2(-1, 1);
            isFaceRight = !isFaceRight;
        }
    }

    //private void Jump()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
    //    }
    //}
}
