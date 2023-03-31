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

        
    }
}