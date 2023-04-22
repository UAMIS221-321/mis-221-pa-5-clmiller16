namespace mis_221_pa_5_clmiller16
{
    public class BookingUtility
    {
        private Booking[] bookings;
        private Listing[] listings;   

        // public BookingUtility(Booking[] bookings, Listing[] listings){
        //     this.bookings = bookings;
        //     this.listings = listings;
        // }
        public BookingUtility(Booking[] bookings){
            this.bookings = bookings;
        }     



        public void GetAllBookingsFromFile()
        {
            //open
            StreamReader inFile = new StreamReader("transactions.txt");

            //*** int wordCount = 0;


            //process
            Booking.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                //*** wordCount+=temp.Length();
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], DateOnly.Parse(temp[3]), int.Parse(temp[4]), temp[5], temp[6]);
                Booking.IncCount();
                line = inFile.ReadLine();
            }


            //close
            inFile.Close();
        }

        public void AddBooking()
        {
            System.Console.WriteLine("Please enter the session ID");
            Booking myBooking = new Booking();
            myBooking.SetSessionID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the customer name");
            myBooking.SetCustomerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the customer email address");
            myBooking.SetCustomerEmail(Console.ReadLine());
            System.Console.WriteLine("Please enter training date");
            myBooking.SetTrainingDate(DateOnly.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the trainer ID");
            myBooking.SetTrainerID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the trainer name");
            myBooking.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the status");
            myBooking.SetStatus(Console.ReadLine());
           
            bookings[Booking.GetCount()] = myBooking;
            Booking.IncCount();
        }

        public void BookSession(string stringUserInput){
            // System.Console.WriteLine("Which session ID would you like to book?");
            // string stringUserInput = Console.ReadLine(); 
            int userInput = int.Parse(stringUserInput);

            Booking myBooking = new Booking();

            myBooking.SetSessionID(userInput);
            System.Console.WriteLine("What is your name (customer)");
            myBooking.SetCustomerName(Console.ReadLine());
            System.Console.WriteLine("What is your email (customer)");
            myBooking.SetCustomerEmail(Console.ReadLine());

            StreamReader inFile = new StreamReader("listings.txt");

            int myCount = 0;
            string line = inFile.ReadLine();
            int HEREWEGO = -1;
            while(line != null)
            {
                string[] temp = line.Split('#');
                // myCount++;

                // for (int i = 0; i < temp.Length; i++){
                //     System.Console.WriteLine(temp[i]);
                // }

                for (int i = 0; i < temp.Length; i++){
                    if (stringUserInput == temp[i]){
                        // string[] temp2 = temp;
                        myBooking.SetTrainerName(temp[1]);
                        myBooking.SetTrainingDate(DateOnly.Parse(temp[2]));
                        myBooking.SetTrainerID(int.Parse(temp[7]));
                        //HEREWEGO = myBooking.GetTrainerID();
                    }
                }

                line = inFile.ReadLine();
            }

            inFile.Close();




            // StreamReader inFile2 = new StreamReader("trainers.txt");

            // //int myCount = 0;
            // string line2 = inFile2.ReadLine();
            // while(line2 != null)
            // {
            //     string[] temperory = line2.Split('#');
            //     //myCount++;

            //     // for (int i = 0; i < temperory.Length; i++){
            //     //     if (stringUserInput == temperory[i]){
            //     //         // string[] temp2 = temp;

            //     //         //NONE OF THIS IS EXECUTING!!
            //     //         System.Console.WriteLine(temperory[i]);
            //     //         System.Console.WriteLine(temperory[0]);
            //     //         System.Console.WriteLine(temperory[1]);
            //     //         System.Console.WriteLine(temperory[2]);
            //     //         Console.ReadKey();
            //     //         myBooking.SetTrainerID(int.Parse(temperory[0]));
            //     //     }
            //     // }

            //     if (HEREWEGO == int.Parse(temperory[0])){
            //         myBooking.SetTrainerID(int.Parse(temperory[0]));
            //     }

            //     line2 = inFile2.ReadLine();
            // }

            // inFile2.Close();

            bookings[Booking.GetCount()] = myBooking; // AHHHHHHHHH

            // for (int x = 0; x < bookings.Length; x++){
            //     System.Console.WriteLine(bookings[x].ToStringFormatted());
            // }
            






            // Listing myListing = new Listing();


            // myBooking.SetTrainingDate(myListing.GetDate());
            // myBooking.SetTrainerID(myListing.GetID());
            // myBooking.SetTrainerName(myListing.GetName());



            // myBooking.SetTrainingDate(myListing.GetDate());
            // myBooking.SetTrainerID(myListing.GetID());
            // myBooking.SetTrainerName(myListing.GetName());

            // Save();

            //pull info from listing here
        }

        public void Save2()
        {
            StreamWriter outFile = new StreamWriter("transactions.txt");

            // System.Console.WriteLine(Booking.GetCount());

            // outFile.WriteLine("BEFORE THE LOOP");

            for(int i = 0; i < Booking.GetCount(); i++)
            {
                outFile.WriteLine(bookings[i].ToFile());
            }


            // outFile.WriteLine("AFTER THE LOOP");

            outFile.Close();

        }

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("transactions.txt");

            // System.Console.WriteLine(Booking.GetCount());

            // outFile.WriteLine("BEFORE THE LOOP");

            for(int i = 0; i < Booking.GetCount() + 1; i++)
            {
                outFile.WriteLine(bookings[i].ToFile());
            }


            // outFile.WriteLine("AFTER THE LOOP");

            outFile.Close();

        }

        private int Find(int searchVal)
        {
            for(int i = 0; i < Booking.GetCount(); i++)
            {
                if(bookings[i].GetSessionID() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }

        public void UpdateBooking()
        {
            System.Console.WriteLine("What is the ID of the session you want to update");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if(foundIndex != -1)
            {
                // System.Console.WriteLine("Please enter the ID");
                // bookings[foundIndex].SetID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the customer name");
                bookings[foundIndex].SetCustomerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the customer email address");
                bookings[foundIndex].SetCustomerEmail(Console.ReadLine());
                System.Console.WriteLine("Please enter training date");
                bookings[foundIndex].SetTrainingDate(DateOnly.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the trainer ID");
                bookings[foundIndex].SetTrainerID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the trainer name");
                bookings[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the status");
                bookings[foundIndex].SetStatus(Console.ReadLine());

                Save();

            }
            else
            {
                System.Console.WriteLine("Session not found");
            }

        }



        // public void DeleteBooking(){
        //     System.Console.WriteLine("What is the ID of the Booking you want to delete?");
        //     int deleteID = int.Parse(Console.ReadLine());

        //     bookings[deleteID - 1].SetDeleted(true);
        // }

        public void SortByEmail(){
            for (int i = 0; i < Booking.GetCount() - 1; i++){
                int min = i;

                for (int j = i + 1; j < Booking.GetCount(); j++){
                    if (bookings[j].GetCustomerEmail().CompareTo(bookings[min].GetCustomerEmail()) < 0 ){
                        min = j;
                    }
                }
                if (min != i){
                    Swap(min, i);
                }
            }
        }

        public void SortByCustomerNameThenByDate(){
            for (int i = 0; i < Booking.GetCount() - 1; i++){
                int min  = i;

                for (int j = i + 1; j < Booking.GetCount(); j++){
                    if (bookings[j].GetCustomerName().CompareTo(bookings[min].GetCustomerName()) < 0 ||
                    (bookings[j].GetCustomerName() == bookings[min].GetCustomerName() && bookings[j].GetTrainingDate() < bookings[min].GetTrainingDate())
                    ){
                        min = j;
                    }
                }
                if (min != i){
                    Swap(min, i);
                }
            }
        }

        private void Swap(int x, int y){
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }

        public void CompleteOrCancel(){

            string userInput = GetSubMenuChoice();
            while (userInput != "4"){
                RouteSubMenu(userInput);
                userInput = GetSubMenuChoice();
            }

        }

        private string GetSubMenuChoice(){
            DisplaySubMenu();
            string userInput = Console.ReadLine();

            while (!ValidSubMenuChoice(userInput)){
                Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();

                DisplaySubMenu();
                userInput = Console.ReadLine(); // change to get submenuchoice!!!
            }

            return userInput;

        }

        private void DisplaySubMenu(){
            Console.Clear();
            System.Console.WriteLine("1:    Complete an Appointment");
            System.Console.WriteLine("2:    Cancel an Appointment");
            System.Console.WriteLine("3:    No-Show an Appointment");
            System.Console.WriteLine("4:    Exit");
        }
        
        private bool ValidSubMenuChoice(string userInput){
            if (userInput == "1" || userInput == "2"|| userInput == "3"|| userInput == "4"){
                return true;
            } else return false;
        }

        private void RouteSubMenu(string userInput){
            if (userInput == "1"){
                CompleteAppointment();
            } else if (userInput == "2"){
                CancelAppointment();
            } else NoShowAppointment();
        }

        private void CompleteAppointment(){
            System.Console.WriteLine("What is the ID of the session you want to complete?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if (foundIndex != -1){
                bookings[foundIndex].SetStatus("completed");
                Save2();
            } else System.Console.WriteLine("Session not found");
        }

        private void CancelAppointment(){
            System.Console.WriteLine("What is the ID of the session you want to cancel?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if (foundIndex != -1){
                bookings[foundIndex].SetStatus("cancelled");
                Save2();
            } else System.Console.WriteLine("Session not found");     
        }

        private void NoShowAppointment(){
            System.Console.WriteLine("What is the ID of the session you've decided not to show up to?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if (foundIndex != -1){
                bookings[foundIndex].SetStatus("no-show");
                Save2();
            } else System.Console.WriteLine("Session not found");
        }


    }
}