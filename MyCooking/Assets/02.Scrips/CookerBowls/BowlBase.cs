using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BowlBase : MonoBehaviour
{
    public LayerMask whatIsInduction;
    public BoxCollider bc;
    protected RaycastHit hit;
    RaycastHit[] CookHit;
    public Induction IDTTem;
    private void Start()
    {
        IDTTem = GameObject.Find("InductionIndex").GetComponent<Induction>();
        bc = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        if (transform.parent == null)
        {
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.3f, whatIsInduction))
            {
                hit.collider.transform.SetParent(transform);
            }
        }
        if (Physics.SphereCast(transform.position, bc.bounds.extents.y, Vector3.up, out hit, 0.3f, whatIsInduction))
        {
            BowlProperty();
        }


    }
    protected virtual void BowlProperty()
    {
        //추후 유지보수를 원하면 아래에서 구현하는 이 함수에 요리 방식을 이프문으로 넣어준다.
    }
}
