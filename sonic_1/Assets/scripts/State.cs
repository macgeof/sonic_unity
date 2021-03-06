using System;
using UnityEngine;

public class State
{
	protected float timeInState = 0.0f;
	protected float minimumTimeInState = 0.0f;
	protected float horizontalDecay = 0f;
	protected float minimumHorizontal = 0f;
	protected float maximumHorizontal = 0f;
	protected float minimumVertical = 0f;
	protected float maximumVertical = 0f;
	
	public float MinimumHorizontal
	{
		get { return minimumHorizontal; }
		set { minimumHorizontal = value; }
	}
	
	public float MaximumHorizontal
	{
		get { return maximumHorizontal; }
		set { maximumHorizontal = value; }
	}
	
	public float MinimumVertical
	{
		get { return minimumVertical; }
		set { minimumVertical = value; }
	}
	
	public float MaximumVertical
	{
		get { return maximumVertical; }
		set { maximumVertical = value; }
	}
	
	public float HorizontalDecay
	{
		get { return horizontalDecay; }
		set { horizontalDecay = value; }
	}
	
	public System.Random probability = new System.Random();
	
	public State ()
	{
	}
	
	public virtual void Enter(Entity __owner, float __timeDelay = 0.0f)
	{
		timeInState += __timeDelay;
	}
	
	public virtual void Execute(Entity __owner, float __timeDelay = 0.0f)
	{
		timeInState += __timeDelay;
		UpdateMotion(__owner);
	}
	
	public virtual void Exit(Entity __owner, float __timeDelay = 0.0f)
	{
		timeInState += __timeDelay;
	}
	
	protected virtual void UpdateMotion(Entity __owner)
	{
		switch (__owner.PlayerControlled)
		{
			case true :
			{
				float currentHorizontal = Input.GetAxis("Horizontal");
				float currentVertical = Input.GetAxis("Vertical");
				Vector2 motion = __owner.Motion;
				motion.x += currentHorizontal;
				if (currentHorizontal == 0f)
				{
					switch (motion.x > 0)
					{
						case true :
							if (motion.x > maximumHorizontal) motion.x = maximumHorizontal;
							motion.x *= horizontalDecay;
							if (motion.x < 0) motion.x = 0;
							break;
						case false :
							if (motion.x < -maximumHorizontal) motion.x = -maximumHorizontal;
							motion.x *= horizontalDecay;
							if (motion.x > 0) motion.x = 0;
							break;
					}
				}
				motion.y += currentVertical;
//				switch (motion.y > 0f)
//				{
//					case true :
//						motion.y = 0f;
//						break;
//					case false :
//						if (motion.y < -maximumVertical) motion.y = -maximumVertical;
//						break;
//				}
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

