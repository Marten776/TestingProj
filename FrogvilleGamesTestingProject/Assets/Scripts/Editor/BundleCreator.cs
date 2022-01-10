using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BundleCreator : Editor
{
    [MenuItem("Assets/ Build AssetBundles")]
    static void BuildAssetBundles()
    {
        BuildPipeline.BuildAssetBundles(Application.dataPath + "/Input", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);

    }

}
