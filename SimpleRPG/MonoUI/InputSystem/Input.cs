using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoUI.InputSystem {
    /// <summary>Allows for checking whether keys or buttons have been pressed</summary>
    public static class Input {
        /// <summary>The number of keys on the keyboard</summary>
        private const int NUM_KEYS = 255;

        /// <summary>The keystate of the keyboard in the previous frame</summary>
        private static KeyState[] previousKeyboardState;
        /// <summary>The state of the keyboard in the current frame</summary>
        private static State[] currentKeyboardState;

        /// <summary>The button state of the left mouse button in the previous frame</summary>
        private static ButtonState previousLeftMouseState;
        /// <summary>The button state of the right mouse button in the previous frame</summary>
        private static ButtonState previousRightMouseState;
        /// <summary>The button state of the middle mouse button in the previous frame</summary>
        private static ButtonState previousMiddleMouseState;
        /// <summary>The value of the scroll wheel in the previous frame</summary>
        private static int previousScrollValue;

        /// <summary>The state of the left mouse button in the current frame</summary>
        private static State currentLeftMouseState;
        /// <summary>The state of the right mouse button in the current frame</summary>
        private static State currentRightMouseState;
        /// <summary>The state of the middle mouse button in the current frame</summary>
        private static State currentMiddleMouseState;
        /// <summary>The value of the scroll wheel in the current frame</summary>
        private static int currentScrollValue;

        /// <summary>Initializes all the input data</summary>
        public static void Initialize() {
            previousKeyboardState = new KeyState[NUM_KEYS];
            currentKeyboardState = new State[NUM_KEYS];

            for (int i = 0; i < NUM_KEYS; i++) {
                currentKeyboardState[i] = State.Up;
                previousKeyboardState[i] = Keyboard.GetState()[(Keys)i];
            }

            previousLeftMouseState = Mouse.GetState().LeftButton;
            previousRightMouseState = Mouse.GetState().RightButton;
            previousMiddleMouseState = Mouse.GetState().MiddleButton;
            previousScrollValue = Mouse.GetState().ScrollWheelValue;

            currentLeftMouseState = State.Up;
            currentRightMouseState = State.Up;
            currentMiddleMouseState = State.Up;
            currentScrollValue = previousScrollValue;
        }

        /// <summary>Updates the input data<para>This should be done first thing during the update</para>
        /// </summary>
        public static void Update() {
            for (int i = 0; i < NUM_KEYS; i++) {
                CheckKey(ref currentKeyboardState[i], ref previousKeyboardState[i], Keyboard.GetState()[(Keys)i]);
            }

            CheckButton(ref currentLeftMouseState, ref previousLeftMouseState, Mouse.GetState().LeftButton);
            CheckButton(ref currentRightMouseState, ref previousRightMouseState, Mouse.GetState().RightButton);
            CheckButton(ref currentMiddleMouseState, ref previousMiddleMouseState, Mouse.GetState().MiddleButton);

            previousScrollValue = currentScrollValue;
            currentScrollValue = Mouse.GetState().ScrollWheelValue;

            Point mouseLocation = Mouse.GetState().Position;

            if (currentLeftMouseState == State.Pressed)
                MouseClickEventHandler(new MouseClickEventArgs(MouseButtons.Left, mouseLocation));

            if (currentRightMouseState == State.Pressed)
                MouseClickEventHandler(new MouseClickEventArgs(MouseButtons.Right, mouseLocation));

            if (currentMiddleMouseState == State.Pressed)
                MouseClickEventHandler(new MouseClickEventArgs(MouseButtons.Middle, mouseLocation));
        }

        /// <summary>Checks the current state of the key against the previous state and updates it</summary>
        /// <param name="currentState">The current state of the key</param>
        /// <param name="previousState">The previous state of the key</param>
        /// <param name="keyboardState">The current key state of the key</param>
        private static void CheckKey(ref State currentState, ref KeyState previousState, KeyState keyboardState) {
            currentState = (previousState, keyboardState) switch
            {
                (KeyState.Up, KeyState.Down) => State.Pressed,
                (KeyState.Down, KeyState.Up) => State.Released,
                (_, _) => State.Up
            };
            previousState = keyboardState;
        }

        /// <summary>Checks the current state of the button against the previous state and updates it</summary>
        /// <param name="currentState">The current state of the button</param>
        /// <param name="previousState">The previous state of the button</param>
        /// <param name="mouseState">The current button state of the button</param>
        private static void CheckButton(ref State currentState, ref ButtonState previousState, ButtonState mouseState) {
            currentState = (previousState, mouseState) switch
            {
                (ButtonState.Released, ButtonState.Pressed) => State.Pressed,
                (ButtonState.Pressed, ButtonState.Released) => State.Released,
                (_, _) => State.Up
            };
            previousState = mouseState;
        }

        /// <summary>Checks whether the key is currently down</summary>
        /// <param name="key">The key to check for</param>
        /// <returns>True if the key is currently pressed</returns>
        public static bool GetKey(Keys key) {
            return Keyboard.GetState().IsKeyDown(key);
        }

        /// <summary>Checks whether the key was pressed this frame</summary>
        /// <param name="key">The key to check for</param>
        /// <returns>True if the key was pressed this frame</returns>
        public static bool GetKeyDown(Keys key) {
            return currentKeyboardState[(int)key] == State.Pressed;
        }

        /// <summary>Checks whether the key was released this frame</summary>
        /// <param name="key">The key to check for</param>
        /// <returns>True if the key was released this frame</returns>
        public static bool GetKeyUp(Keys key) {
            return currentKeyboardState[(int)key] == State.Released;
        }

        /// <summary>Checks whether the button is currently down</summary>
        /// <param name="button">The button to check for</param>
        /// <returns>True if the button is pressed</returns>
        public static bool GetMouseButton(MouseButtons button) {
            return button switch
            {
                MouseButtons.Left => Mouse.GetState().LeftButton == ButtonState.Pressed,
                MouseButtons.Right => Mouse.GetState().RightButton == ButtonState.Pressed,
                MouseButtons.Middle => Mouse.GetState().MiddleButton == ButtonState.Pressed,
                _ => false
            };
        }

        /// <summary>Checks whether the button was pressed this frame</summary>
        /// <param name="button">The button to check for</param>
        /// <returns>True if the button was pressed this frame</returns>
        public static bool GetMouseButtonDown(MouseButtons button) {
            return button switch
            {
                MouseButtons.Left => currentLeftMouseState == State.Pressed,
                MouseButtons.Right => currentRightMouseState == State.Pressed,
                MouseButtons.Middle => currentMiddleMouseState == State.Pressed,
                _ => false
            };
        }

        /// <summary>Checks whether the button was released this frame</summary>
        /// <param name="button">The button to check for</param>
        /// <returns>True if the button was released this frame</returns>
        public static bool GetMouseButtonUp(MouseButtons button) {
            return button switch
            {
                MouseButtons.Left => currentLeftMouseState == State.Released,
                MouseButtons.Right => currentRightMouseState == State.Released,
                MouseButtons.Middle => currentMiddleMouseState == State.Released,
                _ => false
            };
        }

        /// <summary>Checks if the scroll wheel was scrolled this frame</summary>
        /// <returns>True if the scroll wheel was scrolled this frame</returns>
        public static bool Scrolled() {
            return currentScrollValue == previousScrollValue;
        }

        /// <summary>
        /// How much has been scrolled this frame
        /// </summary>
        /// <returns>How much was scrolled this frame</returns>
        public static int ScrollAmount() {
            return currentScrollValue - previousScrollValue;
        }

        public delegate void OnMouseClick(MouseClickEventArgs e);

        public static event OnMouseClick onMouseClick;

        private static void MouseClickEventHandler(MouseClickEventArgs e) {
            onMouseClick?.Invoke(e);
        }
    }
}
