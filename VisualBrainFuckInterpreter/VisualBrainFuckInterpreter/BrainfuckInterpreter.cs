using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DaanLib;

namespace VisualBrainFuckInterpreter {
    /// <summary>
    /// A visual brainfuck interpreter
    /// </summary>
    public partial class BrainfuckInterpreter : Form {
        Interpreter interpreter;

        /// <summary>
        /// Instantiates a new Brainfuck Interpreter
        /// </summary>
        public BrainfuckInterpreter() {
            InitializeComponent();

            interpreter = new Interpreter();
        }

        /// <summary>
        /// Puts text and a bottom line on the banner
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The Paint Event Args of the event</param>
        private void bannerPanel_Paint(object sender, PaintEventArgs e) {
            // Make sure the sender is a Panel, and cast it
            if (!(sender is Panel banner))
                return;

            // Measure the size of the text
            SizeF textSize = e.Graphics.MeasureString(Text, banner.Font);

            // Calculate the location, so it is centered based on height
            PointF textLocation = new PointF(5, (banner.Height - textSize.Height) / 2);

            // Draw the string to the banner
            e.Graphics.DrawString(Text, banner.Font, Brushes.White, textLocation);

            // Draw a line under the banner
            e.Graphics.DrawLine(Pens.White, banner.Location.X, banner.Height - 1, banner.Location.X + banner.Width, banner.Height - 1);
        }

        /// <summary>
        /// Allows the user to close the form
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The Event Args of the event</param>
        private void closeButton_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// Allows the user to draw the form, as we do not have a border
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The Mouse Event Args of the event</param>
        private void bannerPanel_MouseDown(object sender, MouseEventArgs e) {
            // We only drag when the user presses the left mouse button
            if (e.Button == MouseButtons.Left)
                NativeMethods.HandleWindowDrag(Handle);
        }

        /// <summary>
        /// Reacts to the user pressing a key
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The Key Press Event Args of the event</param>
        private void programTextbox_KeyPress(object sender, KeyPressEventArgs e) {
            // Make sure the sender is a Rich Textbox and cast it
            if (!(sender is RichTextBox textBox))
                return;

            // If the key pressed was the opening bracket, we want to add some stuff to the text
            if(e.KeyChar == '[') {
                // Get the position of the cursor in the window (the text cursor, not mouse cursor)
                int curserPos = textBox.SelectionStart;

                // Check whether there are too many closing brackets (when the loop offset is less than 0)
                // And whether there are any closing brackets after the current index
                if (interpreter.GetLoopOffset() < 0 && HasCharAfterIndex(']', curserPos, textBox.Text)) {
                    // If that is the case, we just want to add the bracket, so there is nothing to do for us
                    return;
                }

                // Else, we want to also add a closing bracket, as we are creating a loop and that needs both characters
                // Get the text before the current curser position, and the text after it seperately
                string preChar = textBox.Text.Substring(0, curserPos);
                string postChar = textBox.Text.Substring(curserPos, textBox.Text.Length - curserPos);

                // Set the text to have both characters between the text parts
                textBox.Text = preChar + "[]" + postChar;

                // Set the cursorposition to between the brackets created
                textBox.SelectionStart = curserPos + 1;

                // Set the event to handled
                e.Handled = true;
            } else if(e.KeyChar == ']') {
                // If it is a closing bracket, we need to make sure we need to add it, or if we can just skip to the next position
                // Get the position of the cursor in the window (the text cursor, not mouse cursor)
                int curserPos = textBox.SelectionStart;

                // Make sure our position is within the text length to prevent an IndexOutOfBoundsError
                // Then, check if the text at the next position is the pressed key (a closing bracket)
                if(curserPos < textBox.Text.Length && textBox.Text[curserPos] == e.KeyChar) {
                    // If both succeed, we just move the cursor position one ahead and set the event to handled
                    textBox.SelectionStart = curserPos + 1;
                    e.Handled = true;
                }
            }

            
        }

        

        

        /// <summary>
        /// Checks whether a specified char appears after a certain index
        /// </summary>
        /// <param name="c">The char to check for</param>
        /// <param name="index">The index to check from</param>
        /// <param name="text">The text to check in</param>
        /// <returns>True if the char appears after the specified index, and false if not</returns>
        public bool HasCharAfterIndex(char c, int index, string text) {
            // Go through each character after the index, if we find the specified character, return true there
            for (int i = index; i < text.Length; i++)
                if (text[i] == c)
                    return true;

            // If not, return false
            return false;
        }

        private void programTextbox_TextChanged(object sender, EventArgs e) {
            // Make sure the sender is a Rich Text Box and cast it if it is
            if (!(sender is RichTextBox textBox))
                return;

            interpreter.LoadNewProgram(textBox.Text);

            // Update the valid program label whenever the text changes, to show the user whether the program is valid or not
            validProgramLabel.Text = "Program Valid: " + (interpreter.ValidateProgram() ? "Yes" : "No");
        }
    }
}
