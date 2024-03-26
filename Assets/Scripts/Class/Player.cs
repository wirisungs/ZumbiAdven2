using System;
using JetBrains.Annotations;

[Serializable]

public class Player {
    public string PlayerName;
    public string kills;

    public Player(){
    }

    public Player (string name, string kills) {
        PlayerName = name;
        this.kills = kills;
    }
}