using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlBase : MonoBehaviour
{
    public LayerMask whatIsInduction;
    private BoxCollider bc;
    private void Start()
    {
        bc = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        RaycastHit hit;
        if (transform.parent == null)
        {
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.3f, whatIsInduction))
            {
                hit.collider.transform.SetParent(transform);
            }
        }
        if (Physics.SphereCast(transform.position, bc.bounds.extents.x, Vector3.up, out hit, 0, whatIsInduction))
        {
            BowlProperty();
        }

    }
    protected virtual void BowlProperty()
    {

    }
}
