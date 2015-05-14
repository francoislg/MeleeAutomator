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
    using MeleeAutomator.Characters;
    using MeleeAutomator.VSMode.Tournament;

    public partial class Tester : Form {
        StartMenu startMenu;
        DolphinController controller;
        MenuSelector menuSelector;
        MeleeStates states;

        public Tester() {
            InitializeComponent();
            controller = new vJoyController(1);
            startMenu = new StartMenu(controller);
            states = startMenu.getMeleeStates();
            menuSelector = states.getMenuSelector();
        }

        private void startMenuButton_click(object sender, EventArgs e) {
            startMenu.pressStart();
        }

        private void optionsMenuButton_Click(object sender, EventArgs e) {
            menuSelector.options();
        }

        private void tournamentModeButton_Click(object sender, EventArgs e) {
            menuSelector.tournamentmode();
        }

        private void setUpTournamentButton_Click(object sender, EventArgs e) {
            states.getTournamentMenu().setNumberOfEntrants(TournamentMenu.Entrants._24).setCPULevel(TournamentMenu.CPULevel.Level1).confirm();
        }

        private void screenshotTester_Click(object sender, EventArgs e) {
            DolphinWindowCapture windowHelper = new DolphinWindowCapture();
            CharactersImageMatcher charactersImageMatcher = new CharactersImageMatcher(states.getCharacters());
            //windowHelper.focus();
            using (Bitmap bitmap = windowHelper.captureWindow()) {
                bitmap.Save("D:/full.png");
            }
            using (Bitmap bitmap = windowHelper.captureCPUTournamentPortrait()) {
                bitmap.Save("D:/test.png");
                Character character = charactersImageMatcher.findCharacterInTournament(bitmap);
                Console.WriteLine("Found " + character.getName());
            }
        }

        private void setTournamentPlayers_Click(object sender, EventArgs e) {
            new TournamentPlayers(states, states.getTournamentMenu(), 24).confirm();
        }

        private void meleeModeButton_Click(object sender, EventArgs e) {
            menuSelector.meleeMode();
        }
    }
}
