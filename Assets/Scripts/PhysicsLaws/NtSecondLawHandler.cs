using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NtSecondLawHandler : PhysicsLawHandler
{
    public override Law MyLaw => Law.NewtonsSecond;

    float oldMass;
    new Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        oldMass = rigidbody2D.mass;
    }

    new void Start()
    {
        base.Start();
    }

    protected override void EnableLaw()
    {
        rigidbody2D.mass = oldMass;
    }
    protected override void DisableLaw()
    {
        oldMass = rigidbody2D.mass;
        rigidbody2D.mass = 1;
    }
}
