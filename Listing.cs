namespace mis_221_pa_5_clmiller16
{
    public class Listing
    {
        private int ID;
        private string name; // supposed to reference the trainer name (maybe make it "public" to do so)
        private DateOnly date;
        private string time;
        private string cost;
        private string taken;
        private bool deleted;
        static private int count;




        public Listing()
        {

        }

        public Listing(int ID, string name, DateOnly date, string time, string cost, string taken, bool deleted)
        {
            this.ID = ID;
            this.name = name;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.taken = taken;
            this.deleted = deleted;
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
        public void SetDate(DateOnly date){
            this.date = date;
        }
        public DateOnly GetDate(){
            return date;
        }
        public void SetTime(string time){
            this.time = time;
        }
        public string GetTime(){
            return time;
        }
        public void SetCost(string cost){
            this.cost = cost;
        }
        public string GetCost(){
            return cost;
        }
        public void SetTaken(string taken){
            this.taken = taken;
        }
        public string GetTaken(){
            return taken;
        }

        public void SetDeleted(bool deleted){
            this.deleted = deleted;
        }
        public bool GetDeleted(){
            return deleted;
        }



        static public void SetCount(int count)
        {
            Listing.count = count;
        }

        static public int GetCount()
        {
            return Listing.count;
        }

        static public void IncCount()
        {
            Listing.count++;
        }

        public override string ToString(){
            return $"The listing ID is {ID}, the trainer's name is {name}, the date is {date} and the time is {time}, the cost is {cost}, and it is taken- {taken}";
        }

        public string ToStringFormatted(){
            return $"{ID} \t{name} \t{date} \t{time} \t{cost} \t{taken}";
        }

        public string ToFile(){
            return $"{ID}#{name}#{date}#{time}#{cost}#{taken}#{deleted}";
        }


    }
}