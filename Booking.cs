namespace mis_221_pa_5_clmiller16
{
    public class Booking
    {
        int sessionID;
        string customerName;
        string customerEmail;
        string trainingDate;
        int trainerID;
        string trainerName;
        string status;
        static private int count;

        public Booking(){
            status = "booked";
        }

        public Booking(int sessionID, string customerName, string customerEmail, string trainingDate, int trainerID, string trainerName){
            status = "booked";
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
        }

        public void SetSessionID(int sessionID){
            this.sessionID = sessionID;
        }
        public int GetSessionID(){
            return sessionID;
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
        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }
        public int GetTrainerID(){
            return trainerID;
        }
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }
        public string GetTrainerName(){
            return trainerName;
        }
        public void SetStatus(string status){
            this.status = status;
        }
        public string GetStatus(){
            return status;
        }
        static public void SetCount(int count)
        {
            Booking.count = count;
        }

        static public int GetCount()
        {
            return Booking.count;
        }

        static public void IncCount()
        {
            Booking.count++;
        }

        public override string ToString(){
            return $"The session ID is {sessionID}, the customer name is {customerName}, the customer email is {customerEmail}, and the training date is {trainingDate}, the trainer ID is {trainerID}, the trainer name is {trainerName}, and the status is {status}";
        }

        public string ToStringFormatted(){
            return $"{sessionID} \t{customerName} \t{customerEmail} \t{trainingDate} \t{trainerID} \t{trainerName} \t{status}";
        }

        public string ToFile(){
            return $"{sessionID}#{customerName}#{customerEmail}#{trainingDate}#{trainerID}#{trainerName}#{status}";
        }



    }
}