using System;
using System.Collections.Generic;

public class MessageDispatcher
{
	private static bool ALLOW_INSTANTIATION = false;
	private static MessageDispatcher INSTANCE = null;
	private static readonly object padlock = new object();
	
	List<Telegram> priorityQueue;
	
	MessageDispatcher()
	{
		if (ALLOW_INSTANTIATION)
		{
			priorityQueue = new List<Telegram>();
		}
		else
		{
			throw new System.Exception("Singleton : access via getInstance");
		}
	}
	
	public static MessageDispatcher getInstance()
	{
		lock(padlock)
		{
			if (INSTANCE == null)
			{
				ALLOW_INSTANTIATION = true;
				INSTANCE = new MessageDispatcher();
				ALLOW_INSTANTIATION = false;
			}
			return INSTANCE;
		}
	}
	
	public void DispatchMessage(double delay,
		string sender,
		string receiver,
		string message,
		object extraInfo)
	{
		
	}
	
	private void Discharge(Entity __receiver, Telegram __message)
	{
	}
}
