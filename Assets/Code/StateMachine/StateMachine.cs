using System;
using System.Collections.Generic;

namespace Code.StateMachine
{
    public class StateMachine
    {
        private StateNode _currentStateNode;
        private Dictionary<Type, StateNode> _nodes = new();
        private HashSet<ITransition> _anyTransitions = new();
        
        public void Update() {
            var transition = GetTransition();
            if (transition != null) 
                ChangeState(transition.To);
            
            _currentStateNode.State?.Update();
        }
        
        public void FixedUpdate() {
            _currentStateNode.State?.FixedUpdate();
        }

        public void SetState(IState state) {
            _currentStateNode = _nodes[state.GetType()];
            _currentStateNode.State?.OnEnter();
        }

        void ChangeState(IState state) {
            if (state == _currentStateNode.State) return;
            
            var previousState = _currentStateNode.State;
            var nextState = _nodes[state.GetType()].State;
            
            previousState?.OnExit();
            nextState?.OnEnter();
            _currentStateNode = _nodes[state.GetType()];
        }

        ITransition GetTransition() {
            foreach (var transition in _anyTransitions)
                if (transition.Condition.Evaluate())
                    return transition;
            
            foreach (var transition in _currentStateNode.Transitions)
                if (transition.Condition.Evaluate())
                    return transition;
            
            return null;
        }

        public void AddTransition(IState from, IState to, IPredicate condition) {
            GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
        }
        
        public void AddAnyTransition(IState to, IPredicate condition) {
            _anyTransitions.Add(new Transition(GetOrAddNode(to).State, condition));
        }

        StateNode GetOrAddNode(IState state) {
            var node = _nodes.GetValueOrDefault(state.GetType());
            
            if (node == null) {
                node = new StateNode(state);
                _nodes.Add(state.GetType(), node);
            }
            
            return node;
        }
        
        class StateNode
        {
            public IState State { get; }
            public HashSet<ITransition> Transitions { get; }

            public StateNode(IState state)
            {
                State = state;
                Transitions = new HashSet<ITransition>();
            }
            
            public void AddTransition(IState to, IPredicate condition)
            {
                Transitions.Add(new Transition(to, condition));
            }
        }

        
    }
}