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
    using MeleeAutomator.Helpers;
    using MeleeAutomator.Characters;
    using MeleeAutomator.VSMode.Tournament;

    public partial class Tester : Form {
        StartMenu startMenu;
        DolphinAsyncController controller;
        MenuSelector menuSelector;
        MeleeStates states;
        MeleeCursor cursor;
        CharactersManager manager;

        public Tester() {
            InitializeComponent();
            controller = new DolphinAsyncController(new vJoyController(1));
            startMenu = new StartMenu(controller);
            states = startMenu.getMeleeStates();
            menuSelector = states.getMenuSelector();
            cursor = new MeleeCursor(controller);
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
                Console.WriteLine("Found " + character.name);
            }
        }

        private async void setTournamentPlayers_Click(object sender, EventArgs e) {
            await new TournamentPlayers(states, states.getTournamentMenu(), 24).confirm();
        }

        private async void meleeModeButton_Click(object sender, EventArgs e) {
            await menuSelector.meleeMode();
        }

        private async void button1_Click(object sender, EventArgs e) {
            await cursor.getTo(manager.getCharacter("Roy"));
            await cursor.getTo(manager.getCharacter("DrMario"));
            await cursor.getTo(manager.getCharacter("DK"));
        }

        private async void quickButtonLeft_Click(object sender, EventArgs e) {
            await cursor.calibrate();
        }
    }
}
