using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NewBehaviourScript : MonoBehaviour
{
    public class CreateAssetBundles
    {
        [MenuItem("Assets/Build AssetBundles by daydev")]
        static void BuildAllAssetBundles()
        {
            BuildPipeline.BuildAssetBundles("AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        }
    }
}
