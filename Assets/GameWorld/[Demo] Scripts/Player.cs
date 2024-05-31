using UnityEngine;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using System;
using TMPro;
using System.Security.Cryptography.X509Certificates;
using System.Data;


public class Player : MonoBehaviour
{
    public Compile compiler = new Compile();
    public static String username;

    [System.Serializable]
    public class Compile
    {
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
