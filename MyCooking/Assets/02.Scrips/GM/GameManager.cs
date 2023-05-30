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
    public Queue<Vector3> IngredPosition = new Queue<Vector3>();
    public Queue <GameObject> ingredientCookIndex = new Queue<GameObject>();
    public List<bool> ingredientIsOut = new List<bool>();
    void Start()
    {
        SelectedFood = null;
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
    public void GetIngredientPosition(int foodIndex)//������ �丮�� ��� �����ǰ��� ����
    {
        if (IngredPosition.Count ==0)
        {
            ingredientIsOut.Clear();
            SelectedFood = foodTable.sheets[0].list[foodIndex];
            IngredPosition.Enqueue(new Vector3(IGList.sheets[0].list[SelectedFood.ingredientIndex1].installerPosX, IGList.sheets[0].list[SelectedFood.ingredientIndex1].installerPosY, IGList.sheets[0].list[SelectedFood.ingredientIndex1].installerPosZ));
            ingredientIsOut.Add(false);
            if (SelectedFood.ingredientIndex2 !=0)
            {
                ingredientIsOut.Add(false);
                IngredPosition.Enqueue(new Vector3(IGList.sheets[0].list[SelectedFood.ingredientIndex2].installerPosX, IGList.sheets[0].list[SelectedFood.ingredientIndex2].installerPosY, IGList.sheets[0].list[SelectedFood.ingredientIndex2].installerPosZ));
                if (SelectedFood.ingredientIndex3 != 0)
                {
                    ingredientIsOut.Add(false);
                    IngredPosition.Enqueue(new Vector3(IGList.sheets[0].list[SelectedFood.ingredientIndex3].installerPosX, IGList.sheets[0].list[SelectedFood.ingredientIndex3].installerPosY, IGList.sheets[0].list[SelectedFood.ingredientIndex3].installerPosZ));
                }
            }
            IngredientPositionDequeue();
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
    public void InteractIngredientItems(GameObject OBJ)
    {
        if (ingredientIsOut.Count != 0)
        {
            if (ingredientIsOut[0] == false)
            {
                foreach (var item in IGList.sheets[0].list)
                {
                    if (item.englishName == OBJ.name && item.index == SelectedFood.ingredientIndex1)
                    {
                        ingredientIsOut[0] = true;
                        ingredientCookIndex.Enqueue(OBJ);
                        break;
                    }
                }
            }
            else if (ingredientIsOut[1] == false)
            {
                foreach (var item in IGList.sheets[0].list)
                {
                    if (item.englishName == OBJ.name && item.index == SelectedFood.ingredientIndex2)
                    {
                        ingredientIsOut[1] = true;
                        ingredientCookIndex.Enqueue(OBJ);
                        break;
                    }

                }
            }
            else if (ingredientIsOut[2] == false)
            {
                foreach (var item in IGList.sheets[0].list)
                {
                    if (item.englishName == OBJ.name && item.index == SelectedFood.ingredientIndex3)
                    {
                        ingredientIsOut[2] = true;
                        ingredientCookIndex.Enqueue(OBJ);
                        guideSphere.SetActive(false);
                        break;
                    }

                }
            }
            IngredientPositionDequeue();
        }
    }
}
