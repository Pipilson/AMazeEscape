using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MontarLabirinto : MonoBehaviour
{
    [SerializeField]
    GameObject[] prefabParede;
    MapSize map;
    public bool ironman;

    void Start()
    {
        map = GameObject.Find("Imortal").GetComponent<MapSize>();

        if (map.mazeX < 10)
        {
            map.mazeX = 10;
        }

        if (map.mazeY < 10)
        {
            map.mazeY = 10;
        }

        if (map.mazeX == 200 && map.mazeY == 200)
        {
            ironman = true;
        }

        else
        {
            ironman = false;
        }

        Vector3 refT = prefabParede[0].GetComponent<Renderer>().bounds.size;
        Vector3 refP = new Vector3(-2, 2, -1);
        string temp = GerarLabirinto.generateMaze(map.mazeX, map.mazeY);
        string[] strArray = temp.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int linhas = strArray.Length;
        int colunas = strArray[0].Length;

        for (int l = 0; l < linhas; l++)
        {
            for (int c = 0; c < colunas; c++)
            {
                if (strArray[l][c] == '1')
                {
                    int rnd = Random.Range(0, prefabParede.Length - 3);
                    Instantiate(prefabParede[rnd], new Vector3(refP.x + refT.x * l, 0, refP.y + refT.y * c), Quaternion.identity).name = "P_" + l + "_" + c;
                }

                if (strArray[l][c] == '0')
                {
                    Instantiate(prefabParede[6], new Vector3(refP.x + refT.x * l, -2.45f, refP.y + refT.y * c), Quaternion.identity).name = "C_" + l + "_" + c;

                    int rnd = Random.Range(1, 11);

                    if (rnd == 10)
                    {
                        Instantiate(prefabParede[4], new Vector3(refP.x + refT.x * l, 0, refP.y + refT.y * c), transform.rotation).name = "I_" + l + "_" + c;
                    }
                }

                if (strArray[l][c] == '3')
                {
                    Instantiate(prefabParede[5], new Vector3(refP.x + refT.x * l, -2.45f, refP.y + refT.y * c), Quaternion.identity).name = "F_" + l + "_" + c;
                }
            }
        }
    }
}