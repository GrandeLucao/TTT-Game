using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{

    // PlayerData vai ser a classe que vai guardar todos os dados que vao ser salvos
    // e recarregados, nota que nao podemos usar tipos do unity (Vector3, etc)
    public int level;
    public float health;
    public float[] position;

    public PlayerData(Player player)
    {
        this.level = player.level;
        this.health = player.health;

        this.position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }

}