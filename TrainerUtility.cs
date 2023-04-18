namespace mis_221_pa_5_clmiller16
{
    public class TrainerUtility
    {
        private Trainer[] trainers;   

        public TrainerUtility(Trainer[] trainers){
            this.trainers = trainers;
        }     



        public void GetAllTrainersFromFile()
        {
            //open
            StreamReader inFile = new StreamReader("trainers.txt");

            //*** int wordCount = 0;


            //process
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                //*** wordCount+=temp.Length();
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3], bool.Parse(temp[4]));
                Trainer.IncCount();
                line = inFile.ReadLine();
            }


            //close
            inFile.Close();
        }

        public void AddTrainer(int max)
        {
            int count = Trainer.GetCount();
            // FindMaxID(count);

            // System.Console.WriteLine("Please enter the ID");
            Trainer myTrainer = new Trainer();
            myTrainer.SetID(max);
            System.Console.WriteLine("Please enter the name");
            myTrainer.SetName(Console.ReadLine());
            System.Console.WriteLine("Please enter the mailing address");
            myTrainer.SetAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter the email address");
            myTrainer.SetEmail(Console.ReadLine());

            myTrainer.SetDeleted(false);
           
            trainers[Trainer.GetCount()] = myTrainer; // adds myTrainer to last slot in trainers
            Trainer.IncCount();
        }

        // public int FindMaxID(int count){
        //     int max = 

        //     for (int i = 0; i < count; i++){
                
        //     }



        //     return max;
        // }


        public void Save()
        {
            StreamWriter outFile = new StreamWriter("trainers.txt");

            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                outFile.WriteLine(trainers[i].ToFile());
            }

            outFile.Close();

        }

        private int Find(int searchVal)
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                if(trainers[i].GetID() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }

        private int FindBinary(int searchVal){
            int last = Trainer.GetCount();
            int first = 0;
            int foundIndex = -1;
            bool found = false;
            while (!found && last >= first)
            {
                int middle = (last + first) / 2;
                if (trainers[middle].GetID() == searchVal)
                {
                    found = true;
                    foundIndex = middle;
                }
                else
                {
                    if (trainers[middle].GetID() < searchVal)
                    {
                        first = middle + 1;
                    }
                    else 
                    {
                        last = middle - 1;
                    }
                }
            }
            return foundIndex;

        }

        public void UpdateTrainer()
        {
            System.Console.WriteLine("What is the ID of the trainer you want to update");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = FindBinary(searchVal);
            System.Console.WriteLine();
            if (foundIndex != -1){
                System.Console.WriteLine(trainers[foundIndex].GetName());
            } else System.Console.WriteLine("Nothing found");
    
            System.Console.WriteLine();
            Console.ReadKey();
            if(foundIndex != -1)
            {
                // System.Console.WriteLine("Please enter the ID");
                // trainers[foundIndex].SetID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the name");
                trainers[foundIndex].SetName(Console.ReadLine());
                System.Console.WriteLine("Please enter the address");
                trainers[foundIndex].SetAddress(Console.ReadLine());
                System.Console.WriteLine("Please enter the email");
                trainers[foundIndex].SetEmail(Console.ReadLine());

                trainers[foundIndex].SetDeleted(false);

                Save();

            }
            else
            {
                System.Console.WriteLine("Trainer not found");
            }

        }

        public string DeleteTrainer(){
            System.Console.WriteLine("What is the ID of the trainer you want to delete?");
            string userInput = Console.ReadLine();
            while (int.TryParse(userInput, out int output) == false){
                System.Console.WriteLine("Please enter in a number");
                userInput = Console.ReadLine();
            }

            int deleteID = int.Parse(userInput);

            trainers[deleteID - 1].SetDeleted(true);

            return trainers[deleteID - 1].GetName();
        }
    }
}