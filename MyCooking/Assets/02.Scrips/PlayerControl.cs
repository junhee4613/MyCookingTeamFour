using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    #region 변수
    private Transform leftHandTR;
    private Transform rightHandTR;
    private Transform objOnLeftHand;
    private Transform objOnRighttHand;
    public LayerMask OBJLayers;
    #endregion
    private void Awake()
    {
        leftHandTR = GameObject.Find("LeftHand Controller").GetComponent<Transform>();
        rightHandTR = GameObject.Find("RightHand Controller").GetComponent<Transform>();
    }
    #region VR 검지손가락 인풋관리
    public void OnRightTriggerPress(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            SenseObjects(rightHandTR);
        }
        if (ctx.canceled)
        {
            CancelGrapping(rightHandTR);
        }
    }
    public void OnLeftTriggerPress(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            SenseObjects(leftHandTR);
        }
        if (ctx.canceled)
        {
            CancelGrapping(leftHandTR);
        }
    }
    private void SenseObjects(Transform handTR)
    {
        RaycastHit Hit;
        if (Physics.Raycast(handTR.position, handTR.forward, out Hit, 0.3f, OBJLayers, QueryTriggerInteraction.UseGlobal))
        {
            Debug.Log("레이케스터");
            if (Hit.collider.gameObject.layer == 7)
            {
                GameObject instTemp = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/"+Hit.transform.name.Replace(" Installer","")),handTR);
                float instExtend = instTemp.GetComponent<BoxCollider>().bounds.extents.z / 2;
                instTemp.transform.localPosition = Vector3.forward * instExtend;
                instTemp.transform.localRotation = Quaternion.identity;
                if (handTR == leftHandTR)
                {
                    objOnLeftHand = instTemp.transform;
                }
                else if (handTR == rightHandTR)
                {
                    objOnRighttHand = instTemp.transform;
                }
            }
            else if (Hit.collider.gameObject.layer == 6)
            {
                Debug.Log("레이어 64");
                GameObject OBJTemp = Hit.collider.gameObject;
                OBJTemp.transform.SetParent(handTR);
                float objExtend = OBJTemp.GetComponent<BoxCollider>().bounds.extents.z / 2;
                OBJTemp.transform.localPosition = Vector3.forward * objExtend;
                OBJTemp.transform.localRotation = Quaternion.identity;
                if (handTR == leftHandTR)
                {
                    objOnLeftHand = OBJTemp.transform;
                }
                else if (handTR == rightHandTR)
                {
                    objOnRighttHand = OBJTemp.transform;
                }
            }
            if (objOnLeftHand != null)
            {
                if (objOnLeftHand.name.Contains("(Clone)"))
                {
                    objOnLeftHand.name = objOnLeftHand.name.Replace("(Clone)","");
                    Debug.Log("앙");
                }
                GameManager.GMinstatnce().InteractIngredientItems(objOnLeftHand.name);
            }
            else if(objOnRighttHand != null)
            {
                if (objOnRighttHand.name.Contains("(Clone)"))
                {
                    objOnRighttHand.name = objOnRighttHand.name.Replace("(Clone)", "");
                    Debug.Log("앙");
                }
                GameManager.GMinstatnce().InteractIngredientItems(objOnRighttHand.name);
            }
        }
    }
    private void CancelGrapping(Transform handTR)
    {
        if (objOnLeftHand != null&& handTR == leftHandTR)
        {
            if (handTR == leftHandTR)
            {
                objOnLeftHand.parent = null;
                objOnLeftHand= null;
            }
        }
        else if (objOnRighttHand != null && handTR == rightHandTR)
        {
            if (handTR == rightHandTR)
            {
                objOnRighttHand.parent = null;
                objOnRighttHand = null;
            }
        }
    }
    #endregion
}
