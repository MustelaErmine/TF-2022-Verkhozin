using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FrictionForceHandler : PhysicsLawHandler
{
    public override Law MyLaw => Law.AmontonCoulomb;

    [SerializeField] bool searchInChildren;

    [SerializeField] PhysicsMaterial2D normalMaterial, noFriction;
    Collider2D[] colliders;

    void Awake()
    {
        colliders = GetComponents<Collider2D>();
        if (searchInChildren)
        {
            colliders = (colliders.ToList().Union(GetComponentsInChildren<Collider2D>().ToList())).ToArray();
        }
    }

    new void Start()
    {
        base.Start();
    }

    protected override void EnableLaw()
    {
        foreach(Collider2D collider in colliders)
        {
            collider.sharedMaterial = normalMaterial;
        }
    }
    protected override void DisableLaw()
    {
        foreach (Collider2D collider in colliders)
        {
            collider.sharedMaterial = noFriction;
        }
    }
}
