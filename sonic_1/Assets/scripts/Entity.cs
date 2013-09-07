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
	
	public void Update()
	{
		//do nothing
	}
	
	protected void _update (float __timeDelay)
	{
		float __positionX = transform.position.x + motion.x;
		float __positionY = transform.position.y + motion.y;
		Vector3 __newPosition = new Vector3(__positionX, __positionY, 1f);
		transform.position = __newPosition;
		Debug.Log("Entity.doStateUpdate : " + id + " : " + name + " : x = " + transform.position.x + ", y = " + transform.position.y);
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
