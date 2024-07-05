using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float kSpeed = 0.05f;
    private const float kRotationSpeed = 1.0f;
    private Animator catAnimator;
    private float timeSinceStateTransition = 0.0f;
    
    enum CatState
    {
        MOVING,
        GROOMING
    };

    private CatState state = CatState.MOVING;
    
    // Start is called before the first frame update
    void Start()
    {
        catAnimator = GetComponent<Animator>();
    }

    void HandleMoving()
    {
        float x_direction = Input.GetAxis("Horizontal");
        float z_direction = Input.GetAxis("Vertical");

        Vector3 move_direction = new Vector3(x_direction, 0.0f, z_direction) * kSpeed;

        transform.Translate(move_direction);

        if (z_direction != 0.0f)
        {
            catAnimator.Play("A_trot");
        }
        else if (x_direction != 0.0f)
        {
            Debug.Log("Playing wriggle");
            catAnimator.Play("C_wriggling");
        }
        else
        {
            catAnimator.Play("A_idle");
        }

        float h = kRotationSpeed * Input.GetAxis("Mouse X");
        float v = kRotationSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(0, h, 0);

        if (Input.GetKey(KeyCode.G))
        {
            timeSinceStateTransition = 0.0f;
            state = CatState.GROOMING;
        }
    }

    void HandleGrooming()
    {
        catAnimator.Play("B_wash");
        timeSinceStateTransition += Time.deltaTime;
        if (timeSinceStateTransition > 2.0f)
        {
            state = CatState.MOVING;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case CatState.MOVING:
                HandleMoving();
                return;
            case CatState.GROOMING:
                HandleGrooming();
                return;
        }
    }
}
