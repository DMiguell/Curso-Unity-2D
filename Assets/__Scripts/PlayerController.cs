using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    public float speed;
    private Vector2 input;

    private Animator _animator;

    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            // input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); Esto es lo mismo que lo de abajo
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // Con esto evitamos el movimiento en diagonal
            if(input.x !=0)
            {
                input.y = 0;
            }

            if (input != Vector2.zero)
            {

                _animator.SetFloat("Move X", input.x);
                _animator.SetFloat("Move Y", input.y);

                var targetPosition = transform.position;
                targetPosition.x += input.x;
                targetPosition.y += input.y;

                StartCoroutine(MoveTowards(targetPosition));
            }
        }
    }

    private void LateUpdate()
    {
        _animator.SetBool("is Moving", isMoving);
    }

    IEnumerator MoveTowards(Vector3 destination)
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, destination) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        transform.position = destination;
        isMoving = false;
    }
}
