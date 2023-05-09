using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gm;
    public static GameManager GMinstatnce() {  return gm;  }
    void Start()
    {
        if(gm != null)
        {
            Destroy(this);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this);
        }
    }
}
