using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class CSVReader_Sam : MonoBehaviour
{
    TextAsset csvFile_PlayerPosition; //CSVファイル
    List<string[]> csvDatas_PlayerPosition = new List<string[]>();//中身を入れるリスト
    //public static List<int[]> csvIntDatas = new List<int[]>();
    public static int[,] csvIntDatas_playerPosition = new int[8,8];
    public string csvFileName_PlayerPosition;

    TextAsset csvFile; //CSVファイル
    List<string[]> csvDatas = new List<string[]>();//中身を入れるリスト
    //public static List<int[]> csvIntDatas = new List<int[]>();
    public static int[,] csvIntDatas = new int[8, 8];
    public string csvFileName;

    // Start is called before the first frame update
    void Start()
    {
        csvFile = Resources.Load(csvFileName) as TextAsset;
        if(csvFile == null)
        {
            Debug.Log("ないよ");
        }

        StringReader reader = new StringReader(csvFile.text);


        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
 
        for(int i = 0; i <= 7; i++)
        {
            for(int j = 0; j <= 7; j++)
            {
                csvIntDatas[i,j] = int.Parse(csvDatas[i][j]);
                
            }
        }





        csvFile_PlayerPosition = Resources.Load(csvFileName_PlayerPosition) as TextAsset;
        if (csvFile_PlayerPosition == null)
        {
            Debug.Log("ないよ");
        }

        StringReader reader_PlayerPosition = new StringReader(csvFile_PlayerPosition.text);


        while (reader_PlayerPosition.Peek() != -1)
        {
            string line = reader_PlayerPosition.ReadLine();
            csvDatas_PlayerPosition.Add(line.Split(','));
        }

        for (int i = 0; i <= 7; i++)
        {
            for (int j = 0; j <= 7; j++)
            {
                csvIntDatas_playerPosition[i, j] = int.Parse(csvDatas_PlayerPosition[i][j]);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
