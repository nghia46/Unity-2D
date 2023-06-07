using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string ItemName;
    public Sprite ItemIcon;
    public value price;
    public itemType Type;

    public enum itemType
    {
        weapon,
        potion,
        material,
        armor,
        shield,
        tool,
        book,
        plant,
        ring,
        amulet,
    }
    public enum value
    {
        ten = 10,
        twenty = 20,
        fifty = 50,
        hundred = 100,
        fiveHunderd = 500
    }

}
