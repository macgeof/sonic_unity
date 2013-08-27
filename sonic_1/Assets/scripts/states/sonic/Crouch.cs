using UnityEngine;
using System.Collections;
using System;

public class Crouch : State
{

	public Crouch()
	{
		minimumHorizontal = 0f;
		maximumHorizontal = 0f;
		minimumVertical = 0.01f;
		maximumVertical = 1.1f;
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
				Debug.Log("Crouch.Enter() : " + __owner.id + " : " + __owner.name);
				animatingSprite.Play("crouch");
			}
		}
	}
	
	public override void Execute(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Execute(__owner, __timeDelay);
		Vector2 motion = __owner.Motion;
		Debug.Log("Crouch.Execute() : " + __owner.id + " :  motion y = " + motion.y);
		Sonic sonic;
		if (motion.y == 0f)
		{
			sonic = __owner as Sonic;
			StandStill standstill = new StandStill();
			sonic.StateEngine().ChangeState(standstill, __timeDelay);
			return;
		}
//		if (motion.y > 0)
//		{
//			sonic = __owner as Sonic;
//			LookUp lookup = new LookUp();
//			sonic.StateEngine().ChangeState(lookup, __timeDelay);
//			return;
//		}
	}
	
	public override void Exit(Entity __owner, float __timeDelay = 0.0f)
	{
		base.Exit(__owner, __timeDelay);
		Debug.Log("Crouch.Exit() : changing state to still");
	}
	
	override protected void UpdateMotion(Entity __owner)
	{
		base.UpdateMotion(__owner);
		switch (__owner.PlayerControlled)
		{
			case true :
			{
				float currentVertical = Input.GetAxis("Vertical");
				Vector2 motion = __owner.Motion;
				if (currentVertical == 0f)
				{
					motion.y = 0f;
				}
				switch (motion.y > -minimumVertical)
				{
					case true :
						motion.y = 0f;
						break;
					case false :
						if (motion.y < -maximumVertical) motion.y = -maximumVertical;
						break;
				}
				__owner.Motion = motion;
				break;
			}
			case false :
			{
				//do nothing for now
				break;
			}
		}
	}
}
