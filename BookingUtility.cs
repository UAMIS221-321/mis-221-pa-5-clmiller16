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


        // gets all the bookings
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
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], DateOnly.Parse(temp[3]), int.Parse(temp[4]), temp[5], temp[6], int.Parse(temp[7]));
                Booking.IncCount();
                line = inFile.ReadLine();
            }


            //close
            inFile.Close();
        }
        
        // adds a booking
        // public void AddBooking()
        // {
        //     System.Console.WriteLine("Please enter the session ID");
        //     Booking myBooking = new Booking();
        //     myBooking.SetSessionID(int.Parse(Console.ReadLine()));
        //     System.Console.WriteLine("Please enter the customer name");
        //     myBooking.SetCustomerName(Console.ReadLine());
        //     System.Console.WriteLine("Please enter the customer email address");
        //     myBooking.SetCustomerEmail(Console.ReadLine());
        //     System.Console.WriteLine("Please enter training date");
        //     myBooking.SetTrainingDate(DateOnly.Parse(Console.ReadLine()));
        //     System.Console.WriteLine("Please enter the trainer ID");
        //     myBooking.SetTrainerID(int.Parse(Console.ReadLine()));
        //     System.Console.WriteLine("Please enter the trainer name");
        //     myBooking.SetTrainerName(Console.ReadLine());
        //     System.Console.WriteLine("Please enter the status");
        //     myBooking.SetStatus(Console.ReadLine());
        //     System.Console.WriteLine("Please enter the cost");
        //     myBooking.SetCost(int.Parse(Console.ReadLine()));
           
        //     bookings[Booking.GetCount()] = myBooking;
        //     Booking.IncCount();
        // }


        // Books a session
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

            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');

                // pulls info from listings to book a session
                for (int i = 0; i < temp.Length; i++){
                    if (stringUserInput == temp[i]){
                        myBooking.SetTrainerName(temp[1]);
                        myBooking.SetTrainingDate(DateOnly.Parse(temp[2]));
                        myBooking.SetTrainerID(int.Parse(temp[7]));
                        myBooking.SetCost(int.Parse(temp[4]));
                    }
                }

                line = inFile.ReadLine();
            }

            inFile.Close();

            bookings[Booking.GetCount()] = myBooking; // AHHHHHHHHH

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

        // finds the index where the listing is found
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

        // finds the index of the booking based on the ID you input, then updates the content
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
                System.Console.WriteLine("Please enter the cost");
                bookings[foundIndex].SetCost(int.Parse(Console.ReadLine()));

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

        // sorts the bookings alphabetically by customer email
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

        // sorts alphabetically by name then chronologically by date
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

        // sorts chronologically by date
        public void SortByDate(){
            for (int i = 0; i < Booking.GetCount() - 1; i++){
                int min  = i;

                for (int j = i + 1; j < Booking.GetCount(); j++){
                    if (bookings[j].GetTrainingDate() < bookings[min].GetTrainingDate())
                    {
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

        public void CompleteOrCancel(int selectedIndex){

            RouteSubMenu(selectedIndex);

            //here will take a string and feed it to RouteSubMenu
        }

        // private string GetSubMenuChoice(){
        //     DisplaySubMenu();
        //     string userInput = Console.ReadLine();

        //     while (!ValidSubMenuChoice(userInput)){
        //         Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
        //         Console.WriteLine("Press any key to continue....");
        //         Console.ReadKey();

        //         DisplaySubMenu();
        //         userInput = Console.ReadLine(); // change to get submenuchoice!!!
        //     }

        //     return userInput;

        // }

        // private void DisplaySubMenu(){
        //     Console.Clear();
        //     System.Console.WriteLine("1:    Complete an Appointment");
        //     System.Console.WriteLine("2:    Cancel an Appointment");
        //     System.Console.WriteLine("3:    No-Show an Appointment");
        //     System.Console.WriteLine("4:    Exit");
        // }
        
        // private bool ValidSubMenuChoice(string userInput){
        //     if (userInput == "1" || userInput == "2"|| userInput == "3"|| userInput == "4"){
        //         return true;
        //     } else return false;
        // }

        private void RouteSubMenu(int selectedIndex){
            Console.CursorVisible = true;
            if (selectedIndex == 0){
                CompleteAppointment();
            } else if (selectedIndex == 1){
                CancelAppointment();
            } else NoShowAppointment();
        }

        // to complete an appointment- sets to completed and runs workouts
        private void CompleteAppointment(){
            System.Console.WriteLine("What is the ID of the session you want to complete?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if (foundIndex != -1){
                bookings[foundIndex].SetStatus("completed");
                Save2();
            } else System.Console.WriteLine("Session not found");

            System.Console.WriteLine("\nWhat type of workout would you like to complete?\n");
            System.Console.WriteLine("Options Include:");
            System.Console.WriteLine("1. Dunk Contest\n2. Exercise\n3. 1v1");
            string workoutType = Console.ReadLine();

            if (workoutType.ToUpper() == "DUNK CONTEST" || workoutType == "1"){
                DunkContest();
            } else if (workoutType.ToUpper() == "EXERCISE" || workoutType == "2"){
                Exercise();
            } else if (workoutType.ToUpper() == "1V1" || workoutType == "3"){
                oneVSone();
            }
            
        }

        // dunk contest
        private void DunkContest(){
            Console.Clear();

            System.Console.WriteLine("Please select a difficulty level for this workout");
            System.Console.WriteLine("1:    Rookie\n2:    Advanced\n3:    Pro");
            int difficulty = int.Parse(Console.ReadLine());
            Console.Clear();

            System.Console.WriteLine("Welcome to the Chicago Bulls Official Dunk Contest- It is your job to impress the judges!\n");
            System.Console.WriteLine("Pick a number between 1 and 7 to decide which dunk you want to attempt tonight.\n");
            string dunkStyle = Console.ReadLine(); // this will choose a dunk style, this does not affect odds of failing a dunk attempt-- each dunk style has an associated score


            // generates a random number of failed attempts
            Random rnd = new Random();
            int failedAttempts = -1;
            if(difficulty == 1){
                failedAttempts = rnd.Next(1,2);
            } else if (difficulty == 2){
                failedAttempts = rnd.Next(1,4);
            } else if (difficulty == 3){
                failedAttempts = rnd.Next(1,8);
            } else {
                failedAttempts = 0;
            }
            //System.Console.WriteLine(failedAttempts);
            
            // you are only allowed to fail 3 dunks before receiving a score of 0
            int maxAttempts = 3;
            for (int i = 0; i < failedAttempts; i++){
                
                if (i < maxAttempts){
                    System.Console.WriteLine("Press any key to attempt a dunk");
                    Console.ReadKey();
                    System.Console.WriteLine("FAILED ATTEMPT\n");
                }
            }
            

            // messages if you failed all 3 or the result depending on which style dunk you choose
            if (failedAttempts >= 3){
                System.Console.WriteLine("You failed 3 attempts\n\nScore: 0");
            } else{
                System.Console.WriteLine("Press any key to attempt a dunk");
                Console.ReadKey();
                DunkTheBall(dunkStyle);
                if (dunkStyle == "1"){
                    System.Console.WriteLine("\nSlam Dunk!\nPress any key to see what score the judges awarded you\n");
                    Console.ReadKey();
                    System.Console.WriteLine("Score: 10");
                } else if (dunkStyle == "2"){
                    System.Console.WriteLine("\nSlam Dunk!\nPress any key to see what score the judges awarded you\n");
                    Console.ReadKey();
                    System.Console.WriteLine("Score: 9.5");
                } else if (dunkStyle == "3"){
                    System.Console.WriteLine("\nSlam Dunk!\nPress any key to see what score the judges awarded you\n");
                    Console.ReadKey();
                    System.Console.WriteLine("Score: 9");
                } else if (dunkStyle == "4"){
                    System.Console.WriteLine("\nSlam Dunk!\nPress any key to see what score the judges awarded you\n");
                    Console.ReadKey();
                    System.Console.WriteLine("Score: 8.5");
                } else if (dunkStyle == "5"){
                    System.Console.WriteLine("\nSlam Dunk!\nPress any key to see what score the judges awarded you\n");
                    Console.ReadKey();
                    System.Console.WriteLine("Score: 8");
                } else if (dunkStyle == "6"){
                    System.Console.WriteLine("\nSlam Dunk!\nPress any key to see what score the judges awarded you\n");
                    Console.ReadKey();
                    System.Console.WriteLine("Score: 7.5");
                } else if (dunkStyle == "7"){
                    System.Console.WriteLine("\nSlam Dunk!\nPress any key to see what score the judges awarded you\n");
                    Console.ReadKey();
                    System.Console.WriteLine("Score: 7");
                } else System.Console.WriteLine("\nSomething went wrong");
            }

            Console.ReadKey();
            
        }

        // displays the ascii art for the dunk you choose to do
        private void DunkTheBall(string dunkStyle){
            StreamReader inFile = new StreamReader("dunkcontest" + dunkStyle + ".txt");
            string line = inFile.ReadLine();
            while(line != null){
                System.Console.WriteLine(line);
                line = inFile.ReadLine();
            }

            inFile.Close();
        }


        // allows you to choose to do weight lifitng or cardio and displayed the appropiate ascii art
        private void Exercise(){
            Console.Clear();

            System.Console.WriteLine("What type of workout would you like to complete?");
            System.Console.WriteLine("1. Weight Lifing\n2. Cardio");

            string response = Console.ReadLine();

            if (response.ToUpper() == "1" || response.ToUpper() == "WEIGHT LIFTING"){
                StreamReader inFile = new StreamReader("deadlift.txt");
                string line = inFile.ReadLine();
                while(line!=null){
                    System.Console.WriteLine(line);
                    line = inFile.ReadLine();
                }

                inFile.Close();

                System.Console.WriteLine("Nice workout! You're looking strong!");

            } else if (response.ToUpper() == "2" || response.ToUpper() == "CARDIO"){
                StreamReader inFile = new StreamReader("cycling.txt");
                string line = inFile.ReadLine();
                while(line!=null){
                    System.Console.WriteLine(line);
                    line = inFile.ReadLine();
                }

                inFile.Close();

                System.Console.WriteLine("Nice workout! Cardiovascular endurance is key!");
            }

            Console.ReadKey();
        }

        // choose who you want to play against, MJ is the hardes to beat
        private void oneVSone(){
            Console.Clear();

            System.Console.WriteLine("Who would you like to play 1v1 against?");
            System.Console.WriteLine("1. Zach Lavine\n2. DeMar DeRozan\n3. Michael Jordan");

            string response = Console.ReadLine();
            Random rnd = new Random();
            int difficulty = -1;

            if (response.ToUpper() == "1" || response.ToUpper() == "ZACH LAVINE"){
                ShowGraphic();
                difficulty = rnd.Next(1,100);
                if (difficulty < 10){
                    System.Console.WriteLine("You lost the game :(");
                } else{
                    System.Console.WriteLine("You beat Zach Lavine!");
                }
            } else if (response.ToUpper() == "2" || response.ToUpper() == "DEMAR DEROZAN"){
                ShowGraphic();
                difficulty = rnd.Next(1,100);
                if (difficulty < 40){
                    System.Console.WriteLine("You lost the game :(");
                } else{
                    System.Console.WriteLine("You beat DeMar DeRozan!");
                }
            } else if (response.ToUpper() == "3" || response.ToUpper() == "MICHAEL JORDAN"){
                ShowGraphic();
                difficulty = rnd.Next(1,100);
                if (difficulty < 90){
                    System.Console.WriteLine("You lost the game :(");
                } else{
                    System.Console.WriteLine("You beat Michael Jordn! Please come speak to the creater of this app, he would like to offer you a cookie.");
                }
            }

            Console.ReadKey();
        }


        // shows the 1v1 ascii graphic
        private void ShowGraphic(){
            StreamReader inFile = new StreamReader("onevone.txt");
            string line = inFile.ReadLine();
            while (line!=null){
                System.Console.WriteLine(line);
                line = inFile.ReadLine();
            }

            inFile.Close();
        }

        // sets booking to cancelled
        private void CancelAppointment(){
            System.Console.WriteLine("What is the ID of the session you want to cancel?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if (foundIndex != -1){
                bookings[foundIndex].SetStatus("cancelled");
                Save2();
            } else System.Console.WriteLine("Session not found");     
        }

        // sets booking to cancelled
        private void NoShowAppointment(){
            System.Console.WriteLine("What is the ID of the session you've decided not to show up to?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if (foundIndex != -1){
                bookings[foundIndex].SetStatus("no-show");
                Save2();
            } else System.Console.WriteLine("Session not found");

            System.Console.WriteLine("Not showing up to something you said you'd be there for is shameful--- side eye");
            Console.ReadKey();
        }


    }
}