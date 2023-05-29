using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Induction : MonoBehaviour
{
    public float timeTem;
    private int maxTem = 150;                          //최대 온도
    private float test = 0;
    public int speed;                           //온도가 올라가는 속도를 증가 시키기 위해 선언
    public int fireIndex = 0;                       //숫자가 올라가면 인덕션 온도 단계도 같이 올라감
    public TextMeshProUGUI textInduction;           //인덕션 단계를 텍스트
    public Material inductionMAT;                   //인덕션 단계를 색깔
    public float inductionLayer;                    //인덕션 온도 단계
    public TextMeshProUGUI inductionDegrees;        //온도 표시
    // Start is called before the first frame update        //인덕션에 있는 숫자를 fireIndex의 값으로 표시하기 위한 테스트용
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

        /*else            //음수일 때
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
        Debug.Log("단계: " + fireIndex);
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
        Debug.Log("단계: " + fireIndex);
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
            Debug.Log("온도: " + Mathf.Clamp(test, 0, maxTem));
            yield return new WaitForSeconds(0.016f);
        }
        

    }
    //온도를 올렸다가 내리면 같은 온도 단계라도 중간에서부터 더 해져 기존과 다른 속도로 올라간다 EX) 0~30도까지는 10초라 했을 때 중간에 온도를 내려 15도로 떨어진 후 다시 온도를 올리면 15~45도까지 10초가 걸린다
    IEnumerator TempertureDown()
    {
        timeTem = fireIndex / fireIndex * 0.05f;
        while (0 <= test)
        {
            timeTem *= 0.9985f;
            test -= timeTem * 0.5f;
            Debug.Log("온도: " + Mathf.Clamp(test, 0, maxTem));
            yield return new WaitForSeconds(0.016f);
        }
    }
}
