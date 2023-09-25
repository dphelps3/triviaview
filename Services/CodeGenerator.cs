using System.Data;
using TriviaLink.Models;
using Microsoft.EntityFrameworkCore;

namespace TriviaLink.Services
{
    public class CodeGenerator
    {


        public static string GenerateCode()
        {
            Random rand = new Random();

            int stringlength = 4;
            int randValue;
            string str = "";
            char letter;

            for (int i = 0; i < stringlength; i++)
            {
                randValue = rand.Next(0, 26);

                letter = Convert.ToChar(randValue + 65);

                str = str + letter;
            }

            return str;
        }

        public static bool CheckCodeValidity()
        {
            
        }
    }
}
