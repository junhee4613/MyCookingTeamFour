using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodReciepeButton : MonoBehaviour
{
    public int foodIndex;
    public void OnButtonFoodPick()
    {
        GameManager.GMinstatnce().GetIngredientPosition(foodIndex);
    }
}
