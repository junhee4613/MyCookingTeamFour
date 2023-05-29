using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Induction : MonoBehaviour
{
    public float timeTem;
    private int maxTem = 150;                          //�ִ� �µ�
    private float test = 0;
    public int speed;                           //�µ��� �ö󰡴� �ӵ��� ���� ��Ű�� ���� ����
    public int fireIndex = 0;                       //���ڰ� �ö󰡸� �δ��� �µ� �ܰ赵 ���� �ö�
    public TextMeshProUGUI textInduction;           //�δ��� �ܰ踦 �ؽ�Ʈ
    public Material inductionMAT;                   //�δ��� �ܰ踦 ����
    public float inductionLayer;                    //�δ��� �µ� �ܰ�
    public TextMeshProUGUI inductionDegrees;        //�µ� ǥ��
    // Start is called before the first frame update        //�δ��ǿ� �ִ� ���ڸ� fireIndex�� ������ ǥ���ϱ� ���� �׽�Ʈ��
    void Start()
    {
        textInduction = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (fireIndex == 1 && test < 30)
        {
            test += fireIndex * 5 * Time.fixedDeltaTime;
        }
        else if (fireIndex == 2 && test < 60)
        {
            test += fireIndex * 4 * Time.fixedDeltaTime;
        }
        else if (fireIndex == 3 && test < 90)
        {
            test += fireIndex * 3 * Time.fixedDeltaTime;
        }
        else if (fireIndex == 4 && test < 120)
        {
            test += fireIndex * 2 * Time.fixedDeltaTime;
        }
        else if (fireIndex == 5 && test < 150)
        {
            test += fireIndex * 1 * Time.fixedDeltaTime;
        }*/

        /*else            //������ ��
        {
            switch (fireIndex)
            {
                case 1:
                    Debug.Log(Mathf.Clamp(test += fireIndex * speed * Time.fixedDeltaTime, 30, 150));
                    break;
                case 2:
                    Debug.Log(Mathf.Clamp(test += fireIndex * speed * Time.fixedDeltaTime, 60, 150));
                    break;
                case 3:
                    Debug.Log(Mathf.Clamp(test += fireIndex * speed * Time.fixedDeltaTime, 90, 150));
                    break;
                case 4:
                    Debug.Log(Mathf.Clamp(test += fireIndex * speed * Time.fixedDeltaTime, 120, 150));
                    break;
                


            }
        }*/

    }
    public void Up()
    {


        if (fireIndex <= 4)
        {
            fireIndex += 1;
            speed = 1;
        }
        inductionLayer = fireIndex * 0.2f;
        inductionMAT.color = new Color(inductionLayer, 0, 0, 1);
        textInduction.text = fireIndex.ToString();
        Debug.Log("�ܰ�: " + fireIndex);
        StopCoroutine(TempertureUp());
        StopCoroutine(TempertureDown());
        StartCoroutine(TempertureUp());


    }
    public void Down()
    {
        if (fireIndex >= 1)
        {
            fireIndex -= 1;
            speed = -1;
        }
        inductionLayer = fireIndex * 0.2f;
        inductionMAT.color = new Color(inductionLayer, 0, 0, 1);
        textInduction.text = fireIndex.ToString();
        Debug.Log("�ܰ�: " + fireIndex);
        StopCoroutine(TempertureUp());
        StopCoroutine(TempertureDown());
        StartCoroutine(TempertureDown());
    }
    IEnumerator TempertureUp()
    {
        timeTem = fireIndex / fireIndex * 0.05f;
        while (maxTem >= test)
        {
            timeTem *= 0.9985f;
            test += timeTem;
            Debug.Log("�µ�: " + Mathf.Clamp(test, 0, maxTem));
            yield return new WaitForSeconds(0.016f);
        }
        

    }
    //�µ��� �÷ȴٰ� ������ ���� �µ� �ܰ�� �߰��������� �� ���� ������ �ٸ� �ӵ��� �ö󰣴� EX) 0~30�������� 10�ʶ� ���� �� �߰��� �µ��� ���� 15���� ������ �� �ٽ� �µ��� �ø��� 15~45������ 10�ʰ� �ɸ���
    IEnumerator TempertureDown()
    {
        timeTem = fireIndex / fireIndex * 0.05f;
        while (0 <= test)
        {
            timeTem *= 0.9985f;
            test -= timeTem * 0.5f;
            Debug.Log("�µ�: " + Mathf.Clamp(test, 0, maxTem));
            yield return new WaitForSeconds(0.016f);
        }
    }
}
