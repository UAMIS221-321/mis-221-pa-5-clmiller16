namespace mis_221_pa_5_clmiller16
{
    public class Trainer
    {
        private int trainerID;
        private string trainerName;
        private string trainerAddress;
        private string trainerEmail;

        static private int count;

        public Trainer()
        {

        }

        public Trainer(int trainerID, string trainerName, string trainerAddress, string trainerEmail)
        {
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.trainerAddress = trainerAddress;
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

        public void SetTrainerAddress(string trainerAddress){
            this.trainerAddress = trainerAddress;
        }

        public string GetTrainerAddress(){
            return trainerAddress;
        }

        public void SetTrainerEmail(string trainerEmail){
            this.trainerEmail = trainerEmail;
        }

        public string GetTrainerEmail(){
            return trainerEmail;
        }

        static public void SetCount(int count)
        {
            Trainer.count = count;
        }

        static public int GetCount()
        {
            return Trainer.count;
        }

        static public void IncCount()
        {
            Trainer.count++;
        }

        public override string ToString(){
            return $"The trainer ID is {trainerID}, the name is {trainerName}, the address is {trainerAddress}, and the email is {trainerEmail}";
        }

        public string ToFile(){
            return $"{trainerID}#{trainerName}#{trainerAddress}#{trainerEmail}";
        }



    }
}