using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventario : MonoBehaviour {

    public Image[] itemImagenes = new Image[numHuecos];
    public Item[] items = new Item[numHuecos];
    public const int numHuecos = 4;

    public void AñadirItem(Item nuevoItem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = nuevoItem;
                itemImagenes[i].sprite = nuevoItem.sprite;
                itemImagenes[i].enabled = true;
                return;
            }
        }
    }

    public void QuitarItem(Item itemBorrado)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemBorrado)
            {
                items[i] = null;
                itemImagenes[i].sprite = null;
                itemImagenes[i].enabled = false;
                return;
            }
        }
    }
}
