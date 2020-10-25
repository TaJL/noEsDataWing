using UnityEngine;
using System.IO;

public static class DataSaver
{
    public static string directory= "/SavedData/";
    public static string FileName= "Data.txt";

    public static void Save(DataFormat other){
        string dir = Application.persistentDataPath + directory;

        if(!Directory.Exists(dir)){
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(other);
        File.WriteAllText(dir+FileName,json);
        Debug.Log("Guarde datos");
    }
    public static DataFormat Load(){
        string fullpath = Application.persistentDataPath + directory + FileName;
        DataFormat dt = new DataFormat();
        if(File.Exists(fullpath)){
            string json = File.ReadAllText(fullpath);
            dt = JsonUtility.FromJson<DataFormat>(json);
            Debug.Log("existen datos");
        }else{
            Debug.Log("no existen datos");
        }
        return dt;
    }
}
