using UnityEngine;
using System.Collections;

public enum relatedGameObjects{sonic};

public class Entity : MonoBehaviour
{
	private static int _NEXT_ID = 0;
	
	private OTAnimatingSprite	animatingSprite;
	private StateEngine			stateEngine;
	protected Vector2			motion					=	new Vector2(0f,0f);
	protected bool				playerControlled		=	false;
	
	public static int nextId()
	{
		return _NEXT_ID++;
	}
	
	public int id = -1;
	public string name = "";
	public GameObject relatedGameObject;
	
	// Use this for initialization
	public void SetId ()
	{
		if (id == -1)
		{
			id = Entity.nextId();
		}
	}
	
	public virtual void doStateUpdate(float __timeDelay = 0.0f)
	{
		_update(__timeDelay);
	}
	
	protected void _update (float __timeDelay)
	{
//		Debug.Log("Entity._update : " + id + " : " + name);
	}
	
	public StateEngine StateEngine()
	{
		return stateEngine;
	}
	
	public OTAnimatingSprite AnimatingSprite()
	{
		return animatingSprite;
	}
	
	public void SetStateEngine(StateEngine __engine)
	{
		stateEngine = __engine;
	}
	
	public virtual void SetAnimatingSprite(OTAnimatingSprite __sprite)
	{
		animatingSprite = __sprite;
	}
	
	public Vector2 Motion
	{
		get
		{
			return motion;
		}
		set
		{
			motion = value;
		}
	}
	
	public bool PlayerControlled
	{
		get { return playerControlled; }
		set { playerControlled = value; }
	}
}
