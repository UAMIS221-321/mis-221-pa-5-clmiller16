namespace mis_221_pa_5_clmiller16
{
    public class Trainer
    {
        private int ID;
        private string name;
        private string address;
        private string email;

        static private int count;

        public Trainer()
        {

        }

        public Trainer(int ID, string name, string address, string email)
        {
            this.ID = ID;
            this.name = name;
            this.address = address;
            this.email = email;
        }

        public void SetID(int ID){
            this.ID = ID;
        }

        public int GetID(){
            return ID;
        }

        public void SetTrainerName(string name){
            this.name = name;
        }

        public string GetTrainerName(){
            return name;
        }

        public void SetAddress(string address){
            this.address = address;
        }

        public string GetAddress(){
            return address;
        }

        public void SetEmail(string email){
            this.email = email;
        }

        public string GetEmail(){
            return email;
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
            return $"The trainer ID is {ID}, the name is {name}, the address is {address}, and the email is {email}";
        }

        public string ToFile(){
            return $"{ID}#{name}#{address}#{email}";
        }



    }
}