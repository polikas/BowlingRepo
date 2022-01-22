using System;

public class BowlingGame
{
     int totalScore = 0;

     public int PlayBowling(int score)
    {
        //declare variables
        Random rnd = new Random();
        int roll1 = 0;
        int roll2 = 0;
        int roll3 = 0;
        int tempScore = 0;
        int totalPins = 10;
        string spare = "SPARE";
        string strike = "STRIKE";
        string spareOrStrike = "";


        for (int frame = 1; frame <= 10; frame++)
        {
            Console.WriteLine("Frame " + frame);
            Console.WriteLine(" ");

            roll1 = rnd.Next(0, totalPins + 1);
            Console.WriteLine("roll one: " + roll1);

            totalPins -= roll1;

            //check iff roll one didnt strike so move to second roll
            if (totalPins > 0)
            {
                roll2 = rnd.Next(0, totalPins + 1); // +1 to fix the range of totalPins left as a maxium value
                Console.WriteLine("roll two: " + roll2);

                //strike on second roll
                if (totalPins == 10 && roll2 == 10)
                {
                    Console.WriteLine(strike);
                    spareOrStrike = strike;
                    totalPins -= roll2;
                }

                totalPins -= roll2;
                //check remaining pins if 0 then its spare
                if (totalPins == 0 && roll2 < 10)
                {
                    Console.WriteLine(spare);
                    spareOrStrike = spare;
                }
            }
            else //strike with first roll
            {
                Console.WriteLine(strike);
            }
            //check final frame and 
            if (frame == 10 && spareOrStrike == strike || frame == 10 && spareOrStrike == spare)
            {
                totalPins = 10;
                // extra roll
                roll3 = rnd.Next(0, totalPins + 1);
                Console.WriteLine("10th Frame 3rd roll: " + roll3);
            }


            tempScore = roll1 + roll2 + roll3;
            totalScore += tempScore;
            Console.WriteLine("Score: " + tempScore);
            totalPins = 10;
            roll2 = 0;
            Console.WriteLine("End of Frame " + frame);
            spareOrStrike = " ";
            Console.WriteLine(" ");
        }

        return totalScore;
    }

    public static void Main(string[] args)
    {
        BowlingGame game = new BowlingGame();

        game.PlayBowling(game.totalScore);
        Console.WriteLine("Total Score: " + game.totalScore);
    }
}