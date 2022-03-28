using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomentumLawHandler : PhysicsLawHandler
{
    public override Law MyLaw => Law.ConservationOfMomentum;

    bool mode;
    new Rigidbody2D rigidbody2D;
    Vector2 oldVelocity = Vector2.zero;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    new void Start()
    {
        base.Start();
    }

    protected override void EnableLaw()
    {
        mode = false;
    }
    protected override void DisableLaw()
    {
        mode = true;
    }
    private void FixedUpdate()
    {
        if (mode)
        {
            if ((oldVelocity - rigidbody2D.velocity).magnitude < 0.1f)
            {
                rigidbody2D.velocity *= 0.9f;
                rigidbody2D.angularVelocity *= 0.9f;
            }
        }
        oldVelocity = rigidbody2D.velocity;
    }
}
