namespace mis_221_pa_5_clmiller16
{
    public class Trainer
    {
        private int trainerID;
        private string trainerName;
        private string address;
        private string trainerEmail;

        public Trainer()
        {

        }

        public Trainer(int trainerID, string trainerName, string address, string trainerEmail)
        {
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.address = address;
            this.trainerEmail = trainerEmail;
        }

        public void SetID(int trainerID){
            this.trainerID = trainerID;
        }

        public int GetID(){
            return trainerID;
        }

        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        public string GetTrainerName(){
            return trainerName;
        }

        public void SetAddress(string address){
            this.address = address;
        }

        public string GetAddress(){
            return address;
        }

        public void SetTrainerEmail(string trainerEmail){
            this.trainerEmail = trainerEmail;
        }

        public string GetTrainerEmail(){
            return trainerEmail;
        }



    }
}