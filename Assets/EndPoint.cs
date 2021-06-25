using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private bool hasLevelPart = false; 
    public bool HasLevelPart { get { return hasLevelPart; } set { hasLevelPart = value; } }
    [SerializeField] private Types type; public Types Type { get { return type; } }
    public enum Types
    {
        Top,
        Left,
        Right,
        Bottom
    };



}
