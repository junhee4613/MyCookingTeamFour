using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Induction : MonoBehaviour
{
    public bool fire = true;
    public int fireIndex = 0;
    public Text text;
    // Start is called before the first frame update        //인덕션에 있는 숫자를 fireIndex의 값으로 표시하기 위한 테스트용
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
