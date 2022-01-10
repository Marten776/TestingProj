using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectImporter : MonoBehaviour
{
    AssetBundle myAssetBundle;
    public List<GameObject> trees = new List<GameObject>();
    int currentTree = 0;
    public ObjectRotator objectRotator;
    GameObject currentTreeObject;
    void Start()
    {
        LoadAssetBundle();
    }

    void LoadAssetBundle()
    {
        myAssetBundle = AssetBundle.LoadFromFile(Application.dataPath + "/Input/trees");

        Debug.Log(myAssetBundle == null ? " Failed " : "Loaded");
        LoadTrees();
        currentTreeObject = Instantiate(trees[currentTree], transform);
        objectRotator.objectToRotate = currentTreeObject;
    }


    void LoadTrees()
    {
        trees.Add((GameObject)myAssetBundle.LoadAsset("Fir_Tree"));
        trees.Add((GameObject)myAssetBundle.LoadAsset("Oak_Tree"));
        trees.Add((GameObject)myAssetBundle.LoadAsset("Poplar_Tree"));
    }
    public void LoadTree(int x)
    {
        DestroyImmediate(currentTreeObject);
        currentTreeObject= Instantiate(trees[x], transform);
        objectRotator.objectToRotate= currentTreeObject;
    }

    public void NextTree()
    {

        if (currentTree >= 0 && currentTree < 2)
        {
            currentTree++;
            LoadTree(currentTree);
        }

        else Debug.Log("I cant load Next Tree!");
    }
    public void PreviousTree()
    {

        if (currentTree > 0 && currentTree <= 2)
        {
            currentTree--;
            LoadTree(currentTree);
        }
            

        else Debug.Log("I cant load previous Tree!");
    }
}
