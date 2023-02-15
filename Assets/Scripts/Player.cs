using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager GameManager;
    private const float Speed = 10f;

    private Rigidbody2D _rigidbody2D;

    private Vector2 _offset;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _offset = Vector2.zero;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _offset = Time.deltaTime * Speed * Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _offset = Time.deltaTime * -Speed * Vector2.left;
        }
    }

    private void LateUpdate()
    {
        if ((_rigidbody2D.position + _offset).x > -9f && (_rigidbody2D.position + _offset).x < 9f)
            _rigidbody2D.position += _offset;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.Hit();
    }
}
