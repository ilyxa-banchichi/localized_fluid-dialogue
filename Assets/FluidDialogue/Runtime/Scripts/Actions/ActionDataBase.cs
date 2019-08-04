using System;
using UnityEngine;

namespace CleverCrow.Fluid.Dialogues.Actions {
    public abstract class ActionDataBase : ScriptableObject, IGetRuntime<IAction> {
        [SerializeField]
        private string _title;

        [SerializeField]
        private string _uniqueId;

        protected virtual void OnInit (IDialogueController dialogue) {}

        protected virtual void OnStart () {}

        protected virtual ActionStatus OnUpdate () {
            return ActionStatus.Success;
        }

        protected virtual void OnExit () {}

        protected virtual void OnReset () {}

        public string UniqueId => _uniqueId;

        public void Setup () {
            if (string.IsNullOrEmpty(_title)) {
                _title = GetType().Name;
            }

            name = GetType().Name;
            _uniqueId = Guid.NewGuid().ToString();
        }

        public IAction GetRuntime (IDialogueController dialogue) {
            var copy = Instantiate(this);
            return new ActionRuntime(dialogue, _uniqueId) {
                OnInit = copy.OnInit,
                OnStart = copy.OnStart,
                OnUpdate = copy.OnUpdate,
                OnExit = copy.OnExit,
                OnReset = copy.OnReset,
            };
        }
    }
}
