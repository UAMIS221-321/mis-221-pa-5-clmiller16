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
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                Trainer.IncCount();
                line = inFile.ReadLine();
            }


            //close
            inFile.Close();
        }

        public void AddTrainer()
        {
            System.Console.WriteLine("Please enter the ID");
            Trainer myTrainer = new Trainer();
            myTrainer.SetID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the name");
            myTrainer.SetName(Console.ReadLine());
            System.Console.WriteLine("Please enter the mailing address");
            myTrainer.SetAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter the email address");
            myTrainer.SetEmail(Console.ReadLine());
           
            trainers[Trainer.GetCount()] = myTrainer;
            Trainer.IncCount();
        }

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

        public void UpdateTrainer()
        {
            System.Console.WriteLine("What is the ID of the trainer you want to update");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if(foundIndex != -1)
            {
                System.Console.WriteLine("Please enter the ID");
                trainers[foundIndex].SetID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the name");
                trainers[foundIndex].SetName(Console.ReadLine());
                System.Console.WriteLine("Please enter the address");
                trainers[foundIndex].SetAddress(Console.ReadLine());
                System.Console.WriteLine("Please enter the email");
                trainers[foundIndex].SetEmail(Console.ReadLine());

                Save();

            }
            else
            {
                System.Console.WriteLine("Trainer not found");
            }

        }
    }
}