using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Induction : MonoBehaviour
{
    public bool fire = true;
    public int fireIndex = 0;
    public TextMeshProUGUI text;
    public Material inductionMAT;
    public float inductionLayer;
    // Start is called before the first frame update        //�δ��ǿ� �ִ� ���ڸ� fireIndex�� ������ ǥ���ϱ� ���� �׽�Ʈ��
    void Start()
    {
        /*text = GetComponent<TextMeshProUGUI>();*/             //���߿� �ּ� Ǯ��
    }

    // Update is called once per frame
    void Update()
    {

        text.text = fireIndex.ToString();
        Debug.Log(fireIndex);

    }
    public void OnCollisionStay(Collision collision)
    {
        
    }
    public void Up()
    {
        if (fire)
        {
            
            if (fireIndex <= 4)
            {
                fireIndex += 1;
            }
            inductionLayer = fireIndex * 0.2f;
            inductionMAT.color = new Color(inductionLayer, 0, 0, 1);
        }
    }
    public void Down()
    {
        if (fire)
        {
            if (fireIndex >= 1)
            {
                fireIndex -= 1;
            }
            inductionLayer = fireIndex * 0.2f;
            inductionMAT.color = new Color(inductionLayer, 0, 0, 1);

        }


    }
}
