using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BowlBase : MonoBehaviour
{
    public LayerMask whatIsInduction;
    public BoxCollider bc;
    protected RaycastHit hit;
    public Induction IDTTem;
    public PlayerControl PC;
    bool isOnInduction;
    public Vector3 Center;
    public List<GameObject> cook = new List<GameObject>();
    private void Start()
    {
        IDTTem = GameObject.Find("InductionIndex").GetComponent<Induction>();
        bc = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        if (transform.parent == null)
        {
            isOnInduction = false;
        }
        else
        {
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.3f, whatIsInduction))
            {
                if (!isOnInduction)
                {
                    isOnInduction = true;
                    if (transform.parent.name.Contains("Controller"))
                    {
                        if (PC.objOnRighttHand == transform)
                        {
                            PC.objOnRighttHand = null;
                            this.transform.parent = null;
                        }
                        else if (PC.objOnLeftHand == transform)
                        {
                            PC.objOnRighttHand = null;
                            this.transform.parent = null;
                        }
                    }
                    BoxCollider inductionBC = hit.collider.GetComponent<BoxCollider>();
                    transform.parent = hit.collider.transform;
                    transform.rotation = Quaternion.identity;
                    transform.localPosition = new Vector3(0,inductionBC.bounds.extents.y,-0.62f);
                }
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
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position+Center,0.2f);
    }
}
