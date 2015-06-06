
namespace MeleeAutomator {
    using DolphinControllerAutomator;
    using MeleeAutomator.VSMode;
    using MeleeAutomator.VSMode.Tournament;
    using MeleeAutomator.Options;
    using MeleeAutomator.Characters;
    using MeleeAutomator.VSMode.Melee;

    public class MeleeStates {
        public MenuSelector menuSelector { get; private set; }
        public StartMenu startMenu { get; private set; }
        public VSMenu vsMenu { get; private set; }
        public MeleeMenu meleeMenu { get; private set; }
        public TournamentMenu tournamentMenu { get; private set; }
        public DolphinAsyncController mainController { get; private set; }
        public DolphinAsyncController[] controllers { get; private set; }
        public OptionsMenu optionsMenu { get; private set; }
        public CharactersManager characters { get; private set; }
        public DolphinWindowCapture dolphinWindowCapturer { get; private set; }
        public CharactersImageMatcher imageMatcher { get; private set; }

        public MeleeStates(StartMenu startMenu, DolphinAsyncController[] controllers) {
            this.characters = new CharactersManager();
            this.dolphinWindowCapturer = new DolphinWindowCapture();
            this.imageMatcher = new CharactersImageMatcher(characters);
            this.startMenu = startMenu;
            this.controllers = controllers;
            this.mainController = controllers[0];
            this.menuSelector = new MenuSelector(this, startMenu);
            this.optionsMenu = new OptionsMenu(this, menuSelector);
            this.vsMenu = new VSMenu(this, menuSelector);
            this.meleeMenu = new MeleeMenu(this, vsMenu);
            this.tournamentMenu = new TournamentMenu(this, vsMenu);
        }
    }
}
