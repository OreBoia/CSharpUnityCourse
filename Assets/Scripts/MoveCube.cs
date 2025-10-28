using UnityEngine;

public class MoveCube: MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private Vector3 _dir;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotateSpeed;

    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _color;
    [SerializeField] private Color _oldColor;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();

        _oldColor = _renderer.material.color;
    }

    void Update()
    {
        HandleInputMovement();
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_renderer.material.color == _oldColor)
                _renderer.material.color = _color;
            else
                _renderer.material.color = _oldColor;
        }
    }


    private void HandleInputMovement()
    {
        _dir = Vector3.zero;

        Debug.Log($"Transform Forward: {transform.forward}");
        if (Input.GetKey(KeyCode.W))
            _dir += transform.forward; // Vector3.forward (x= 0,y= 0,z= 1)
        else if (Input.GetKey(KeyCode.S))
            _dir += -transform.forward;

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(new Vector3(0f, -_rotateSpeed, 0f));
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0f, _rotateSpeed, 0f));
    }


    void FixedUpdate()
    {
        if(_dir != Vector3.zero) _rb.MovePosition(_rb.position + _dir * _speed * Time.deltaTime);
    }
}