namespace mis_221_pa_5_clmiller16
{
    public class TrainerUtility
    {
        private Trainer[] trainers;   

        public TrainerUtility(Trainer[] trainers){
            this.trainers = trainers;
        }     



        public void GetAllBooksFromFile()
        {
            //open
            StreamReader inFile = new StreamReader("input.txt");

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
    }
}