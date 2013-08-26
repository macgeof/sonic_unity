using UnityEngine;
using System.Collections;
using System;

public class LookUp : State
{

	public LookUp() { }
	
	public override  void Enter(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Enter(__owner, __timeDelay);
		Sonic sonic = __owner as Sonic;
		if (sonic != null)
		{
			OTAnimatingSprite animatingSprite = sonic.AnimatingSprite();
			if (animatingSprite != null)
			{
				Debug.Log("LookUp.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("look_up");
			}
		}
	}
	
	public override void Execute(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Execute(__owner, __timeDelay);
		Vector2 motion = __owner.Motion;
		Debug.Log("LookUp.Execute() : " + __owner.id + " :  motion y = " + motion.y);
		Sonic sonic;
		if (motion.y == 0f)
		{
			sonic = __owner as Sonic;
			StandStill standstill = new StandStill();
			sonic.StateEngine().ChangeState(standstill, __timeDelay);
			return;
		}
		if (motion.y < 0)
		{
			sonic = __owner as Sonic;
			Crouch crouch = new Crouch();
			sonic.StateEngine().ChangeState(crouch, __timeDelay);
			return;
		}
	}
	
	public override void Exit(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Exit(__owner, __timeDelay);
		Debug.Log("LookUp.Exit() : changing state to still");
		Sonic sonic = __owner as Sonic;
		StandStill standstill = new StandStill();
		sonic.StateEngine().ChangeState(standstill, __timeDelay);
	}
	
//	override protected void UpdateMotion(Entity __owner)
//	{
//		switch (__owner.PlayerControlled)
//		{
//			case true :
//			{
//				float currentVertical = Input.GetAxis("Vertical");
//				Debug.Log("LookUp.Execute : currentVertical = " + currentVertical);
//				Vector2 motion = __owner.Motion;
//				motion.y += currentVertical;
//				if (currentVertical == 0f)
//				{
//					motion.y = 0;
//				}
//				else
//				{
//					switch (motion.y > 0)
//					{
//						case true :
//							if (motion.y > maximumVertical) motion.y = maximumVertical;
//							break;
//						case false :
//							if (motion.y < -maximumVertical) motion.y = -maximumVertical;
//							break;
//					}
//				}
//				__owner.Motion = motion;
//				break;
//			}
//			case false :
//			{
//				//do nothing for now
//				break;
//			}
//		}
//	}
}
