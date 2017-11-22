using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    Author 		: Md. Shajahan Kabir Saju
	Create Date : 22 November, 2017
	Description : Loading 3d asset(asset bundle) into run time from sd card or phone memory
	Note that: Set Write Access = External (SDCard) into player setting.
*/
public class Load3dAssets : MonoBehaviour {
	
	public Text showText;

	void Start () {
		StartCoroutine (FuncLoadAssets ());
	}

	IEnumerator FuncLoadAssets(){
		while(!Caching.ready)
			yield return null;
		//aa is a 3d asset bundle
		//for phone memory
		//paste aa asset bundle into files folder that is exist in yor packege name
		//aa is a bundle name
		string bundleURL ="file://"+ Application.persistentDataPath+"/aa";
		//for sd card
		//Create a folder into your sd card named my3dasset. Paste aa bundle into my3dasset folder.
		//string bundleURL = "file:///mnt/sdcard/my3dasset/aa";
		using (WWW www = WWW.LoadFromCacheOrDownload (bundleURL, 1)) {
			yield return www;
			if (www.error == "") {
				AssetBundle bundle = www.assetBundle;
				//aa is object name not bundle name
				GameObject temp = (GameObject)bundle.LoadAsset ("aa");
				Instantiate (temp, new Vector3 (0, 0, 0), Quaternion.identity);
			} else {
				showText.text = "Error: "+www.error+":";
				throw new UnityException ("WWW Download had an error: " + www.error);
			}
		}


	}


}
