using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCoins : MonoBehaviour
{
    public int numberOfCoins;
    public GameObject prefab;
    public float yOffset;
    public Terrain terrain;

    private float _terrainWidth;
    private float _terrainHeight;

    void Start()
    {
        //tamanho do terreno
        _terrainWidth = terrain.terrainData.size.x;
        _terrainHeight = terrain.terrainData.size.z;

        for (int i = 0; i < numberOfCoins; i++)
        {
            //gera uma posição aleatoria dentro do terreno 
            float posX = UnityEngine.Random.Range(0, _terrainWidth);
            float posZ = UnityEngine.Random.Range(0, _terrainHeight);

            //calcula a altura correspondente ao ponto no terreno
            float altura = Terrain.activeTerrain.SampleHeight(new Vector3(posX, 0, posZ));

            //Cria o prefab na posição
            GameObject coin = Instantiate(prefab, new Vector3(posX, yOffset + altura, posZ), Quaternion.identity);
        }
    }
}
