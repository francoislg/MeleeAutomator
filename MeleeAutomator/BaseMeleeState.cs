
namespace MeleeAutomator {
    using DolphinControllerAutomator;
    using System.Threading.Tasks;

    public class BaseMeleeState<State> : MeleeState where State : MeleeState  {
        protected MeleeStates states;
        protected DolphinAsyncController mainController;
        private State backState;

        public BaseMeleeState(MeleeStates states, State backState) {
            this.states = states;
            this.backState = backState;
            this.mainController = states.mainController;
        }

        public virtual void reset() {}

        public async Task<State> back() {
            await mainController.press(DolphinButton.B).execute();
            backState.reset();
            return backState;
        } 
    }
}