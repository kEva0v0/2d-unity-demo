using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlueController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;

    private float moveHorizontal;
    private float moveVertical;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
<<<<<<< HEAD

        moveSpeed = 1f;
        isJumping = false;
        jumpForce = 60f;
=======
>>>>>>> 68e09dbd0365cf59b586813d294386edb5687f06
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (moveHorizontal < -0.1f || moveHorizontal > 0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }
    }
}
