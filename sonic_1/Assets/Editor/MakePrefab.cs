//adds a menu item to create a prefab
using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakePrefab : MonoBehaviour {
	
	[MenuItem("Brownbridges/Create Prefab from Selection %#p")]
	static void MenuItemMethod()
	{
		CreatePrefab();
	}
	
	static void CreatePrefab()
	{
		//pick up selection from stage - is array of gameobjects (maybe should use transform[] instead, but GO is working for now!)
		GameObject[] __selectedObjects = Selection.gameObjects;
		//loop through the selected objects
		foreach(GameObject __gameObject in __selectedObjects)
		{
			bool __createNew = true;
			//get the path of the currently selected gameobject
			string __path = "Assets/" + __gameObject.name + ".prefab";
			//attempt to find out if prefab of this name already exists in the project
			GameObject __existingObject = Resources.LoadAssetAtPath(__path, typeof(GameObject)) as GameObject;
			Debug.Log("Object already exists : " + (__existingObject != null) + " : " + typeof(GameObject));
			//display dialog to confirm replacement of the already existent gameobject
			if (__existingObject)
			{
				__createNew = EditorUtility.DisplayDialog("Prefab exists",
					"Do you want to replace with the current selection?",
					"Yes",
					"No"
				);
			}
			//if required, go ahead and create the prefab
			if (__createNew)
			{
				createPrefabAndReplace(__gameObject, __path);
			}
		}
	}
	
	static void createPrefabAndReplace(GameObject __gameObject, string __path)
	{
		//create an empty prefab with the path supplied
		Object __newPrefab = PrefabUtility.CreateEmptyPrefab(__path);
		//replace the prefab with the newly created on based on the supplied gameobject
        PrefabUtility.ReplacePrefab(__gameObject, __newPrefab, ReplacePrefabOptions.ConnectToPrefab);
		//do immediate destroy on the gameobject parameter
		DestroyImmediate(__gameObject);
		//instantiate a new gameobject form the new prefab
		PrefabUtility.InstantiatePrefab(__newPrefab);
		//refresh the assets
		AssetDatabase.Refresh();
	}

}
