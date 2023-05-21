using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gm;
    public static GameManager GMinstatnce() {  return gm;  }
    public foodList.Param SelectedFood;
    public foodList foodTable;
    public ingredientList IGList;
    public bool isGuideLineEnabled;
    public GameObject guideSphere;
    [SerializeField]public Queue<Vector3> IngredPosition = new Queue<Vector3>();
    void Start()
    {
        SelectedFood = foodTable.sheets[0].list[1];
        if (gm != null)
        {
            Destroy(this);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this);
        }
    }
    public void GetIngredientPosition(int foodIndex)//선택한 요리의 재료 포지션값을 받음
    {
        if (isGuideLineEnabled && SelectedFood != null)
        {
            SelectedFood = foodTable.sheets[0].list[foodIndex];
            IngredPosition.Enqueue(new Vector3(IGList.sheets[0].list[SelectedFood.ingredientIndex1].installerPosX, IGList.sheets[0].list[SelectedFood.ingredientIndex1].installerPosY, IGList.sheets[0].list[SelectedFood.ingredientIndex1].installerPosZ));
            if (SelectedFood.ingredientIndex2 !=0)
            {
                IngredPosition.Enqueue(new Vector3(IGList.sheets[0].list[SelectedFood.ingredientIndex2].installerPosX, IGList.sheets[0].list[SelectedFood.ingredientIndex2].installerPosY, IGList.sheets[0].list[SelectedFood.ingredientIndex2].installerPosZ));
                if (SelectedFood.ingredientIndex3 != 0)
                {
                    IngredPosition.Enqueue(new Vector3(IGList.sheets[0].list[SelectedFood.ingredientIndex3].installerPosX, IGList.sheets[0].list[SelectedFood.ingredientIndex3].installerPosY, IGList.sheets[0].list[SelectedFood.ingredientIndex3].installerPosZ));
                }
            }
        }
    }
    public void IngredientPositionDequeue()
    {
        if(guideSphere == null&& isGuideLineEnabled)
        {
            guideSphere = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/TestShpere"));
        }
        if (IngredPosition.Count>0 && isGuideLineEnabled)
        {
            guideSphere.SetActive(true);
            guideSphere.transform.position = IngredPosition.Dequeue();
        }
    }
}
