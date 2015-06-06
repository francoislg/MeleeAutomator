using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MeleeAutomator;
using DolphinControllerAutomator;
using DolphinControllerAutomator.Controllers;

namespace MeleeAutomatorUITester {
    using MeleeAutomator.Cursors;
    using MeleeAutomator.Characters;
    using MeleeAutomator.VSMode.Tournament;
    using System.Threading.Tasks;
    using System.Diagnostics;

    public partial class Tester : Form {
        StartMenu startMenu;
        DolphinAsyncController mainController;
        DolphinAsyncController[] controllers;
        MenuSelector menuSelector;
        MeleeStates states;
        CharactersManager manager;
        MeleeStageCursor stageCursor;

        public Tester() {
            InitializeComponent();
            controllers = new DolphinAsyncController[] {
                new DolphinAsyncController(new vJoyController(1)),
                new DolphinAsyncController(new vJoyController(2))
            };
            mainController = controllers[0];
            startMenu = new StartMenu(controllers);
            states = startMenu.meleeStates;
            menuSelector = states.menuSelector;
            
            stageCursor = new MeleeStageCursor(mainController);
            manager = new CharactersManager();
        }

        private async void startMenuButton_click(object sender, EventArgs e) {
            await startMenu.pressStart();
        }

        private async void optionsMenuButton_Click(object sender, EventArgs e) {
            await menuSelector.options();
        }

        private async void tournamentModeButton_Click(object sender, EventArgs e) {
            await menuSelector.tournamentmode();
        }

        private void setUpTournamentButton_Click(object sender, EventArgs e) {
            states.tournamentMenu.setNumberOfEntrants(TournamentMenu.Entrants._24).setCPULevel(TournamentMenu.CPULevel.Level1).confirm();
        }

        private void screenshotTester_Click(object sender, EventArgs e) {
            DolphinWindowCapture windowHelper = new DolphinWindowCapture();
            CharactersImageMatcher charactersImageMatcher = new CharactersImageMatcher(states.characters);
            //windowHelper.focus();
            using (Bitmap bitmap = windowHelper.captureWindow()) {
                bitmap.Save("D:/full.png");
            }
            using (Bitmap bitmap = windowHelper.captureCPUTournamentPortrait()) {
                bitmap.Save("D:/test.png");
                Character character = charactersImageMatcher.findCharacterInTournament(bitmap);
                Console.WriteLine("Found " + character.name);
            }
        }

        private async void setTournamentPlayers_Click(object sender, EventArgs e) {
            await new TournamentPlayers(states, states.tournamentMenu, 24).confirm();
        }

        private async void meleeModeButton_Click(object sender, EventArgs e) {
            await menuSelector.meleeMode();
        }

        private async void toStageButton_Click_1(object sender, EventArgs e) {
            await stageCursor.select(MeleeStageCursor.Stage.DreamLand);
        }
    }
}
