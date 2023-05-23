using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LiquidObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Liquid;
    private void OnEnable()
    {
        Liquid.DOScaleY(3, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (transform.rotation.z > 0.258819103)
        {
            if (Physics.Raycast(Liquid.position, -Liquid.up, out hit, 10, 128))
            {
                Debug.Log("��");
                Debug.Log(hit.point);

            }
        }

    }
}

