

using Unity.VisualScripting;

[System.Serializable]

public class Artifacts
{
    public Artifacts(string artName, int artId, int dura, int dmg)
    {
        artifact_name = artName;
        art_id = artId;
        durability = dura;
        damage = dmg;
    }

    public string artifact_name { get; set; }
    public int art_id { get; set; }
    public int durability { get; set;}
    public int damage { get; set;}
}


//These are the object properties for the artifacts that will be given to the players.