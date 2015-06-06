
namespace MeleeAutomator {
    using DolphinControllerAutomator;
    using System.Threading.Tasks;

    public class BaseMeleeState<State> : MeleeState where State : MeleeState  {
        protected MeleeStates states;
        protected DolphinAsyncController controller;
        private State backState;

        public BaseMeleeState(MeleeStates states, State backState) {
            this.states = states;
            this.backState = backState;
            this.controller = states.mainController;
        }

        public virtual void reset() {}

        public async Task<State> back() {
            await controller.press(DolphinButton.B).execute();
            backState.reset();
            return backState;
        } 
    }
}