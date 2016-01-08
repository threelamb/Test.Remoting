using System;
using System.Runtime.Remoting.Messaging;
using Wayfarer.BroadCast.Common;

namespace Wayfarer.BroadCast.RemoteObject
{
	/// <summary>
	/// Class1 ��ժҪ˵����
	/// </summary>
	public class BroadCastObj:MarshalByRefObject,IBroadCast
	{	
		public event BroadCastEventHandler BroadCastEvent;

		#region IBroadCast ��Ա

		//[OneWay]
		public void BroadCastingInfo(string info)
		{
			if (BroadCastEvent != null)
			{
				BroadCastEvent(info);
			}
		}

		#endregion

		public override object InitializeLifetimeService()
		{
			return null;
		}

	}
}
