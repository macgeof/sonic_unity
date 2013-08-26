using UnityEngine;
using System.Collections;

public class Telegram
{
	//the entity that sent this telegram
	int          Sender;

	//the entity that is to receive this telegram
	int          Receiver;

	//the message itself. These are all enumerated in the file
	//"MessageTypes.h"
	int          Msg;

	//messages can be dispatched immediately or delayed for a specified amount
	//of time. If a delay is necessary this field is stamped with the time 
	//the message should be dispatched.
	double       DispatchTime;
	
	//any additional information that may accompany the message
	IEnumerable       ExtraInfo;
	
	public Telegram(double time,
           int    sender,
           int    receiver,
           int    msg,
           IEnumerable  info = null)
	{
		DispatchTime = time;
		Sender = sender;
		Receiver = receiver;
		Msg = msg;
		ExtraInfo = info;
	}
}
