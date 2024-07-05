using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float kSpeed = 0.05f;
    private const float kRotationSpeed = 1.0f;
    private Animator catAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        catAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x_direction = Input.GetAxis("Horizontal");
        float z_direction = Input.GetAxis("Vertical");

        Vector3 move_direction = new Vector3(x_direction, 0.0f, z_direction) * kSpeed;

        transform.Translate(move_direction);

        if (z_direction != 0.0f)
        {
            catAnimator.Play("A_trot");
        } else if (x_direction != 0.0f)
        {
            catAnimator.Play("A_Play");
        }
        else
        {
            catAnimator.Play("A_idle");
        }
        
        float h = kRotationSpeed * Input.GetAxis("Mouse X");
        float v = kRotationSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(0, h, 0);
    }
}
