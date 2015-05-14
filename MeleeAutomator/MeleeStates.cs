
namespace MeleeAutomator {
    using DolphinControllerAutomator;
    using MeleeAutomator.VSMode;
    using MeleeAutomator.VSMode.Tournament;
    using MeleeAutomator.Options;
    using MeleeAutomator.Characters;
    using MeleeAutomator.VSMode.Melee;

    public class MeleeStates {
        private MenuSelector menuSelector;
        private StartMenu startMenu;
        private VSMenu vsMenu;
        private MeleeMenu meleeMenu;
        private TournamentMenu tournamentMenu;
        private DolphinController controller;
        private OptionsMenu optionsMenu;
        private CharactersManager characters;
        private DolphinWindowCapture dolphinWindowCapture;
        private CharactersImageMatcher imageMatcher;

        public MeleeStates(StartMenu startMenu, DolphinController controller) {
            this.startMenu = startMenu;
            this.controller = controller;
            this.menuSelector = new MenuSelector(this, startMenu);
            this.optionsMenu = new OptionsMenu(this, menuSelector);
            this.vsMenu = new VSMenu(this, menuSelector);
            this.meleeMenu = new MeleeMenu(this, vsMenu);
            this.tournamentMenu = new TournamentMenu(this, vsMenu);
            this.characters = new CharactersManager();
            this.dolphinWindowCapture = new DolphinWindowCapture();
            this.imageMatcher = new CharactersImageMatcher(characters);
        }

        public DolphinController getController() {
            return controller;
        }

        public TournamentMenu getTournamentMenu(){
            return tournamentMenu;
        }

        public OptionsMenu getOptionsMenu() {
            return optionsMenu;
        }

        public VSMenu getVSMenu() {
            vsMenu.resetCursor();
            return vsMenu;
        }

        public MenuSelector getMenuSelector() {
            return menuSelector;
        }

        public CharactersManager getCharacters() {
            return characters;
        }

        public DolphinWindowCapture getWindowCapture() {
            return dolphinWindowCapture;
        }

        public CharactersImageMatcher getCharactersImageMatcher() {
            return imageMatcher;
        }

        internal MeleeMenu getMeleeMenu() {
            return meleeMenu;
        }
    }
}
