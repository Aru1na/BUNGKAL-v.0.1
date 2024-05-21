using UnityEngine;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using System;
using TMPro;


[System.Serializable]
public class Person
{
    public String username;
    public int heatlhPoints;
}
public class Player : MonoBehaviour
{
    public TMP_InputField ipnf;
    [System.Serializable]
    public class ArtifactList
    {
        public List<Artifacts> artifactNew = new List<Artifacts>();
    }
    //This is the inventory


    [System.Serializable]
    public class Compile
    {
        public Person personInfo = new Person();
        public ArtifactList ArtInfo = new ArtifactList();
    }
    public Compile compiler = new Compile();
    
    

}
    //Compiler of user properties and its inventory of artifacts
