namespace mis_221_pa_5_clmiller16
{
    public class Trainer
    {
        private int ID;
        private string name;
        private string address;
        private string email;
        private bool deleted;
        // private bool deleted;

        static private int count;

        public Trainer()
        {

        }

        public Trainer(int ID, string name, string address, string email, bool deleted)
        {
            this.ID = ID;
            this.name = name;
            this.address = address;
            this.email = email;
            this.deleted = deleted;

            // deleted = false;
        }


        public void SetID(int ID){
            this.ID = ID;
        }

        public int GetID(){
            return ID;
        }

        public void SetName(string name){
            this.name = name;
        }

        public string GetName(){
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

        public void SetDeleted(bool deleted){
            this.deleted = deleted;
        }
        public bool GetDeleted(){
            return deleted;
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

        public string ToStringFormatted(){
            return $"{ID} \t{name} \t{address} \t{email}";
        }

        public string ToFile(){
            return $"{ID}#{name}#{address}#{email}#{deleted}";
        }



    }
}