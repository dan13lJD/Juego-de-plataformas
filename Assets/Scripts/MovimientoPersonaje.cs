using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    //variables para saber la velocidad de caminata, y de brinco
    public float speed = 2.5f;
    public float jumpForce = 2.5f;

    //variables para comprobar si está el personaje parado en el suelo
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    //referencias 
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    //variables de movimiento y salto
    private Vector2 _movement;
    private bool _facingRight = true;
    private bool _isGrounded;


    private void Awake()
    {
        //guardamos el componente de rigid body y el animator en 
        //las variables correspondientes.
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //comenzamos con el movimiento
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _movement = new Vector2(horizontalInput, 0f);
        //volteamos al personaje
        if (horizontalInput < 0f && _facingRight == true)
        {
            Flip();
        }
        else if (horizontalInput > 0f && _facingRight == false)
        {
            Flip();
        }

        //Hay suelo?
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //esta saltando?
        if (Input.GetButtonDown("Jump") && _isGrounded == true)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float horizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
    }

    private void LateUpdate()
    {
        _animator.SetBool("Idle", _movement == Vector2.zero);
        _animator.SetBool("isGrounded", _isGrounded);
    }

    //esta funcion voltea al personaje en su eje x
    private void Flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
