using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FryFan : BowlBase
{
    protected override void BowlProperty()
    {
        if (GameManager.GMinstatnce().ingredientCookIndex.Count != 0)
        {
            if (GameManager.GMinstatnce().ingredientCookIndex.Peek().name == hit.collider.gameObject.name)
            {
                if (IDTTem.timeTem > 80)
                {
                    SoundManager.SMInstance().ChangeSFX("FrySound");
                    //���⿡ �丮���� ��ũ��Ʈ ������ �ɵ�
                    Debug.Log("�丮 ���� �Լ� ������ �ǰԶ�");
                }
                hit.collider.GetComponent<BoxCollider>().enabled = false;
                GameManager.GMinstatnce().ingredientCookIndex.Dequeue();
                hit.collider.transform.parent = null;
                hit.collider.transform.parent = transform;
                hit.collider.transform.localPosition = Vector3.zero - (Vector3.up * bc.bounds.extents.y);
            }
        }
    }
}
