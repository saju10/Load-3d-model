using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*
    Author 		: Md. Shajahan Kabir Saju
	Create Date : 22 November, 2017
	Description : Create Asset Bundle for a 3d model. also kept this script into editor folder
*/

public class CreateAssetBundle : Editor {

	[MenuItem("Bundle/Make Asset Bundle")]
	static void  BundleAllAssets(){
		BuildPipeline.BuildAssetBundles ("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.Android);
	}

}
