using CleverCrow.Fluid.Dialogues.Nodes;

namespace CleverCrow.Fluid.Dialogues.Conditions {
    public abstract class ConditionDataBase : NodeNestedDataBase<ICondition>, IConditionData {
        public virtual void OnInit (IDialogueController dialogue) {}
        public abstract bool OnGetIsValid ();

        public override ICondition GetRuntime (IDialogueController dialogue) {
            return new ConditionRuntime(dialogue, _uniqueId, Instantiate(this));
        }
    }
}
