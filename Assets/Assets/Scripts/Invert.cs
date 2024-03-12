using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.XR;

public class Invert : MonoBehaviour
{
    public PlayerMovement pm;
    private Vector3 movement;

    private void FixedUpdate()
    {
        if (pm.verticalInput < 0 && !pm.right) { Flip(); }
        if (pm.verticalInput > 0 && pm.right) { Flip(); }
    }

    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        pm.right = !pm.right;
    }
}
