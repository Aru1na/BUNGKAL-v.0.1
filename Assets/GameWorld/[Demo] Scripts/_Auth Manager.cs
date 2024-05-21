using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Authentication; //Login Package
using System.Threading.Tasks; //Task functions
using UnityEngine.UI;
using Unity.Services.Core; //
using TMPro;
using System; //Text fields
public class AuthManager : MonoBehaviour
{
    public GameObject CloudObject;
    public GameObject LocalFile;
    public TMP_InputField username;
    public TMP_InputField password;

    public async void Start(){
        await UnityServices.InitializeAsync();
    }
    
    public async void Register(){
            await SignUpWithUsernamePasswordAsync();
        }

    public async void Login(){
        await SignInWithUsernamePasswordAsync();
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
            CloudSaveScript cloud = CloudObject.GetComponent<CloudSaveScript>();
            cloud.GetPlayerFile();
            LocalFileSave Local = LocalFile.GetComponent<LocalFileSave>();
            Local.OutputJSON();
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