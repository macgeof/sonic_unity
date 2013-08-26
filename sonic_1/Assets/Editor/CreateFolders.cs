// creates the basic folder structure for the project
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class CreateFolders : MonoBehaviour {
	
	[MenuItem("Brownbridges/Create Project Folders")]
	static void MenuItemMethod()
	{
		GenerateFolders();
	}
	
	static void GenerateFolders()
	{
		string __projectPath = Application.dataPath + "/";
		ArrayList __folderList = new ArrayList();
		__folderList.Add("Audio");
		__folderList.Add("Fonts");
		__folderList.Add("Materials");
		__folderList.Add("Meshes");
		__folderList.Add("Packages");
		__folderList.Add("Physics");
		__folderList.Add("Prefabs");
		__folderList.Add("Resources");
		__folderList.Add("Scripts");
		__folderList.Add("Shaders");
		__folderList.Add("Sprites");
		__folderList.Add("Textures");
		for (int i = 0; i < __folderList.Count; i++)
		{
			Directory.CreateDirectory(__projectPath + __folderList[i]);
		}
		
		AssetDatabase.Refresh();
	}
}
