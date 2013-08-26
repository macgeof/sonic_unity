using UnityEngine;
using System.Collections;
using System;

public class RunFast : State
{
	public RunFast()
	{
		minimumHorizontal = 8.0f;
		maximumHorizontal = 8.0f;
		minimumVertical = 0f;
		maximumVertical = 0f;
		horizontalDecay = 1f;
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
				Debug.Log("RunFast.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("fast_run");
			}
		}
	}
	
	public override void Execute(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Execute(__owner, __timeDelay);
		Vector2 motion = __owner.Motion;
		Debug.Log("RunFast.Execute() : " + __owner.id + " :  motion x = " + motion.x);
		if ((motion.x >= 0 && motion.x < minimumHorizontal) || (motion.x <= 0 && motion.x > -minimumHorizontal))
		{
			Sonic sonic = __owner as Sonic;
			Run run = new Run();
			sonic.StateEngine().ChangeState(run, __timeDelay);
			return;
		}
		if (motion.x > maximumHorizontal)
		{
			motion.x = maximumHorizontal;
			__owner.Motion = motion;
		}
	}
	
	public override void Exit(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Exit(__owner, __timeDelay);
	}
}
