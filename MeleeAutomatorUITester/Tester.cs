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
    using System.Threading.Tasks;
    using System.Diagnostics;

    public partial class Tester : Form {
        StartMenu startMenu;
        DolphinAsyncController mainController;
        DolphinAsyncController[] controllers;
        MenuSelector menuSelector;
        MeleeStates states;
        MeleePortrait[] portraits;
        CharactersManager manager;

        public Tester() {
            InitializeComponent();
            controllers = new DolphinAsyncController[] {
                new DolphinAsyncController(new vJoyController(1)),
                new DolphinAsyncController(new vJoyController(2))
            };
            mainController = controllers[0];
            startMenu = new StartMenu(mainController);
            states = startMenu.getMeleeStates();
            menuSelector = states.getMenuSelector();
            portraits = new MeleePortrait[] {
                new MeleePortrait(new MeleeCharacterCursor(controllers[0], 1)),
                new MeleePortrait(new MeleeCharacterCursor(controllers[1], 2))
            };
                
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
            for (int i = 0; i < 60; i++) {
                Character character = manager.getRandomCharacter();
                Console.WriteLine(character);
                await Task.WhenAll(
                    portraits[0].getTo(character),
                    portraits[1].getTo(character)
                );
            }
        }

        private async void quickButtonLeft_Click(object sender, EventArgs e) {
            await Task.WhenAll(
                portraits[0].forceCalibration(),
                portraits[1].forceCalibration()
            );
        }

        private async void button1_Click_1(object sender, EventArgs e) {
            await portraits[0].changeToCPU();
            await portraits[1].changeToCPU();
            await portraits[0].changeToLevel(9);
            await portraits[1].changeToLevel(9);
        }

        private async void toStageButton_Click(object sender, EventArgs e) {
            await Task.WhenAll(
                portraits[0].forceCalibration(),
                portraits[1].forceCalibration()
            );
            await Task.WhenAll(
                portraits[0].changeToCPU(),
                portraits[1].changeToCPU()
            );
            await Task.WhenAll(
                portraits[0].changeToLevel(9),
                portraits[1].changeToLevel(9)
            );
            Character character1 = manager.getRandomCharacter();
            Character character2 = manager.getRandomCharacter();
            await Task.WhenAll(
                portraits[0].getTo(character1),
                portraits[1].getTo(character2)
            );
            await mainController.press(DolphinButton.START).execute();
        }
    }
}
