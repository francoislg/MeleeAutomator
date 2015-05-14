
namespace MeleeAutomator {
    using DolphinControllerAutomator;

    public class MeleeState<State> {
        protected MeleeStates states;
        protected DolphinController controller;
        private State backState;

        public MeleeState(MeleeStates states, State backState) {
            this.states = states;
            this.backState = backState;
            this.controller = states.getController();
        }

        public State back() {
            controller.press(DolphinButton.B);
            return backState;
        } 
    }
}