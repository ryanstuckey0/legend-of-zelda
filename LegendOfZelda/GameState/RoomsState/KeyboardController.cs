﻿using LegendOfZelda.GameState.Command;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Rooms
{
    internal class KeyboardController : IController
    {
        private readonly Dictionary<Keys, ICommand> controllerMappings;
        private List<Keys> oldKbState;
        private List<Keys> repeatableKeys;

        public KeyboardController(IGameState gameState)
        {
            RoomGameState gameStateCast = (RoomGameState)gameState;
            oldKbState = new List<Keys>();
            InitRepeatableKeys();
            controllerMappings = new Dictionary<Keys, ICommand>();

            RegisterCommand(Keys.Escape, new PauseGameCommand(gameState));
            RegisterCommand(Keys.Q, new QuitGameCommand(gameState));

            // Register Player 1 Commands
            RegisterCommand(Keys.W, new WalkingForwardCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.Up, new WalkingForwardCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.A, new WalkingLeftCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.Left, new WalkingLeftCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.D, new WalkingRightCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.Right, new WalkingRightCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.S, new WalkingDownCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.Down, new WalkingDownCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.Z, new SwordAttackCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.N, new SwordAttackCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.E, new DamageLinkCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.D4, new UseBowCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.D8, new UseSwordBeamCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.D6, new UseBoomerangCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.D7, new UseBombCommand(gameStateCast.GetPlayer(0)));
        }

        public GameStateConstants.InputType GetInputType()
        {
            return GameStateConstants.InputType.Keyboard;
        }

        public OldInputState GetOldInputState()
        {
            return new OldInputState { oldKeyboardState = oldKbState };
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void SetOldInputState(OldInputState oldInputState)
        {
            oldKbState = oldInputState.oldKeyboardState;
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            bool changedKbState = false;

            foreach (Keys key in pressedKeys)
            {
                changedKbState = true;
                bool inOldKbState = oldKbState.Contains(key);
                if (inOldKbState) oldKbState.Remove(key);
                if (!repeatableKeys.Contains(key)) oldKbState.Add(key);
                if (controllerMappings.ContainsKey(key) && !inOldKbState)
                {
                    controllerMappings[key].Execute();
                }
            }
            if (!changedKbState) oldKbState = new List<Keys>();
        }

        private void InitRepeatableKeys()
        {
            repeatableKeys = new List<Keys>()
            {
                { Keys.W },
                { Keys.S },
                { Keys.A },
                { Keys.D },
                { Keys.Up },
                { Keys.Left },
                { Keys.Down },
                { Keys.Right }
            };
        }
    }
}
