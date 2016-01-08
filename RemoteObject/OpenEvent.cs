using System;
using System.Runtime.Remoting.Messaging;
using Common;

namespace RemoteObject
{
    /// <summary>
    /// 需要公开的事件容器
    /// </summary>
    public class OpenEventA : MarshalByRefObject, IOpentEvent
    {
        public event OpenEventHandler OpenEvent;

        #region IBroadCast 成员

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
    /// 需要公开的事件容器
    /// </summary>
    public class OpenEventB : MarshalByRefObject, IOpentEvent
    {
        public event OpenEventHandler OpenEvent;

        #region IBroadCast 成员

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
