using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Equipment", order = 51)]
public class Item : ScriptableObject
{
    [SerializeField]
    private new string name;
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private int maxCount;
    [SerializeField]
    private int width;
    [SerializeField]
    private int height;
    [SerializeField]
    private Sprite image;

    public string Name
    { get { return name; } }
    public int MaxCount
    { get { return maxCount; } }
    public GameObject Obj
    { get { return obj; } }
    public int Width
    { get { return width; } }
    public int Height
    { get { return height; } }
    public Sprite ObjImage
    { get { return image; } }
}
