using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingUtensils : MonoBehaviour
{
    public int layerMask;
    public List<GameObject> cook = new List<GameObject>();
    // Start is called before the first frame update
    void Start()        //���� ��ġ���� �� ������ �ϼ��ǰ� �ϱ� �� �ش� ������ ��ġ�뿡 �ɾ����� �ϱ�
    {
        layerMask = 1 << LayerMask.NameToLayer("Objects");
        //����Ʈ���� �丮 ��� Data�� �����ͼ� �� ����Ʈ�� �ִ� �͵�� ���� �̸��� ���� ������Ʈ�� �� ��ũ��Ʈ�� ���� ������Ʈ�� ����� �� gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 0.5f, Color.red);
        RaycastHit hitInfo;
        
        if (Physics.Raycast(this.transform.position, transform.forward, out hitInfo, 0.7f, layerMask))
        {
            for (int i = 0; i < cook.Count; i++)
            {

            }
            Debug.Log("����");
            cook[0].gameObject.SetActive(false);
            cook[1].gameObject.SetActive(false);
        }
    }
}
