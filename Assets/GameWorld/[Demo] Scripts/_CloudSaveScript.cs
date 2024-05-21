using System.Collections.Generic;
using UnityEngine;
using Unity.Services.CloudSave;
using UnityEngine.UI;
using Unity.Services.Core;
using TMPro; //Text field
using Unity.Services.Authentication; //Login Package
using Unity.Services.CloudSave.Models; //Cloudsave??
using System.Text;
using System.IO; //JSON Converter
public class CloudSaveScript : MonoBehaviour
{
    
    public async void Start(){
        await UnityServices.InitializeAsync();
    }
    
    public async void PushPlayerFile()
    {
        byte[] file = System.IO.File.ReadAllBytes(Application.dataPath + "/PlayerFile.json");
        await CloudSaveService.Instance.Files.Player.SaveAsync("PlayerFile", file);
        Debug.Log("File successfully uploaded to player database");
    }
    public async void GetPlayerFile(){
        byte [] file = await CloudSaveService.Instance.Files.Player.LoadBytesAsync("PlayerFile");
        string jsonData = Encoding.UTF8.GetString(file);
        File.WriteAllText(Application.dataPath + "/PlayerFile.json", jsonData);
        Debug.Log("File successfully saved locally");
    }

    public async void DeletePlayerFile()
    {
        await CloudSaveService.Instance.Data.Player.DeleteAllAsync();
    }

    /*
    public async void SaveData(){
        Debug.Log("Saved");
        var data = new Dictionary<string, object>{ { "artifactID1", inpf.text } };
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
        inpf.text = AuthenticationService.Instance.PlayerId;
    }

    public async void LoadData(){
        Dictionary<string, Item> serverData =
        await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { "artifactID1" });
        foreach (var kvp in serverData)
        {
            if (serverData.TryGetValue("artifactID1", out var firstKey)) {
                inpf.text = firstKey.Value.GetAs<string>();
            }
        }
    }
*/
}


//This script downloads and uploads the PlayerFile.json into the Unity Cloud Save Database