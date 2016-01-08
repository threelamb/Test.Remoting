using System;
using System.Runtime.Remoting.Messaging;
using Common;

namespace RemoteObject
{
    /// <summary>
    /// ��Ҫ�������¼�����
    /// </summary>
    public class OpenEventA : MarshalByRefObject, IOpentEvent
    {
        public event OpenEventHandler OpenEvent;

        #region IBroadCast ��Ա

        public void ExcuteEvent(string info)
        {
            if (OpenEvent != null)
            {
                OpenEvent(info);
            }
        }

        #endregion

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }

    /// <summary>
    /// ��Ҫ�������¼�����
    /// </summary>
    public class OpenEventB : MarshalByRefObject, IOpentEvent
    {
        public event OpenEventHandler OpenEvent;

        #region IBroadCast ��Ա

        public void ExcuteEvent(string info)
        {
            if (OpenEvent != null)
            {
                OpenEvent(info);
            }
        }

        #endregion

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
