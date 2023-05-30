using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Induction : MonoBehaviour
{
    public float tempSpeed;
    public float timeTem;
    private float test = 0;
    public int speed;                           //온도가 올라가는 속도를 증가 시키기 위해 선언
    public int fireLevel = 0;                       //숫자가 올라가면 인덕션 온도 단계도 같이 올라감
    public TextMeshProUGUI textInduction;           //인덕션 단계를 텍스트
    public Material inductionMAT;                   //인덕션 단계를 색깔
    public float inductionLayer;                    //인덕션 온도 단계
    public TextMeshProUGUI inductionDegrees;        //온도 표시
    public bool isInductionON;
    float timerS = 0;
    // Start is called before the first frame update        //인덕션에 있는 숫자를 fireLevel의 값으로 표시하기 위한 테스트용
    void Start()
    {
        textInduction = GetComponent<TextMeshProUGUI>();
        


    }

    // Update is called once per frame

    public void Up()
    {
        if (fireLevel <= 4)
        {
            fireLevel += 1;
            speed = 1;
        }
        inductionLayer = fireLevel * 0.2f;
        inductionMAT.color = new Color(inductionLayer, 0, 0, 1);
        textInduction.text = fireLevel.ToString();
        Debug.Log("단계: " + fireLevel);
        if (!isInductionON)
        {
            StartCoroutine(TemUp());
        }

    }
    public void Down()
    {
        if (fireLevel >= 1)
        {
            fireLevel -= 1;
            speed = -1;
        }
        inductionLayer = fireLevel * 0.2f;
        inductionMAT.color = new Color(inductionLayer, 0, 0, 1);
        textInduction.text = fireLevel.ToString();
        Debug.Log("단계: " + fireLevel);
        if (!isInductionON)
        {
            StartCoroutine(TemDown());
        }
        
    }
    IEnumerator TemUp()
    {
        StopCoroutine(TemDown());
        isInductionON = true;
        while (timeTem <= 150)
        {
            tempSpeed += 0.005f;
            Debug.Log(timeTem = Mathf.SmoothStep(test, 30f * fireLevel, tempSpeed));
            Mathf.Clamp(timeTem, 0, 30 * fireLevel);
            yield return new WaitForSeconds(0.05f);
            if (timeTem >= fireLevel * 29.9)
            {
                isInductionON = false;
                tempSpeed = 0;
                test = timeTem;
                break;
            }
        }
        isInductionON = false;
    }
    IEnumerator TemDown()
    {
        StopCoroutine(TemUp());
        isInductionON = true;
        while (timeTem >= 30)
        {
            tempSpeed += 0.005f;
            Debug.Log(timeTem = Mathf.SmoothStep(test, 30f * fireLevel, tempSpeed));
            yield return new WaitForSeconds(0.05f);
            if (timeTem <= fireLevel * 30)
            {
                isInductionON = false;
                tempSpeed = 0;
                test = timeTem;
                break;
            }
        }
        isInductionON = false;
    }

    //온도를 올렸다가 내리면 같은 온도 단계라도 중간에서부터 더 해져 기존과 다른 속도로 올라간다 EX) 0~30도까지는 10초라 했을 때 중간에 온도를 내려 15도로 떨어진 후 다시 온도를 올리면 15~45도까지 10초가 걸린다

}
