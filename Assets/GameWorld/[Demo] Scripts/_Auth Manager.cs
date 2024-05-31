using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Authentication; //Login Package
using System.Threading.Tasks; //Task functions
using UnityEngine.UI;
using Unity.Services.Core; //
using TMPro;
using System;
using UnityEngine.Networking;
using UnityEngine.SceneManagement; //Text fields
public class AuthManager : MonoBehaviour
{
    public GameObject CloudObject;
    public TMP_Text status;
    //public GameObject LocalFile;
    public TMP_InputField username;
    public TMP_InputField password;

    bool canLogin = false;
    public async void Start(){
        await UnityServices.InitializeAsync();
    }

    public IEnumerator GetData_Coroutine(Action callback)
    {
        string name = username.text;
        string pass = password.text;
        WWWForm form = new WWWForm();
        form.AddField("username", name);
        form.AddField("password", pass);
        string URL = "http://localhost/bungkal/userSelect.php";
        using (UnityWebRequest users = UnityWebRequest.Post(URL, form))
        {
            yield return users.SendWebRequest();
            if (users.result == UnityWebRequest.Result.ConnectionError)
            {
                status.text = users.downloadHandler.text;
            }
            else if (users.result == UnityWebRequest.Result.Success)
            {
                status.text = users.downloadHandler.text;
                if (users.downloadHandler.text == "1"){
                    Debug.Log("Correct Username and Password");
                    canLogin = true;
                    callback();
                } else {
                    Debug.Log("Incorrect username or password");
                }   
            }
            else
            {
                Debug.Log("User is not registered");
            }
        }
    }

    private void GetDataCallback()
    {
        loginTask(); // Call loginTask after GetData_Coroutine completes
    }
   public IEnumerator PostData_Coroutine(){
        string URL = "http://localhost/bungkal/leaderboardsSelect.php";

        int userID = 1;
        int art_ID = 1;
        string ArtifactName = "CHICKEN";
        int point = 10;

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
    } //Testing to check leaderboarding
    public async void Register(){
        await SignUpWithUsernamePasswordAsync();
    }

    public void Login(){ //public void async Login()
        StartCoroutine(GetData_Coroutine(GetDataCallback));
    }

    public async void loginTask(){
        if (canLogin){
            await SignInWithUsernamePasswordAsync();
            SceneManager.LoadScene("GameWorld");
        } else {
            status.text = "Try logging in again";
        }
    }
    public void PostData(){
        StartCoroutine(PostData_Coroutine());
    }
    async Task SignUpWithUsernamePasswordAsync()
        {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username.text, password.text);
            Debug.Log("Successfully signed up! Username: "+username.text);
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }
    async Task SignInWithUsernamePasswordAsync()
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username.text, password.text);
            Debug.Log("SignIn is successful! Username: "+username.text);
            //CloudSaveScript cloud = CloudObject.GetComponent<CloudSaveScript>();
            //cloud.GetPlayerFile();
            Debug.Log("Login Successful: Cloud Database");
            //LocalFileSave Local = LocalFile.GetComponent<LocalFileSave>();
            //Local.OutputJSON(); FILE SAVE TO LOCAL
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }
    
/*   
async Task SignOut()
    {
        try
        {
            AuthenticationService.Instance.SignOut(true);
        }catch (Exception e){
            Debug.Log(e);
        }
    }//STILL ON GOING PROCESS OF LOGOUT SCREEN

 async Task SignInAnonymous(){
        try{
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            print("Signed in");
            Debug.Log(AuthenticationService.Instance.PlayerId);
        }catch(AuthenticationException ex){
            print("Error");
            Debug.Log(ex);
        }
    }*/
    //ONLY USE WHEN DOING A DEMO
}


//This is where the user authenticates themselves. Though, this will be modified on the final version of the app. Still a work in progress but it works