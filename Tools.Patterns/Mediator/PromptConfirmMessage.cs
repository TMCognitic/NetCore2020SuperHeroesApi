using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Patterns.Mediator
{
    public class PromptConfirmMessage
    {
        public string Message { get; private set; }
        public string Caption { get; private set; }
        public bool Result { get; set; }

        public PromptConfirmMessage(string message, string caption)
        {
            Message = message;
            Caption = caption;
        }
    }
}
