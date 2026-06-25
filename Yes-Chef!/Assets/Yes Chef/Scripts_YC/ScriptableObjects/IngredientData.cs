using UnityEngine;

public enum BaseIngredientType { ForTable,ForStove,DirectServe,ReadyToServe}

//public enum IngredientType
//{
//    Cheese,
//  //  RawMeat,
//  //  CookedMeat,
//    Carrot,
//    ChoppedCarrot
//}


[CreateAssetMenu(fileName = "Ingredient", menuName = "Cooking/Ingredient")]
public class IngredientData : ScriptableObject
{
    public string ingredientName;
    public BaseIngredientType placeWhere;
  //  public IngredientType ingredientType;
    public Sprite icon;
    public GameObject worldPrefab;

    public int ingredientScore;
}