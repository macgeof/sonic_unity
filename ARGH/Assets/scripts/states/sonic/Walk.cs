using UnityEngine;
using System.Collections;
using System;

public class Walk : State
{
	public Walk()
	{
		minimumTimeInState = 2.0f;
		minimumHorizontal = 0.01f;
		maximumHorizontal = 4.0f;
		minimumVertical = 0f;
		maximumVertical = 0f;
	}
	
	public override  void Enter(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Enter(__owner, __timeDelay);
		Sonic sonic = __owner as Sonic;
		if (sonic != null)
		{
			OTAnimatingSprite animatingSprite = sonic.AnimatingSprite();
			if (animatingSprite != null)
			{
				Debug.Log("Walk.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("walk");
			}
		}
	}
	
	public override void Execute(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Execute(__owner, __timeDelay);
		Vector2 motion = __owner.Motion;
		if (motion.x < minimumHorizontal)
		{
			Sonic sonic = __owner as Sonic;
			StandStill standStill = new StandStill();
			sonic.StateEngine().ChangeState(standStill, __timeDelay);
			return;
		}
		if (motion.x > maximumHorizontal)
		{
			Debug.Log("Walk.Execute() : changing state to run");
			Sonic sonic = __owner as Sonic;
			Run run = new Run();
			sonic.StateEngine().ChangeState(run, __timeDelay);
			return;
		}
	}
	
	public override void Exit(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Exit(__owner, __timeDelay);
	}
}
