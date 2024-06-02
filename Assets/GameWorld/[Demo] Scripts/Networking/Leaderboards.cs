using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Leaderboards : MonoBehaviour
{

    public void PostScore(int playerID, Artifacts art){
        StartCoroutine(PostData_Coroutine(playerID, art));
    }
   public IEnumerator PostData_Coroutine(int playerID, Artifacts art){
        string URL = "http://localhost/bungkal/leaderboardsSelect.php";

        int userID = playerID;
        int art_ID = art.art_id;
        string ArtifactName = art.artifact_name;
        int point = art.points;

        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        form.AddField("art_ID", art_ID);
        form.AddField("art_Name", ArtifactName);
        form.AddField("points", point);

        using (UnityWebRequest users = UnityWebRequest.Post(URL, form)){
            yield return users.SendWebRequest();
            if (users.result == UnityWebRequest.Result.ConnectionError || users.result == UnityWebRequest.Result.ProtocolError){
                //outputArea.text = users.error;
            }else{
                Debug.Log(users.downloadHandler.text);
                // Handle the response if needed
            }
        }
   }
}
