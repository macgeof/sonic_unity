using UnityEngine;
using System.Collections;
using System;

public class Fall : State
{

	public Fall() { }
	
	public override  void Enter(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Enter(__owner, __timeDelay);
		Sonic sonic = __owner as Sonic;
		if (sonic != null)
		{
			OTAnimatingSprite animatingSprite = sonic.AnimatingSprite();
			if (animatingSprite != null)
			{
				Debug.Log("Fall.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("fall");
			}
		}
	}
	
	public override void Execute(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Execute(__owner, __timeDelay);
	}
	
	public override void Exit(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Exit(__owner, __timeDelay);
		Sonic sonic = __owner as Sonic;
		if (sonic != null)
		{
			StateEngine stateEngine = sonic.StateEngine();
			Bounce bounceState = new Bounce();
			stateEngine.ChangeState(bounceState);
		}
	}
}
