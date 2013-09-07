using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
	Sonic sonic;
	EntityManager entityManager;
	MessageDispatcher messageDispatcher;
	
	// Use this for initialization
	void Start ()
	{
		entityManager = EntityManager.getInstance();
		messageDispatcher = MessageDispatcher.getInstance();
		OTSprite sprite = OT.CreateSpriteAt("sonic_prototype", new Vector2(20,20));
		sprite.name = "my_sonic_instance";
//		Rigidbody body = sprite.rigidbody;
//		Debug.Log("start" + body + " : sonic id = " + sonic.id);
//		if (body != null)
//		{
//			body.useGravity = true;
//		}
		OTAnimatingSprite animatingSprite = sprite as OTAnimatingSprite;
		
		sonic = animatingSprite.gameObject.AddComponent("Sonic") as Sonic;
		sonic.name = "mySonic";
		sonic.PlayerControlled = true;
//		animatingSprite.Play("stand_anim");
		sonic.SetAnimatingSprite(animatingSprite);
//		sprite.animation.Stop();
//		GameObject tempsonic = GameObject.Find("sonic_sprite");
//		GameObject sonic = GameObject.Instantiate(tempsonic) as GameObject;
//		sonic.name = "SONIC";
//		GameObject.DestroyImmediate(tempsonic);
		bool added = entityManager.addEntity(sonic);
		Debug.Log("start : " + added + " : sonic id = " + sonic.id);
		OT.view.movementTarget = sonic.relatedGameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{
		entityManager.update(Time.deltaTime);
//		Sonic[] sonics;
//		Entity[] entities;
//		GameObject sonic = entityManager.getEntityByName("SONIC");
//		sonics = sonic.GetComponents<Sonic>();
//		entities = sonic.GetComponents<Entity>();
//		Debug.Log("sonics = " + sonics.Length + " : entities = " + entities.Length);
	}
}
