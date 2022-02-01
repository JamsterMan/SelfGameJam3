using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Vector3 walkingDirection;
    
    public float moveSpeed = 5f;

    public Transform movePos;

    public LayerMask stopMovement;

    // Start is called before the first frame update
    void Start()
    {
        movePos.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePos.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePos.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(movePos.position + walkingDirection, .2f, stopMovement))
            {
                movePos.position += walkingDirection;
            }
            else
            {
                TurnAI();
            }
        }
    }

    private void TurnAI()
    {
        if(walkingDirection.x == 1)
        {
            walkingDirection = new Vector3(0, 1, 0);
        }
        else if (walkingDirection.y == 1)
        {
            walkingDirection = new Vector3(-1, 0, 0);
        }
        else if (walkingDirection.x == -1)
        {
            walkingDirection = new Vector3(0, -1, 0);
        }
        else if (walkingDirection.y == -1)
        {
            walkingDirection = new Vector3(1, 0, 0);
        }
    }
}
