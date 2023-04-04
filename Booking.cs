namespace mis_221_pa_5_clmiller16
{
    public class Booking
    {
        int ID;
        string customerName;
        string customerEmail;
        string trainingDate;
        int trainerID;
        string trainerName;
        string status;

        public Booking(){
            status = "booked";
        }

        public void SetID(int ID){
            this.ID = ID;
        }
        public int GetID(){
            return ID;
        }
        public void SetCustomerName(string customerName){
            this.customerName = customerName;
        }
        public string GetCustomerName(){
            return customerName;
        }
        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }
        public string GetCustomerEmail(){
            return customerEmail;
        }
        public void SetTrainingDate(string trainingDate){
            this.trainingDate = trainingDate;
        }
        public string GetTrainingDate(){
            return trainingDate;
        }
        public void SetTrainerID(){
            this.trainerID = trainerID;
        }
        public int GetTrainerID(int trainerID){
            return trainerID;
        }
        public void SetTrainerName(){
            this.trainerName = trainerName;
        }
        public string GetTrainerName(string trainerName){
            return trainerName;
        }
        public void SetStatus(){
            this.status = status;
        }
        public string GetStatus(string status){
            return status;
        }


    }
}