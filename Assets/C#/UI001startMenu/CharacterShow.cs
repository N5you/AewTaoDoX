using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShow : MonoBehaviour
{
    private void OnMouseUp()
    {
        GameObject.Find("Canvas").GetComponent<StartMenuCollo>().OnCharacterClick(gameObject);
    }
}
