using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Induction : MonoBehaviour
{
    public bool fire = true;
    public int fireIndex = 0;
    public Text text;
    // Start is called before the first frame update        //�δ��ǿ� �ִ� ���ڸ� fireIndex�� ������ ǥ���ϱ� ���� �׽�Ʈ��
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + fireIndex;
    }
    public void OnCollisionStay(Collision collision)
    {
        
    }
    public void Up()
    {
        if (fire)
        {
            fireIndex += 1;
        }
    }
    public void Down()
    {
        if (fire)
        {
            fireIndex -= 1;
        }
    }
}
