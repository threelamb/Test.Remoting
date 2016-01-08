using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters;

namespace Common
{
    public class OpenEventWrapper : MarshalByRefObject
    {
        public event OpenEventHandler EventHandlerA;
        public event OpenEventHandler EventHandlerB;

        public void InvokeEventHandlerA(string message)
        {
            if (EventHandlerA != null)
            {
                EventHandlerA(message);
            }
        }

        public void InvokeEventHandlerB(string message)
        {
            if (EventHandlerB != null)
            {
                EventHandlerB(message);
            }
        }

        public OpenEventWrapper()
        {
            IChannel channel;
            IOpentEvent openEvent = null;
            IDictionary props;
            BinaryServerFormatterSinkProvider serverProvider;
            BinaryClientFormatterSinkProvider clientProvider;

            serverProvider = new BinaryServerFormatterSinkProvider();
            clientProvider = new BinaryClientFormatterSinkProvider();
            serverProvider.TypeFilterLevel = TypeFilterLevel.Full;
            props = new Hashtable();
            props["port"] = 0;
            channel = new HttpChannel(props, clientProvider, serverProvider);
            ChannelServices.RegisterChannel(channel);

            openEvent = (IOpentEvent)Activator.GetObject(
                typeof(IOpentEvent), "http://localhost:8080/" + "OpenEventA");
            openEvent.OpenEvent += new OpenEventHandler(this.InvokeEventHandlerA);

            openEvent = (IOpentEvent)Activator.GetObject(
                typeof(IOpentEvent), "http://localhost:8080/" + "OpenEventB");
            openEvent.OpenEvent += new OpenEventHandler(this.InvokeEventHandlerB);


        }

        public static void RegistChannel()
        {
            IChannel channel;
            IDictionary props;
            BinaryServerFormatterSinkProvider serverProvider;
            BinaryClientFormatterSinkProvider clientProvider;

            serverProvider = new BinaryServerFormatterSinkProvider();
            clientProvider = new BinaryClientFormatterSinkProvider();
            serverProvider.TypeFilterLevel = TypeFilterLevel.Full;
            props = new Hashtable();
            props["port"] = 8080;
            channel = new HttpChannel(props, clientProvider, serverProvider);
            ChannelServices.RegisterChannel(channel);
        }

        public static void SetRemotingObj<T>(T Obj)
            where T : MarshalByRefObject
        {
            string uri = typeof(T).Name;
            RemotingServices.Marshal(Obj, uri);
        }
    }
}
