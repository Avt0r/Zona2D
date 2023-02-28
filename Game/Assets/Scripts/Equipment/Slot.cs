using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]
    private int id;
    [SerializeField]
    private Item item;
    [SerializeField]
    private int count;
    [SerializeField]
    private GameObject child;

    private void Awake()
    {
        Image image = child.GetComponent<Image>();
        image.sprite = item.ObjImage;
        image.type = Image.Type.Simple;
        image.preserveAspect = true;
    }
}
