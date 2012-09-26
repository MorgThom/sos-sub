using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoboSub.RemoteControl;
using RoboSub.Internal_Model;

namespace RoboSub.MessageControl {
    class MessagePassthrough : IInputListener, IInternalConditionListener {

        public MessagePassthrough(IInputGatherer remote, IInternalConditionGatherer condition) {
            remote.RegisterListener(this);
            condition.RegisterListener(this);
        }

        #region IInternalConditionListener Members

        public void Notify() {
        }

        #endregion



        #region IInputListener Members

        public void InputNotify(sbyte[] message) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
