namespace mis_221_pa_5_clmiller16
{
    public class Listing
    {
        private int ID;
        private string name; // supposed to reference the trainer name (maybe make it "public" to do so)
        private string date;
        private string time;
        private string cost;
        private bool taken;




        public Listing()
        {

        }

        public Listing(int ID, string name, string date, string time, string cost, bool taken)
        {
            this.ID = ID;
            this.name = name;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.taken = taken;
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
        public void SetDate(string date){
            this.date = date;
        }
        public string GetDate(){
            return date;
        }
        public void SetCost(string cost){
            this.cost = cost;
        }
        public string GetCost(){
            return cost;
        }
        public void SetTaken(bool taken){
            this.taken = taken;
        }
        public bool GetTaken(){
            return taken;
        }

        public override string ToString(){
            return $"The listing ID is {ID}, the trainer's name is {name}, the date is {date} and the time is {time}, the cost is {cost}, and it is taken- {taken}";
        }

        public string ToFile(){
            return $"{ID}#{name}#{date}#{time}#{cost}#{taken}";
        }




    }
}