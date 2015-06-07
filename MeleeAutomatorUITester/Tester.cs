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
    using MeleeAutomator.Images;
    using MeleeAutomator.Menus;
    using MeleeAutomator.StateEngine;
    using MeleeAutomator.Cursors;
    using MeleeAutomator.Characters;
    using MeleeAutomator.Stages;
    using MeleeAutomator.Menus.VSMode.Tournament;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using MeleeAutomator.Menus.VSMode.Melee;

    public partial class Tester : Form {
        MeleeBoot startMenu;
        DolphinAsyncController mainController;
        DolphinAsyncController[] controllers;
        MenuSelector menuSelector;
        MeleeStates states;
        CharactersManager manager;
        MeleeStageCursor stageCursor;
        DolphinWindowCapture dolphinCapturer;

        public Tester() {
            InitializeComponent();
            controllers = new DolphinAsyncController[] {
                new DolphinAsyncController(new vJoyController(1)),
                new DolphinAsyncController(new vJoyController(2))
            }; 
            dolphinCapturer = new DolphinWindowCapture();
            mainController = controllers[0];
            startMenu = new MeleeBoot(controllers);
            states = startMenu.meleeStates;
            menuSelector = states.menuSelector;
            
            stageCursor = new MeleeStageCursor(mainController);
            manager = new CharactersManager();
            autoUpdateToggle.Checked = true;
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
            CharactersImageMatcher charactersImageMatcher = new CharactersImageMatcher(states.characters);
            //windowHelper.focus();
            using (Bitmap bitmap = dolphinCapturer.captureWindow()) {
                bitmap.Save("D:/test/full.png");
            }
            MatchImageMatcher matcher = new MatchImageMatcher();
            using (Bitmap bitmap = dolphinCapturer.captureWinningRibbon(2)) {
                bitmap.Save("D:/test.png");
                Console.WriteLine("found : " + matcher.playerWon(bitmap));
            }
        }

        private async void setTournamentPlayers_Click(object sender, EventArgs e) {
            await new TournamentPlayers(states, states.tournamentMenu, 24).confirm();
        }

        private async void meleeModeButton_Click(object sender, EventArgs e) {
            await menuSelector.meleeMode();
        }

        private async void toStageButton_Click_1(object sender, EventArgs e) {
            await stageCursor.select(Stage.DreamLand);
        }

        private async void selectCharButton_Click(object sender, EventArgs e) {
            FinishedDuelMatch duel = await states.meleeMenu
                .setPlayerOnPort(new MeleePlayer(manager.getRandomCharacter(), "1"), 1)
                .setPlayerOnPort(new MeleePlayer(manager.getRandomCharacter(), "2"), 2)
                .setStage(Stage.DreamLand)
                .confirm();
            Console.WriteLine("Winner is : " + duel.winner);
        }

        private void updatePictureBoxTimer_Tick(object sender, EventArgs e) {
            currentlySeen.Image = dolphinCapturer.captureWindow();
            seenGame.Image = dolphinCapturer.captureEndOfMatchWindow();
            seenRibbon1.Image = dolphinCapturer.captureWinningRibbon(1);
            seenRibbon2.Image = dolphinCapturer.captureWinningRibbon(2);
        }

        private void autoUpdateToggle_CheckedChanged(object sender, EventArgs e) {
            if (updatePictureBoxTimer.Enabled) {
                updatePictureBoxTimer.Stop();
            } else {
                updatePictureBoxTimer.Start();
            }
        }
    }
}
