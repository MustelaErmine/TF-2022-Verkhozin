using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    new Transform transform;
    [SerializeField] Transform arrow;
    SpriteMask arrowMask;

    float force = 0;
    const float forcePerSecond = 0.75f;
    const float forceCoeff = 1500f;

    void Start()
    {
        transform = GetComponent<Transform>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        arrowMask = arrow.GetComponentInChildren<SpriteMask>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !GameplayMenu.pause)
        {
            force += forcePerSecond * Time.deltaTime;
            force = Mathf.Min(1, force);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            arrow.position = (transform.position + mousePosition) / 2;
            Vector3 diff = mousePosition - transform.position;
            float angle = -Mathf.Atan(diff.x / diff.y) / Mathf.PI * 180;
            if (diff.y < 0)
                angle = angle - 180;
            arrow.eulerAngles = new Vector3(0, 0, angle);
        } 
        if (Input.GetMouseButtonUp(0) && !GameplayMenu.pause)
        {
            if (force > 0.01f)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 diff = mousePosition - transform.position;
                Jump(diff.normalized * force);
            }
            force = 0;
            arrow.position = new Vector2(10, 10);
        }
        arrowMask.transform.localPosition = new Vector2(0, (1 - force) * -0.52f);
        arrowMask.transform.localScale = new Vector2(4, 1 + (5.5f - 1) * force);
    }
    void Jump(Vector3 where)
    {
        where.z = 0;
        rigidbody2D.AddForce(where * forceCoeff, ForceMode2D.Force);
    }
}
