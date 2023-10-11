using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New save", menuName = "PlayerSave")]
public class PlayerScriptableObject : ScriptableObject
{
    public int health;
    public int batteries;
    public int epinephrineInjection;
    public int ammo9mm;
    public int arrowQuiver;
    public Vector3 position;
}
