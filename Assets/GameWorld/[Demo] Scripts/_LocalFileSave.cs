using UnityEngine;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using System;
using Unity.VisualScripting;

public class LocalFileSave : MonoBehaviour
{
    public TextAsset jsonText;
    public GameObject PlayerFile;
    public void OutputJSON()
    {
        Player player = PlayerFile.GetComponent<Player>(); //isaiah gameobject
        string strOutput = JsonUtility.ToJson(player.compiler); //string = isaiah.text
        File.WriteAllText(Application.dataPath + "/PlayerFile.json", strOutput); //file = string
        Debug.Log("Local Player File successfully imported to Unity Player Attributes");
    }

    public void InputJSON()
    {
        Player player = PlayerFile.GetComponent<Player>();
        player.compiler = JsonUtility.FromJson<Player.Compile>(jsonText.text);
        Debug.Log("Unity Player Attributes successfully imported to Local Player File");
    }
}

//This reads and writes the player's data into and from the PlayerFile.JSON file