using System;

namespace Common
{
	public delegate void OpenEventHandler(string info);	

	public interface IOpentEvent
	{
		event OpenEventHandler OpenEvent;
		void ExcuteEvent(string info);
	}
}
