using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{

    public List<GameObject> ObjectsSaves = new List<GameObject>();
    GameObject[] allFurniture;
    GameObject[] lights;
    GameObject[] brush;
    GameObject[] ui;

    public void SaveGame()
    {
        

        BinaryFormatter bf = new BinaryFormatter();

        FileStream fl = File.Create(Application.persistentDataPath + "/save.gamesave");

        Save save = new Save();

        save.SaveObjects(ObjectsSaves);

        bf.Serialize(fl, save);

        fl.Close();
    }

    public void LoadGame()
    {
        if (!File.Exists(Application.persistentDataPath + "/save.gamesave"))
            return;
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Application.persistentDataPath + "/save.gamesave", FileMode.Open);

            Save save = (Save)bf.Deserialize(fs);
            FullEnum(save);
            fs.Close();

        }
    }

    public void FullEnum(Save save)
    {
        SceneManager.LoadScene((int)SceneManag.SceneList.LoadedScene);
        allFurniture = Resources.LoadAll<GameObject>("Prefabs/Furniture/");
        foreach (GameObject obj in allFurniture)
        {
            foreach (Save.ObjectsData objec in save.ObjectList)
            {
                if (objec.name == obj.name + "(Clone)" || objec.name == obj.name)
                {
                    Instantiate(obj, new Vector3(objec.Position.x,objec.Position.y,objec.Position.z), Quaternion.Euler(objec.Rotation.x, objec.Rotation.y, objec.Rotation.z));
                }
            }
        }
        lights = Resources.LoadAll<GameObject>("Prefabs/Lights/");
        foreach (GameObject obj in lights)
        {
            foreach (Save.ObjectsData objec in save.ObjectList)
            {
                if (objec.name == obj.name + "(Clone)" || objec.name == obj.name)
                {
                    Instantiate(obj, new Vector3(objec.Position.x,objec.Position.y,objec.Position.z), Quaternion.Euler(objec.Rotation.x, objec.Rotation.y, objec.Rotation.z));
                }
            }
        }
        brush = Resources.LoadAll<GameObject>("Prefabs/tool/");
        foreach (GameObject obj in brush)
        {
            foreach (Save.ObjectsData objec in save.ObjectList)
            {
                if (objec.name == obj.name + "(Clone)" || objec.name == obj.name)
                {
                    Instantiate(obj, new Vector3(objec.Position.x,objec.Position.y,objec.Position.z), Quaternion.Euler(objec.Rotation.x, objec.Rotation.y, objec.Rotation.z));
                }
            }
        }
        ui = Resources.LoadAll<GameObject>("Prefabs/UI/");
        foreach (GameObject obj in ui)
        {
            foreach (Save.ObjectsData objec in save.ObjectList)
            {
                if (objec.name == obj.name + "(Clone)" || objec.name == obj.name)
                {
                    Instantiate(obj, new Vector3(objec.Position.x,objec.Position.y,objec.Position.z), Quaternion.Euler(objec.Rotation.x, objec.Rotation.y, objec.Rotation.z));
                }
            }
        }
    }

}


[System.Serializable]
public class Save
{
    [System.Serializable]
    public struct Vec3
    {
        public float x, y, z;

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [System.Serializable]
    public struct ObjectsData
    {
        public Vec3 Position, Rotation;

        public string name;

        public ObjectsData(Vec3 pos, Vec3 rot,string Name)
        {
            Position = pos;
            Rotation = rot;
            name = Name;
        }
    }

    public List<ObjectsData> ObjectList = new List<ObjectsData>();

    public void SaveObjects(List<GameObject> objects)
    {
        foreach (GameObject obj in objects)
        {
            Vec3 pos = new Vec3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
            Vec3 rot = new Vec3(obj.transform.rotation.x, obj.transform.rotation.y, obj.transform.rotation.z);
            string name = obj.name;

            ObjectList.Add(new ObjectsData(pos,rot,name));
        }
    }
}