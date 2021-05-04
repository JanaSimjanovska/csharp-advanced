using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppClassLibrary
{
    public static class QuizDB
    {

        public static string Question01 { get; set; } = "\n1. What is the capital of Tasmania?\n" +
            "\n1. Dodoma" +
            "\n2. Hobart" +
            "\n3. Launceston" +
            "\n4. Wellington";

        public static string Question02 { get; set; } = "\n2. What is the tallest building in the Republic of the Congo?\n" +
            "\n1. Kinshasa Democratic Republic of the Congo Temple" +
            "\n2. Palais de la Nation" +
            "\n3. Kongo Trade Centre" +
            "\n4. Nabemba Tower";

        public static string Question03 { get; set; } = "\n3. Which of these is not one of Pluto's moons?\n" +
            "\n1. Styx" +
            "\n2. Hydra" +
            "\n3. Nix" +
            "\n4. Lugia";

        public static string Question04 { get; set; } = "\n4. What is the smallest lake in the world?\n" +
            "\n1. Onega Lake" +
            "\n2. Benxi Lake" +
            "\n3. Kivu Lake" +
            "\n4. Wakatipu Lake";

        public static string Question05 { get; set; } = "\n5. What country has the largest population of alpacas?\n" +
            "\n1. Chad" +
            "\n2. Peru" +
            "\n3. Australia" +
            "\n4. Niger";


        public static Dictionary<string, int> AllQuestionsWithCorrectAnswer { get; set; } = new Dictionary<string, int>
        {
            { Question01, 2 },
            { Question02, 4 },
            { Question03, 3 },
            { Question04, 2 },
            { Question05, 2 }
        };


        static QuizDB()
        {
        }

    }
}
