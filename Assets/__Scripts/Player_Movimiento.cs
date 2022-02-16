using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Para El Movimiento del player necesitamos estos 3
[RequireComponent(typeof(Animator))] 
[RequireComponent(typeof(Rigidbody2D))] // Quitarle la rotacion y la gravedad
[RequireComponent(typeof(BoxCollider2D))]

public class Player_Movimiento : MonoBehaviour
{
    [SerializeField] private float velocidad;
    public bool EnMovimiento => _direccionMovimiento.magnitude > 0f;
    
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direccionMovimiento;
    public Vector2 DireccionMovimiento => _direccionMovimiento; // Variable para enviar a otros scripts en este caso lo mandamos a player_animaciones
    private Vector2 _input;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // X
        if(_input.x > 0.1f)
        {
            _direccionMovimiento.x = 1f;
        }
        else if(_input.x < 0f)
        {
            _direccionMovimiento.x = -1f;
        }
        else
        {
            _direccionMovimiento.x = 0f;
        }

        // Y

         if(_input.y > 0.1f)
        {
            _direccionMovimiento.y = 1f;
        }
        else if(_input.y < 0f)
        {
            _direccionMovimiento.y = -1f;
        }
        else
        {
            _direccionMovimiento.y = 0f;
        }
    }

    private void FixedUpdate() 
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direccionMovimiento * velocidad * Time.fixedDeltaTime);
    }
}
