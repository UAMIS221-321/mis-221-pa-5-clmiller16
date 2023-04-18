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
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], temp[6]);
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
            myBooking.SetTrainingDate(Console.ReadLine());
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
                        myBooking.SetTrainingDate(temp[2]);
                    }
                }

                line = inFile.ReadLine();
            }

            inFile.Close();




            StreamReader inFile2 = new StreamReader("trainers.txt");

            //int myCount = 0;
            string line2 = inFile2.ReadLine();
            while(line2 != null)
            {
                string[] temp = line2.Split('#');
                //myCount++;

                for (int i = 0; i < temp.Length; i++){
                    if (stringUserInput == temp[i]){
                        // string[] temp2 = temp;
                        myBooking.SetTrainerID(int.Parse(temp[0]));
                    }
                }

                line2 = inFile2.ReadLine();
            }

            inFile2.Close();

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

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("transactions.txt");

            System.Console.WriteLine(Booking.GetCount());

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
                bookings[foundIndex].SetTrainingDate(Console.ReadLine());
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

        public void SortByCustomerName(){
            for (int i = 0; i < Booking.GetCount() - 1; i++){
                int min  = i;

                for (int j = i + 1; j < Booking.GetCount(); j++){
                    if (bookings[j].GetCustomerName().CompareTo(bookings[min].GetCustomerEmail()) < 0 ){
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
    }
}