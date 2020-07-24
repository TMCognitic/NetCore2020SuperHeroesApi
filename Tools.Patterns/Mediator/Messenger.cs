using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Patterns.Mediator
{
    public sealed class Messenger<TMessage>
    {
        private static Messenger<TMessage> _instance;
        public static Messenger<TMessage> Instance
        {
            get
            {
                return _instance ?? (_instance = new Messenger<TMessage>());
            }
        }

        private Messenger()
        {
            _boxes = new Dictionary<string, Action<TMessage>>();
        }

        private Action<TMessage> _actions;
        private Dictionary<string, Action<TMessage>> _boxes;

        public void Register(Action<TMessage> action)
        {
            _actions += action;
        }

        public void Register(string box, Action<TMessage> action)
        {
            if (!_boxes.ContainsKey(box))
                _boxes.Add(box, null);

            _boxes[box] += action;
        }

        public void Send(TMessage message)
        {
            _actions?.Invoke(message);
        }

        public void Send(string box, TMessage message)
        {
            if (!_boxes.ContainsKey(box))
                throw new InvalidOperationException("the specified box does not exist!");
            
            _boxes[box]?.Invoke(message);
        }
    }
}
