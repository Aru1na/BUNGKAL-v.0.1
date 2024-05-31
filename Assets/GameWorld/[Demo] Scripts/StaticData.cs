using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    public static string user;
    public static void SaveData(string username)
    {
        user = username;
    }

}
