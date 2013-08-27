using UnityEngine;
using System.Collections;
using System;

public class Run : State
{
	public Run()
	{
		minimumTimeInState = 2.0f;
		minimumHorizontal = 4.0f;
		maximumHorizontal = 20.0f;
		minimumVertical = 0f;
		maximumVertical = 0f;
		horizontalDecay = 0.8f;
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
				Debug.Log("Run.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("run");
			}
		}
	}
	
	public override void Execute(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Execute(__owner, __timeDelay);
		Vector2 motion = __owner.Motion;
		Debug.Log("Run.Execute() : " + __owner.id + " :  motion x = " + motion.x);
		if ((motion.x >= 0 && motion.x < minimumHorizontal) || (motion.x <= 0 && motion.x > -minimumHorizontal))
		{
			Sonic sonic = __owner as Sonic;
			Walk walk = new Walk();
			sonic.StateEngine().ChangeState(walk, __timeDelay);
			return;
		}
		if (motion.x > maximumHorizontal)
		{
			Debug.Log("Run.Execute() : changing state to walk");
			Sonic sonic = __owner as Sonic;
			RunFast runFast = new RunFast();
			sonic.StateEngine().ChangeState(runFast, __timeDelay);
			return;
		}
	}
	
	public override void Exit(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Exit(__owner, __timeDelay);
	}
}
