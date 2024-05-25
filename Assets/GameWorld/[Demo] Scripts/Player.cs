using UnityEngine;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using System;
using TMPro;


public class Player : MonoBehaviour
{
    public TMP_InputField ipnf;
    public Compile compiler = new Compile();


    [System.Serializable]
    public class Compile
    {
        public String username;
        public int heatlhPoints;
        public List<Artifacts> artifactNew = new List<Artifacts>();
    }
    
    
    public void AddArtifact(Artifacts newArtifact)
    {
        Debug.Log("Added artifact: "+newArtifact.artifact_name);
        compiler.artifactNew.Add(newArtifact); 
    }

    

}
    //Compiler of user properties and its inventory of artifacts
