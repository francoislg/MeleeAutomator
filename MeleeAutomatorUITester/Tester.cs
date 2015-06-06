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
    using MeleeAutomator.Stages;
    using MeleeAutomator.VSMode.Tournament;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using MeleeAutomator.VSMode.Melee;

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
                bitmap.Save("D:/test/full.png");
            }
            MatchImageMatcher matcher = new MatchImageMatcher();
            List<Bitmap> test = windowHelper.test(2);
            int count = 0;
            foreach (Bitmap bitmap in test) {
                count++;
                bitmap.Save("D:/test/" + count + ".png");
                Console.WriteLine(count + " - found : " + matcher.playerWon(bitmap));
            }
   /*
            using (Bitmap bitmap = windowHelper.captureWinningRibbon(2)) {
                bitmap.Save("D:/test.png");
                MatchImageMatcher matcher = new MatchImageMatcher();
                Console.WriteLine("found : " + matcher.playerWon(bitmap));
            }*/
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
            ActiveDuelMatch duel = await states.meleeMenu
                .setPlayerOnPort(new MeleePlayer(manager.getRandomCharacter(), "1"), 1)
                .setPlayerOnPort(new MeleePlayer(manager.getRandomCharacter(), "2"), 2)
                .setStage(Stage.DreamLand)
                .confirm();
            await duel.finish();
        }
    }
}
