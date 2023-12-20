using System.Windows;

namespace _3drenderer
{
    public static class UserInputHelper
    {
        public static double GetUserInput(string prompt)
        {
            double userInput;
            string input;
            do
            {
                input = Microsoft.VisualBasic.Interaction.InputBox(prompt, "User Input", "1.0");
                if (!double.TryParse(input, out userInput))
                {
                    MessageBox.Show("Invalid input. Please enter a valid number.");
                }
            } while (!double.TryParse(input, out userInput));
            return userInput;
        }
    }
}
