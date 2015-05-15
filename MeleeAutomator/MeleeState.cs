
namespace MeleeAutomator {
    using DolphinControllerAutomator;
    using System.Threading.Tasks;

    public class MeleeState<State> {
        protected MeleeStates states;
        protected DolphinAsyncController controller;
        private State backState;

        public MeleeState(MeleeStates states, State backState) {
            this.states = states;
            this.backState = backState;
            this.controller = states.getController();
        }

        public async Task<State> back() {
            await controller.press(DolphinButton.B).execute();
            return backState;
        } 
    }
}