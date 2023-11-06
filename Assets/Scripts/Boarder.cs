using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boarder : MonoBehaviour
{    
    [SerializeField] float flipSpeed = 220f;
    Rigidbody2D rb2d;

    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float baseSpeed = 80f;
    [SerializeField] float brakeSpeed = 30f;
    [SerializeField] float boostSpeed = 120f;

    public bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove) {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls() {
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            surfaceEffector2D.speedVariation = boostSpeed;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            surfaceEffector2D.speedVariation = brakeSpeed;
        } else {
            surfaceEffector2D.speedVariation = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            rb2d.AddTorque(flipSpeed);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            rb2d.AddTorque(-flipSpeed);
        }
    }

}
