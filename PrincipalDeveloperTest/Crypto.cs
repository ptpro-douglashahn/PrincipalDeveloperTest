using System;
namespace PrincipalDeveloper
{
    /// <summary>
    /// Scramble and Descramble a string using a key
    /// </summary>
    public class Crypto
    {
        //
        //  Version    Date         Author        Description
        //  1.000      23 Jan 2024  Douglas Hahn  Writing a test for hiring a principal developer - initial development
        //
        /// <summary>
        /// Generate a key and scramble a string using that key
        /// </summary>
        /// <param name="inputString">The string to scramble</param>
        /// <returns>A class called ScrambledAndKey that has two elements, a scrambled string and the key used to scramble the key</returns>
        public ScrambledAndKey Scramble(string inputString)
        {
            //
            //  Validations
            //
            ValidateInputString(inputString);
            //
            //  Assemble a key using a random generator
            //  Make the key one character shorter than the input string
            //
            Random rnd = new Random();
            string generatedKeyString;
            string validCharacters = AllValidCharacters();
            do
            {
                generatedKeyString = "";
                for (int c = 0; c < inputString.Length - 1; c++)
                {
                    int genPos = rnd.Next(0, validCharacters.Length - 1);
                    generatedKeyString += validCharacters.Substring(genPos, 1);
                }
            } while (generatedKeyString.Trim() == "");
            //
            //  Create the class to return both the scrambled string and the key
            //
            ScrambledAndKey outputValue = new ScrambledAndKey();
            //
            //  Scramble the input string using the generated key and save it in the ScrambledAndKey class
            //
            outputValue.Scrambled = Scramble(inputString, generatedKeyString);
            //
            //  Save the key in the ScrambledAndKey class
            //
            outputValue.Key = generatedKeyString;
            //
            //  return the ScrambledAndKey class
            //
            return outputValue;
        }
        /// <summary>
        /// Scramble an input string using a provided key
        /// </summary>
        /// <param name="inputString">The string to be scrambled</param>
        /// <param name="keyString">The key to use in scrambling the string</param>
        /// <returns>The scrambled string</returns>
        public string Scramble(string inputString, string keyString)
        {
            //
            //  Validation Checks
            //
            ValidateInputString(inputString);
            if (keyString == null)
            {
                throw new Exception("The key string cannot be null.");
            }
            if (keyString.Length >= inputString.Length)
            {
                throw new Exception("Your key string must be shorter than your input string");
            }
            if (keyString.Trim() == "")
            {
                throw new Exception("A keyString of all spaces will not scramble the input string.");
            }
            //
            //  Check for invalid characters in the keyString
            //
            string validCharacters = AllValidCharacters();
            for (int intC = 0; intC < keyString.Length; intC++)
            {
                string targetChar = keyString.Substring(intC, 1);
                if (!validCharacters.Contains(targetChar))
                {
                    throw new Exception("Your key string contains invalid characters.  " + (char)34 + targetChar + (char)34);
                }
            }
            //
            //  Create the variable to output
            //
            string scrambledString = "";
            //
            //  Loop through the inputString and calculate the scrambled characters
            //
            for (int intC = 0; intC < inputString.Length; intC++)
            {
                char inputChar = inputString.Substring(intC, 1)[0];
                int inputAscii = (int)inputChar;
                int inputValidCharPos = inputAscii - 32;
                //
                //  Determine which keyString character to use to scramble the target character
                //
                int keyValidCharPos = intC % keyString.Length;
                char keyChar = keyString.Substring(keyValidCharPos, 1)[0];
                int keyAscii = (int)keyChar;
                int keyPosition = keyAscii - 32;
                //
                //  Determine the scrambled character by adding the two integers together
                //  If the position of the scrambled character is after the end of the valid characters,
                //  then add the valid character length
                //
                int scrambledPosition = (inputValidCharPos + keyPosition) % validCharacters.Length;
                char scrambledChar = validCharacters.Substring(scrambledPosition,1)[0];
                //
                //  Concatenate it to the scrambled string
                //
                scrambledString += scrambledChar;
            }
            //
            //  Return the result
            //
            return scrambledString;
        }
        /// <summary>
        /// Descramble the scrambled string using the key 
        /// </summary>
        /// <param name="scrambledString">The scrambled string</param>
        /// <param name="keyString">The key used to scramble the string</param>
        /// <returns>The descrambled string</returns>
        public string Descramble(string scrambledString, string keyString)
        {
            //
            //  Validations
            //
            if (scrambledString == null)
            {
                throw new Exception("The scrambled string cannot be null.");
            }
            if (keyString == null)
            {
                throw new Exception("The key string cannot be null.");
            }
            string validCharacters = AllValidCharacters();
            //
            //  Loop through the inputString and calculate the scrambled characters
            //
            string descrambledString = "";
            for (int intC = 0; intC < scrambledString.Length; intC++)
            {
                //
                //  Extract the target scrambled character
                //
                char scrambledChar = scrambledString.Substring(intC, 1)[0];
                int scrambledAscii = (int)scrambledChar;
                int keyPosition = intC % keyString.Length;
                //
                //  Extract the key Character
                //
                char keyChar = keyString.Substring(keyPosition, 1)[0];
                int keyAscii = (int)keyChar;
                int descrambledPos = (scrambledAscii - keyAscii);
                if (descrambledPos < 0)
                {
                    descrambledPos += validCharacters.Length;
                }
                //
                //  Determine the descrambled character from the valid characters string
                //
                char descrambledChar = validCharacters.Substring(descrambledPos,1)[0];
                //
                //  Concatenate it to the scrambled string
                //
                descrambledString += descrambledChar;
            }
            return descrambledString;
        }
        /// <summary>
        /// Generate a list of all the valid characters that can be used in either the input string or the key
        /// </summary>
        /// <returns>A string of all the valid characters</returns>
        public string AllValidCharacters()
        {
            string validCharacters = "";
            for (int intC = 32; intC < 127; intC++)
            {
                validCharacters += (char)intC;
            }
            return validCharacters;
        }
        /// <summary>
        /// Validate the Input String
        /// </summary>
        /// <param name="inputString"></param>
        protected void ValidateInputString(string inputString)
        {
            //
            //  Validations
            //
            if (inputString == null)
            {
                throw new Exception("The input string cannot be null.");
            }
            if (inputString.Length < 2)
            {
                throw new Exception("The input string must be at least 2 characters in length.");
            }
            //
            //  Check for invalid characters in the inputString
            //
            string validCharacters = AllValidCharacters();
            for (int intC = 0; intC < inputString.Length; intC++)
            {
                string targetChar = inputString.Substring(intC, 1);
                if (!validCharacters.Contains(targetChar))
                {
                    throw new Exception("Your input string contains invalid characters.");
                }
            }
        }
        /// <summary>
        /// This class is needed to return two values the scrambled string and the key that was generated to scramble the data
        /// </summary>
        public class ScrambledAndKey
        {
            public string Scrambled;
            public string Key;
        }
    }
}
