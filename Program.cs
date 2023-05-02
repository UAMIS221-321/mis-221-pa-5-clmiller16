using mis_221_pa_5_clmiller16;
Console.Clear();

Console.CursorVisible = true;

//displays a black and red Chicago Bulls Logo
StreamReader inFile = new StreamReader("bulls.txt");
string line = inFile.ReadLine();
while (line != null){
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.BackgroundColor = ConsoleColor.Black;
    System.Console.WriteLine(line);
    line = inFile.ReadLine();
}

Console.ResetColor();

inFile.Close();

System.Console.WriteLine("\nWelcome to Train Like a Champion- The Exclusive Trainers for the Chicago Bulls! \n\nAre you a customer or a trainer?");
string currentUser = Console.ReadLine();
if(currentUser == "t"){ // checks if a trainer using app
    currentUser = "trainer";
}
if(currentUser == "c"){ //checks if a customer using app
    currentUser = "customer";
}
while (currentUser.ToUpper() != "TRAINER" && currentUser.ToUpper() != "CUSTOMER"){ // must either enter a trainer or customer
    System.Console.WriteLine("**Please enter either customer or trainer**");
    currentUser = Console.ReadLine();
}

if (currentUser.ToUpper() == "TRAINER"){
    System.Console.WriteLine("What is your password?"); // password validation for trainers
    string password = Console.ReadLine();
    string contents = File.ReadAllText("passwords.txt");
    while (!contents.Contains(password)) // checks if the password entered is in the passwords file
    {
        System.Console.WriteLine("Incorrect Password- Please try again");
        password = Console.ReadLine();
    }

    System.Console.WriteLine("\nACCESS GRANTED");
    Console.ReadKey();
}

//Main Menu
int selectedIndex = Run("main");
while (selectedIndex != 4){
    Route(selectedIndex, currentUser);
    selectedIndex = Run("main");
}


// arrow key menu system
static int Run(string menuVersion){

    int selectedIndex = 0;

    Console.CursorVisible = false;

    string[] options = GetMenuVersion(menuVersion);

    int length = options.Length;
    ConsoleKey keyPressed;
    do{
        Console.Clear();
        DisplayOptions(ref selectedIndex, options, menuVersion);
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        keyPressed = keyInfo.Key;

        if (keyPressed == ConsoleKey.UpArrow){
            selectedIndex--;

            if (selectedIndex == -1){
                selectedIndex = length - 1;
            }

        } else if (keyPressed == ConsoleKey.DownArrow){
            selectedIndex++;

            if (selectedIndex == length){
                selectedIndex = 0; 
            }
        }


    } while (keyPressed != ConsoleKey.Enter);



    return selectedIndex;
}

// different menu options stored in an array for the arrow key menu system
static string[] GetMenuVersion(string menuVersion){
    if (menuVersion == "main"){
        string[] options = {"1:   Trainer Info    ", "2:   Session Listings", "3:   Bookings        ", "4:   Run Reports     ", "5:   Exit App        "};
        return options;
    } else if (menuVersion == "trainer"){
        string[] options = {"1:   Add Trainer", "2:   Edit Trainer", "3:   Delete Trainer", "4:   Exit" };
        return options;
    } else if (menuVersion == "listing"){
        string[] options = {"1:   Add Listing", "2:   Edit Listing", "3:   Delete Listing", "4:   Exit"};
        // DisplayListingMenu();


        return options;
    } else if (menuVersion == "booking"){
        string[] options = {"1:   View All Available Sessions", "2:   View Sessions For Trainer", "3:   Book a Session", "4:   Complete/Cancel/No-Show", "5:   Exit"};
        return options;
    } else if (menuVersion == "report"){
        string[] options = {"1:   Individual Customer Sessions", "2:   Historical Customer Sessions", "3:   Historical Revenue Report", "4:   Monthly Revenue Report", "5:   Yearly Revenue Report", "6:   View All Customer Data", "7:   Exit"};
        return options;
    } else if (menuVersion == "bookingsubmenu"){
        string[] options = {"1:    Complete an Appointment", "2:    Cancel an Appointment", "3:    No-Show an Appointment", "4:    Exit"};
        return options;
    } else {
        string[] options = {"string"};
        return options;
    }
}

//displays the options for arrow key menu system
static void DisplayOptions(ref int selectedIndex, string[] options, string menuVersion){

    for (int i = 0; i < options.Length; i++){
        string currentOption = options[i];
        string prefix;

        if (i == selectedIndex){ // highlights the selected menu choice
            prefix = " ";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
        } else {
            prefix =  " ";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.White;
        }

        System.Console.WriteLine($"{prefix} << {currentOption} >>");
    }
    Console.ResetColor();

    // displays the content either in the trainers or listings file while in the trainer or listing arrowkey menu
    if (menuVersion == "listing"){
        DisplayListingMenu();
    } else if (menuVersion == "trainer"){
        DisplayTrainerMenu();
    }


}

if (currentUser.ToUpper() != "TRAINER"){ //displays a lifter ascii for trainers upon exit
    StreamReader inFile2 = new StreamReader("lifter.txt");
    string line2 = inFile2.ReadLine();
    while (line2 != null){
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.BackgroundColor = ConsoleColor.White;
        System.Console.WriteLine(line2);
        line2 = inFile2.ReadLine();
    }

    inFile2.Close();

    Console.ResetColor();

    //System.Console.WriteLine("___________________________________________________________________");
    Console.Write("                               ");
    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.ForegroundColor = ConsoleColor.Black;
    System.Console.WriteLine("                     Maybe you will be as strong as Arnold one day                     ");
    Console.ResetColor();
    //System.Console.WriteLine("___________________________________________________________________\n");

    Console.CursorVisible = true;
} else { 
    StreamReader inFile2 = new StreamReader("basketball.txt"); // displays a basketball ascii for customers
        string line2 = inFile2.ReadLine();
        while (line2 != null){
            Console.ResetColor();
            // Console.ForegroundColor = ConsoleColor.Black;
            // Console.BackgroundColor = ConsoleColor.White;
            System.Console.WriteLine(line2);
            line2 = inFile2.ReadLine();
        }

        inFile2.Close();

        Console.ResetColor();

        //System.Console.WriteLine("___________________________________________________________________");
        Console.Write("                               ");
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.Black;
        System.Console.WriteLine("\n                     Tell All Your Trainer Friends To Join The App!                     ");
        Console.ResetColor();
        //System.Console.WriteLine("___________________________________________________________________\n");

        Console.CursorVisible = true;    
}




//NOT USED- WAS FOR OLD MENU SYSTEM
// static string GetMenuChoice(){
//     DisplayMenu();
//     string userInput = Console.ReadLine();

//     while (!ValidMenuChoice(userInput)){
//         Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
//         Console.WriteLine("Press any key to continue....");
//         Console.ReadKey();

//         DisplayMenu();
//         userInput = Console.ReadLine();
//     }

//     return userInput;
// }


// static void DisplayMenu(){
//     Console.Clear();
//     Console.WriteLine("1:   Trainer Info");
//     Console.WriteLine("2:   Session Listings");
//     Console.WriteLine("3:   Bookings");
//     Console.WriteLine("4:   Run Reports");
//     Console.WriteLine("5:   Exit App");
// }

// static bool ValidMenuChoice(string userInput){
//     if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5"){
//         return true;
//     } else return false;
// }

// for main menu 
static void Route(int userInput, string currentUser){

    if (userInput == 0){
        ManageTrainers(currentUser);
    } else if (userInput == 1){
        ManageListings(currentUser);
    } else if (userInput == 2){
        ManageBookings(currentUser);
    } else {
        RunReports(currentUser);
    }
}

// MANAGE TRAINERS
static void ManageTrainers(string currentUser){

    if (currentUser.ToUpper() == "TRAINER"){ // only allows trainers to use this part of the app
        int selectedIndex = Run("trainer"); // arrow key menu system 
        while (selectedIndex != 3){
            RouteTrainer(selectedIndex);
            selectedIndex = Run("trainer");
        }
    } else{
        System.Console.WriteLine("\nYou do not have access to this\n");
        System.Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

}

// static string GetTrainerChoice(){
//     DisplayTrainerMenu();
//     string userInput = Console.ReadLine();

//     while (!ValidMenuChoiceTrainer(userInput)){
//         Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
//         Console.WriteLine("Press any key to continue....");
//         Console.ReadKey();

//         DisplayTrainerMenu();
//         userInput = Console.ReadLine();
//     }

//     return userInput;
// }


// displays all the trainers while in the trainer menu
static void DisplayTrainerMenu(){
    // Console.Clear();
    // Console.WriteLine("1:   Add Trainer");
    // Console.WriteLine("2:   Edit Trainer");
    // Console.WriteLine("3:   Delete Trainer");
    // Console.WriteLine("4:   Exit");
    // System.Console.WriteLine();

    //Setup
    Trainer[] trainers = new Trainer[100];
    TrainerUtility utility = new TrainerUtility(trainers);
    utility.GetAllTrainersFromFile();
    int count = Trainer.GetCount();

    //Column Headers
    System.Console.WriteLine("\nTrainers:");
    (int left, int top) = Console.GetCursorPosition();
    Console.SetCursorPosition(0,top + 1);
    System.Console.WriteLine("Trainer ID");
    Console.SetCursorPosition(15, top + 1);
    System.Console.WriteLine("Trainer Name");
    Console.SetCursorPosition(35, top + 1);
    System.Console.WriteLine("Mailing Address");
    Console.SetCursorPosition(55, top + 1);
    System.Console.WriteLine("Trainer Email Address");

    (left, top) = Console.GetCursorPosition();
    int numSessionsPrinted = 0;
    for (int i = 0; i < count; i++){ // prints each trainer alligned under the appropiate column
        if (trainers[i].GetDeleted() == false){
            //System.Console.WriteLine(trainers[i].ToStringFormatted());
            Console.SetCursorPosition(0, top + numSessionsPrinted);
            System.Console.Write(trainers[i].GetID());
            Console.SetCursorPosition(15, top + numSessionsPrinted);
            System.Console.Write(trainers[i].GetName());
            Console.SetCursorPosition(35, top + numSessionsPrinted);
            System.Console.Write(trainers[i].GetAddress());
            Console.SetCursorPosition(55, top + numSessionsPrinted);
            System.Console.Write(trainers[i].GetEmail());
            
            numSessionsPrinted++;
        }
    }
    System.Console.WriteLine();

}

// static bool ValidMenuChoiceTrainer(string userInput){
//     if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4"){
//         return true;
//     } else return false;
// }

static void RouteTrainer(int userInput){

    Console.CursorVisible = true;

    if (userInput == 0){
        AddTrainer();
    } else if (userInput == 1){
        EditTrainer();
    } else{
        DeleteTrainer();
        // System.Console.WriteLine("delete trainer here");
        // Console.ReadKey();
    }
}

// to add a trainer
static void AddTrainer(){
    Trainer[] trainers = new Trainer[100];
    TrainerUtility utility = new TrainerUtility(trainers);
    TrainerReport report = new TrainerReport(trainers);

    utility.GetAllTrainersFromFile();

    int count = Trainer.GetCount();
    
    //Trainer.FindMaxID(trainers);

    // finds the max id
    int max = trainers[0].GetID();
    for (int i = 0; i < count; i++){
        if (trainers[i].GetID() > max){
            max = trainers[i].GetID();
        }
    }
    max++;


    utility.AddTrainer(max);
    utility.Save();

    System.Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}

// to edit a trainer
static void EditTrainer(){
    Trainer[] trainers = new Trainer[100];
    TrainerUtility utility = new TrainerUtility(trainers);
    TrainerReport report = new TrainerReport(trainers);

    utility.GetAllTrainersFromFile();
    utility.UpdateTrainer();
    
    //int index = utility.UpdateTrainer();
    // string name = utility.GetEditedTrainerName(index);

    System.Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}

// to delete a trainer
static void DeleteTrainer(){
    Trainer[] trainers = new Trainer[100];
    TrainerUtility utility = new TrainerUtility(trainers);
    TrainerReport report = new TrainerReport(trainers);
    utility.GetAllTrainersFromFile();

    Listing[] listings = new Listing[100];
    ListingUtility utility1 = new ListingUtility(listings);
    utility1.GetAllListingsFromFile();

    string trainerName = utility.DeleteTrainer();

    System.Console.WriteLine(trainerName);
    Console.ReadKey();


    utility1.DeleteListingsForTrainer(trainerName);

    utility1.Save();
    utility.Save(); 
}

// _____________________________________________________________________
// _____________________________________________________________________
// _____________________________________________________________________
// _____________________________________________________________________
// _____________________________________________________________________
// _____________________________________________________________________

// checks if a trainer using the app, then routes to arrowkey menu system
static void ManageListings(string currentUser){
    if (currentUser.ToUpper() == "TRAINER"){
        int selectedIndex = Run("listing");
        while (selectedIndex != 3){
            RouteListing(selectedIndex);
            selectedIndex = Run("listing");
        }    
    } else{
        System.Console.WriteLine("\nYou do not have access to this\n");
        System.Console.WriteLine("(Press any key to continue)");
        Console.ReadKey();
    }
}

// static string GetListingChoice(){
//     DisplayListingMenu();
//     string userInput = Console.ReadLine();

//     while (!ValidMenuChoiceTrainer(userInput)){
//         Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
//         Console.WriteLine("Press any key to continue....");
//         Console.ReadKey();

//         DisplayListingMenu();
//         userInput = Console.ReadLine();
//     }

//     return userInput;
// }

// displays all the listings while in the listing menu
static void DisplayListingMenu(){
    // Console.Clear();
    // Console.WriteLine("1:   Add Listing");
    // Console.WriteLine("2:   Edit Listing");
    // Console.WriteLine("3:   Delete Listing");
    // Console.WriteLine("4:   Exit");

    Listing[] listings = new Listing[100];
    ListingUtility utility = new ListingUtility(listings);
    utility.GetAllListingsFromFile();
    int count = Listing.GetCount();

    // displays column headers
    System.Console.WriteLine("\nListings:");
    (int left, int top) = Console.GetCursorPosition();
    Console.SetCursorPosition(0,top + 1);
    System.Console.WriteLine("Listing ID");
    Console.SetCursorPosition(15, top + 1);
    System.Console.WriteLine("Trainer Name");
    Console.SetCursorPosition(35, top + 1);
    System.Console.WriteLine("Date");
    Console.SetCursorPosition(55, top + 1);
    System.Console.WriteLine("Time");
    Console.SetCursorPosition(75, top + 1);
    System.Console.WriteLine("Cost ($)");
    Console.SetCursorPosition(85, top + 1);
    System.Console.WriteLine("Status");
    Console.SetCursorPosition(105, top + 1);
    System.Console.WriteLine("Trainer ID");

    // displays column content
    (left, top) = Console.GetCursorPosition();
    int numSessionsPrinted = 0;
    for (int i = 0; i < count; i++){
         if (listings[i].GetDeleted() == false){
            // System.Console.WriteLine(listings[i].ToStringFormatted());
            Console.SetCursorPosition(0, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetID());
            Console.SetCursorPosition(15, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetName());
            Console.SetCursorPosition(35, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetDate());
            Console.SetCursorPosition(55, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetTime());
            Console.SetCursorPosition(75, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetCost());
            Console.SetCursorPosition(85, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetTaken());
            Console.SetCursorPosition(105, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetTrainerID());
            
            numSessionsPrinted++;
         }
    }
    System.Console.WriteLine();
}

static void RouteListing(int userInput){

    Console.CursorVisible = true;

    if (userInput == 0){
        AddListing();
    } else if (userInput == 1){
        EditListing();
    } else{
        DeleteListing();
    }
}

// to add a listing
static void AddListing(){
    Listing[] listings = new Listing[100];
    ListingUtility utility = new ListingUtility(listings);
    ListingReport report = new ListingReport(listings);

    utility.GetAllListingsFromFile();

    int count = Listing.GetCount();

    int max = listings[0].GetID();
    for (int i = 0; i < count; i++){
        if (listings[i].GetID() > max){
            max = listings[i].GetID();
        }
    }
    max++;

    utility.AddListing(max);
    utility.Save();

    System.Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}

// to edit a listing
static void EditListing(){
    Listing[] listings = new Listing[100];
    ListingUtility utility = new ListingUtility(listings);
    ListingReport report = new ListingReport(listings);

    utility.GetAllListingsFromFile();
    utility.UpdateListing();

    System.Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}

// to delete a listing
static void DeleteListing(){
    Listing[] listings = new Listing[100];
    ListingUtility utility = new ListingUtility(listings);
    ListingReport report = new ListingReport(listings);

    utility.GetAllListingsFromFile();
    utility.DeleteListing();
    utility.Save(); 
}


// _______________________________________________________________________________

// checks if a trainer using the app then routes to arrowkey menu system
static void ManageBookings(string currentUser){
    if(currentUser.ToUpper() != "TRAINER"){
        int selectedIndex = Run("booking");
        while (selectedIndex != 4){
            RouteBooking(selectedIndex);
            selectedIndex = Run("booking");
        }   
    } else{
        System.Console.WriteLine("\nPlease re-enter the app as a customer");
        System.Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }
 
}

// static string GetBookingChoice(){
//     DisplayBookingMenu();
//     string userInput = Console.ReadLine();

//     while (!ValidMenuChoiceBooking(userInput)){
//         Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
//         Console.WriteLine("Press any key to continue....");
//         Console.ReadKey();

//         DisplayBookingMenu();
//         userInput = Console.ReadLine();
//     }

//     return userInput;
// }

// static bool ValidMenuChoiceBooking(string userInput){
//     if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5"){
//         return true;
//     } else return false;
// }

// static void DisplayBookingMenu(){
//     Console.Clear();
//     Console.WriteLine("1:   View All Available Sessions");
//     Console.WriteLine("2:   View Sessions By Trainer");
//     Console.WriteLine("3:   Book a Session");
//     Console.WriteLine("4:   Complete/Cancel a Session");
//     Console.WriteLine("5:   Exit");

//     Booking[] bookings = new Booking[100];
//     BookingUtility utility = new BookingUtility(bookings);
//     utility.GetAllBookingsFromFile();
//     int count = Booking.GetCount();

//     // System.Console.WriteLine("Sessions:");
//     // for (int i = 0; i < count; i++){
//     //     System.Console.WriteLine(bookings[i].ToStringFormatted());
//     // }
// }

static void RouteBooking(int userInput){

    Console.CursorVisible = true;

    if (userInput == 0){
        ViewAvailableSessionsCursorPosition();
    } else if (userInput == 1){
        ViewAvailableSessionsByTrainer();
    } else if (userInput == 2){
        BookASession();
    } else DoASession();
}

// static void ViewAvailableSessions(){
//     Listing[] listings = new Listing[100];
//     ListingUtility utility = new ListingUtility(listings);

//     utility.GetAllListingsFromFile();
//     int count = Listing.GetCount();

//     System.Console.WriteLine("\nAvailable Sessions:");
//     (int left, int top) = Console.GetCursorPosition();
//     Console.SetCursorPosition(0,top + 1);
//     System.Console.WriteLine("Session ID");
//     Console.SetCursorPosition(12, top + 1);
//     System.Console.WriteLine("Trainer Name");
//     for (int i = 0; i < count; i++){
//         if (listings[i].GetTaken() == "available"){
//             System.Console.WriteLine(listings[i].ToStringFormatted());
//         }
//     }

//     System.Console.WriteLine("Press any key to continue");
//     Console.ReadKey();
// }

// to view all the available sessions
static void ViewAvailableSessionsCursorPosition(){
    Listing[] listings = new Listing[100];
    ListingUtility utility = new ListingUtility(listings);

    utility.GetAllListingsFromFile();
    int count = Listing.GetCount();

    // column headers
    System.Console.WriteLine("\nAvailable Sessions:");
    (int left, int top) = Console.GetCursorPosition();
    Console.SetCursorPosition(0,top + 1);
    System.Console.WriteLine("Session ID");
    Console.SetCursorPosition(15, top + 1);
    System.Console.WriteLine("Trainer Name");
    Console.SetCursorPosition(35, top + 1);
    System.Console.WriteLine("Date");
    Console.SetCursorPosition(55, top + 1);
    System.Console.WriteLine("Time");
    Console.SetCursorPosition(75, top + 1);
    System.Console.WriteLine("Cost ($)");
    Console.SetCursorPosition(85, top + 1);
    System.Console.WriteLine("Status");
    Console.SetCursorPosition(105, top + 1);
    System.Console.WriteLine("Trainer ID");

    // column content
    (left, top) = Console.GetCursorPosition();
    int numSessionsPrinted = 0;
    for (int i = 0; i < count; i++){
        if (listings[i].GetTaken() == "available"){
            Console.SetCursorPosition(0, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetID());
            Console.SetCursorPosition(15, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetName());
            Console.SetCursorPosition(35, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetDate());
            Console.SetCursorPosition(55, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetTime());
            Console.SetCursorPosition(75, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetCost());
            Console.SetCursorPosition(85, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetTaken());
            Console.SetCursorPosition(105, top + numSessionsPrinted);
            System.Console.Write(listings[i].GetTrainerID());
            
            numSessionsPrinted++;
        }
    }

    System.Console.WriteLine("\n\nPress any key to continue");
    Console.ReadKey();
}

// view all the available sessions for a certain trainer
static void ViewAvailableSessionsByTrainer(){
    System.Console.WriteLine("Which trainer would you like to see the listings for?");
    string trainerName = Console.ReadLine();


    Listing[] listings = new Listing[100];
    ListingUtility utility = new ListingUtility(listings);

    utility.GetAllListingsFromFile();
    int count = Listing.GetCount();

    // column headers
    System.Console.WriteLine("\nAvailable Sessions:");
    (int left, int top) = Console.GetCursorPosition();
    Console.SetCursorPosition(0,top + 1);
    System.Console.WriteLine("Session ID");
    Console.SetCursorPosition(15, top + 1);
    System.Console.WriteLine("Trainer Name");
    Console.SetCursorPosition(35, top + 1);
    System.Console.WriteLine("Date");
    Console.SetCursorPosition(55, top + 1);
    System.Console.WriteLine("Time");
    Console.SetCursorPosition(75, top + 1);
    System.Console.WriteLine("Cost");
    Console.SetCursorPosition(85, top + 1);
    System.Console.WriteLine("Status");
    Console.SetCursorPosition(105, top + 1);
    System.Console.WriteLine("Trainer ID");

    // column content
    (left, top) = Console.GetCursorPosition();
    int numSessionsPrinted = 0;
    for (int i = 0; i < count; i++){
        if (listings[i].GetTaken() == "available" && listings[i].GetName() == trainerName){
            // System.Console.WriteLine(listings[i].ToStringFormatted());
            Console.SetCursorPosition(0, numSessionsPrinted + top);
            System.Console.Write(listings[i].GetID());
            Console.SetCursorPosition(15, numSessionsPrinted + top);
            System.Console.Write(listings[i].GetName());
            Console.SetCursorPosition(35, numSessionsPrinted + top);
            System.Console.Write(listings[i].GetDate());
            Console.SetCursorPosition(55, numSessionsPrinted + top);
            System.Console.Write(listings[i].GetTime());
            Console.SetCursorPosition(75, numSessionsPrinted + top);
            System.Console.Write(listings[i].GetCost());
            Console.SetCursorPosition(85, numSessionsPrinted + top);
            System.Console.Write(listings[i].GetTaken());
            Console.SetCursorPosition(105, numSessionsPrinted + top);
            System.Console.Write(listings[i].GetTrainerID());

            numSessionsPrinted++;

        }
    }

    System.Console.WriteLine("\n\nPress any key to continue");
    Console.ReadKey();
}

// to book a session
static void BookASession(){
    ViewAvailableSessionsCursorPosition();

    // Listing[] listings = new Listing[100];
    // ListingUtility utility1 = new ListingUtility(listings);
    // utility1.GetAllListingsFromFile();

    Booking[] bookings = new Booking[100];
    BookingUtility utility = new BookingUtility(bookings);
    utility.GetAllBookingsFromFile();
    int count = Booking.GetCount();

    Listing[] listings = new Listing[100];
    ListingUtility utility1 = new ListingUtility(listings);
    utility1.GetAllListingsFromFile();

    // System.Console.WriteLine("Which session ID would you like to book?");
    // int userInput = int.Parse(Console.ReadLine());

    // Listing[] listings = new Listing[100];
    // ListingUtility utility1 = new ListingUtility(listings);
    // utility1.GetAllListingsFromFile();

    // Trainer[] trainers = new Trainer[100];
    // TrainerUtility utility2 = new TrainerUtility(trainers);
    // utility2.GetAllTrainersFromFile();
    
    // int variable1 = listings[userInput].GetID();
    // string variable2 = listings[userInput].GetDate();
    // int variable3 = trainers[userInput].GetID();
    // string variable4 = listings[userInput].GetName();

    //status update needed

    System.Console.WriteLine("Which session ID would you like to book?");
    string stringUserInput = Console.ReadLine(); 

    utility.BookSession(stringUserInput);
    utility1.SetListingTaken(stringUserInput); // sets a listings to taken when you book it
    utility.Save();
    // utility1.Save();

    System.Console.WriteLine("Press any key to continue");
    Console.ReadKey();


}

// to add a booking
// static void AddBooking(){
//     Booking[] bookings = new Booking[100];
//     BookingUtility utility = new BookingUtility(bookings);
//     // BookingReport report = new BookingReport(bookings);

//     utility.GetAllBookingsFromFile();
//     utility.AddBooking();
//     utility.Save();

//     System.Console.WriteLine("Press any key to continue");
//     Console.ReadKey();
// }

// to edit a booking
// static void EditBooking(){
//     Booking[] bookings = new Booking[100];
//     BookingUtility utility = new BookingUtility(bookings);
//     // BookingReport report = new BookingReport(bookings);

//     utility.GetAllBookingsFromFile();
//     utility.UpdateBooking();

//     System.Console.WriteLine("Press any key to continue");
//     Console.ReadKey();
// }

// to complete/cancel/no-show
static void DoASession(){
    Booking[] bookings = new Booking[100];
    BookingUtility utility = new BookingUtility(bookings);

    utility.GetAllBookingsFromFile();
    
    int selectedIndex = Run("bookingsubmenu");
    while (selectedIndex!= 3){
        utility.CompleteOrCancel(selectedIndex);
        selectedIndex = Run("bookingsubmenu");
    }
    
    utility.Save2();
    

    // System.Console.WriteLine("Press any key to continue");
    // Console.ReadKey();
}


// static void ViewBookedSessions(){
//     Booking[] bookings = new Booking[100];
//     BookingUtility utility = new BookingUtility(bookings);

//     utility.GetAllBookingsFromFile();
//     int count = Booking.GetCount();

//     System.Console.WriteLine("\nBooked Sessions:");
//     for (int i = 0; i < count; i++){
//         if (bookings[i].GetStatus() == "booked"){
//             System.Console.WriteLine(bookings[i].ToStringFormatted());
//         }
//     }

//     System.Console.WriteLine("Press any key to continue");
//     Console.ReadKey();
// }

// static void DeleteListing(){
//     Listing[] listings = new Listing[100];
//     ListingUtility utility = new ListingUtility(listings);
//     ListingReport report = new ListingReport(listings);

//     utility.GetAllListingsFromFile();
//     utility.DeleteListing();
//     utility.Save(); 
// }


// Trainer jeff = new Trainer(7, "jeff", "123 dirt road", "jefflucas@ua.edu");
// System.Console.WriteLine(jeff.GetTrainerAddress());


// Console.Clear();

// Trainer[] trainers = new Trainer[100];
// TrainerUtility utility = new TrainerUtility(trainers);
// TrainerReport report = new TrainerReport(trainers);

// utility.GetAllTrainersFromFile();
// System.Console.WriteLine("raw file:");
// report.PrintAllTrainers();
// System.Console.WriteLine();
// utility.UpdateTrainer();
// System.Console.WriteLine("\n new file:");
// report.PrintAllTrainers();


// System.Console.WriteLine("\n\n");

// Listing[] listings = new Listing[100];
// ListingUtility utility1 = new ListingUtility(listings);
// ListingReport report1 = new ListingReport(listings);

// utility1.GetAllListingsFromFile();
// report1.PrintAllListings();




// System.Console.WriteLine("sorted:");
// report.IDByEmail();

//_________________________________________________________________________________________________________________________

// checks if a trainer using the app, then routes to arrowkey menu system
static void RunReports(string currentUser){
    if (currentUser.ToUpper() == "TRAINER"){
        int selectedIndex = Run("report");
        while (selectedIndex != 6){
            RouteReports(selectedIndex);
            selectedIndex = Run("report");
        }        
    } else {
        System.Console.WriteLine("\nYou do not have access to this\n");
        System.Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

}

// static string GetReportChoice(){
//     DisplayReportMenu();
//     string userInput = Console.ReadLine();

//     while (!ValidMenuChoiceReport(userInput)){
//         Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
//         Console.WriteLine("Press any key to continue....");
//         Console.ReadKey();

//         DisplayReportMenu();
//         userInput = Console.ReadLine();
//     }

//     return userInput;
// }

// static void DisplayReportMenu(){
//     Console.Clear();
//     Console.WriteLine("1:   Individual Customer Sessions");
//     Console.WriteLine("2:   Historical Customer Sessions");
//     Console.WriteLine("3:   Historical Revenue Report");
//     Console.WriteLine("4:   Monthly Revenue Report");
//     Console.WriteLine("5:   Yearly Revenue Report");
//     Console.WriteLine("6:   View All Customer Data");
//     Console.WriteLine("7:   Exit");
// }

// static bool ValidMenuChoiceReport(string userInput){
//     if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6" || userInput == "7"){
//         return true;
//     } else return false;
// }

static void RouteReports(int userInput){

    Console.CursorVisible = true;

    if (userInput == 0){
        IndividualCustomerSessions();
    } else if (userInput == 1){
        HistoricalCustomerSessions();
    } else if (userInput == 2){
        HistoricalRevenueReport();
    } else if (userInput == 3){
        MonthlyRevenueReport();
    } else if (userInput == 4){
        YearlyRevenueReport();
    } else ViewCustomerData();
}

// view all the sessions for a certain customer
static void IndividualCustomerSessions(){
    Booking[] bookings = new Booking[100];
    BookingUtility utility = new BookingUtility(bookings);
    BookingReport report = new BookingReport(bookings);

    utility.GetAllBookingsFromFile();
    utility.SortByEmail();
    
    // report.PrintAllBookings();
    report.SessionsForCustomer();

    System.Console.WriteLine("\npress any key to continue");
    Console.ReadKey();
}

// views everything in transactions.txt
static void ViewCustomerData(){

    Booking[] bookings = new Booking[100];
    BookingUtility utility = new BookingUtility(bookings);

    utility.GetAllBookingsFromFile();
    int count = Booking.GetCount();
    
    // column headers
    System.Console.WriteLine("\nCustomer Sessions Data:");
    (int left, int top) = Console.GetCursorPosition();
    Console.SetCursorPosition(0,top + 1);
    System.Console.WriteLine("Session ID");
    Console.SetCursorPosition(15, top + 1);
    System.Console.WriteLine("Customer Name");
    Console.SetCursorPosition(35, top + 1);
    System.Console.WriteLine("Customer Email");
    Console.SetCursorPosition(55, top + 1);
    System.Console.WriteLine("Date");
    Console.SetCursorPosition(75, top + 1);
    System.Console.WriteLine("Trainer ID");
    Console.SetCursorPosition(90, top + 1);
    System.Console.WriteLine("Trainer Name");
    Console.SetCursorPosition(110, top + 1);
    System.Console.WriteLine("Status");

    // column content
    (left, top) = Console.GetCursorPosition();
    int numSessionsPrinted = 0;
    for (int i = 0; i < count; i++){
        // System.Console.WriteLine(bookings[i].ToStringFormatted());

            Console.SetCursorPosition(0, numSessionsPrinted + top);
            System.Console.Write(bookings[i].GetSessionID());
            Console.SetCursorPosition(15, numSessionsPrinted + top);
            System.Console.Write(bookings[i].GetCustomerName());
            Console.SetCursorPosition(35, numSessionsPrinted + top);
            System.Console.Write(bookings[i].GetCustomerEmail());
            Console.SetCursorPosition(55, numSessionsPrinted + top);
            System.Console.Write(bookings[i].GetTrainingDate());
            Console.SetCursorPosition(75, numSessionsPrinted + top);
            System.Console.Write(bookings[i].GetTrainerID());
            Console.SetCursorPosition(90, numSessionsPrinted + top);
            System.Console.Write(bookings[i].GetTrainerName());
            Console.SetCursorPosition(110, numSessionsPrinted + top);
            System.Console.Write(bookings[i].GetStatus());

            numSessionsPrinted++;
    }

    System.Console.WriteLine("\n(Press any key to continue)");
    Console.ReadKey();
}


// sessions sorted by date
static void HistoricalCustomerSessions(){
    Booking[] bookings = new Booking[100];
    BookingUtility utility = new BookingUtility(bookings);
    BookingReport report = new BookingReport(bookings);

    utility.GetAllBookingsFromFile();
    int count = Booking.GetCount();

    utility.GetAllBookingsFromFile();
    utility.SortByCustomerNameThenByDate();

    // column headers
    System.Console.WriteLine("\nSessions by Customer then by Date:");
    (int left, int top) = Console.GetCursorPosition();
    Console.SetCursorPosition(0,top + 1);
    System.Console.WriteLine("Session ID");
    Console.SetCursorPosition(15, top + 1);
    System.Console.WriteLine("Customer Name");
    Console.SetCursorPosition(35, top + 1);
    System.Console.WriteLine("Customer Email");
    Console.SetCursorPosition(55, top + 1);
    System.Console.WriteLine("Date");
    Console.SetCursorPosition(75, top + 1);
    System.Console.WriteLine("Trainer ID");
    Console.SetCursorPosition(90, top + 1);
    System.Console.WriteLine("Trainer Name");
    Console.SetCursorPosition(110, top + 1);
    System.Console.WriteLine("Status");

    // column content
    (left, top) = Console.GetCursorPosition();
    int numSessionsPrinted = 0;
    for (int i = 0; i < Booking.GetCount(); i++){
        //System.Console.WriteLine(bookings[i].ToStringFormatted());

        Console.SetCursorPosition(0, numSessionsPrinted + top);
        System.Console.Write(bookings[i].GetSessionID());
        Console.SetCursorPosition(15, numSessionsPrinted + top);
        System.Console.Write(bookings[i].GetCustomerName());
        Console.SetCursorPosition(35, numSessionsPrinted + top);
        System.Console.Write(bookings[i].GetCustomerEmail());
        Console.SetCursorPosition(55, numSessionsPrinted + top);
        System.Console.Write(bookings[i].GetTrainingDate());
        Console.SetCursorPosition(75, numSessionsPrinted + top);
        System.Console.Write(bookings[i].GetTrainerID());
        Console.SetCursorPosition(90, numSessionsPrinted + top);
        System.Console.Write(bookings[i].GetTrainerName());
        Console.SetCursorPosition(110, numSessionsPrinted + top);
        System.Console.Write(bookings[i].GetStatus());

        numSessionsPrinted++;
    }

    System.Console.WriteLine("\n\n# of Sessions Booked Per Customer:");
    report.SessionsPerCustomer();

    System.Console.WriteLine("\n(Press any key to continue)");
    Console.ReadKey();
}

// revenu by month and year
static void HistoricalRevenueReport(){
    Booking[] bookings = new Booking[100];
    BookingUtility utility = new BookingUtility(bookings);
    BookingReport report = new BookingReport(bookings);

    utility.GetAllBookingsFromFile();
    int count = Booking.GetCount();

    utility.SortByDate();

    //System.Console.WriteLine("MONTHLY REPORT");
    //report.RevenueByMonth();

    System.Console.WriteLine("\n\nMONTH AND YEAR REPORT");
    report.RevenueByMonthAndYear();
    //report.RevenueByYear();
    //report.RevenueByMonth();

    System.Console.WriteLine("\nPress any key to continue");
    Console.ReadKey();
}

// revenue by month
static void MonthlyRevenueReport(){
    Booking[] bookings = new Booking[100];
    BookingUtility utility = new BookingUtility(bookings);
    BookingReport report = new BookingReport(bookings);

    utility.GetAllBookingsFromFile();
    int count = Booking.GetCount();

    utility.SortByDate();

    //System.Console.WriteLine("MONTHLY REPORT");
    report.RevenueByMonth();

    //System.Console.WriteLine("\n\nMONTH AND YEAR REPORT");
    //report.RevenueByMonthAndYear();
    //report.RevenueByYear();
    //report.RevenueByMonth();

    System.Console.WriteLine("\nPress any key to continue");
    Console.ReadKey();
}

// revenue by year
static void YearlyRevenueReport(){
    Booking[] bookings = new Booking[100];
    BookingUtility utility = new BookingUtility(bookings);
    BookingReport report = new BookingReport(bookings);

    utility.GetAllBookingsFromFile();
    int count = Booking.GetCount();

    utility.SortByDate();

    //System.Console.WriteLine("MONTHLY REPORT");
    //report.RevenueByMonth();

    //System.Console.WriteLine("\n\nMONTH AND YEAR REPORT");
    //report.RevenueByMonthAndYear();
    report.RevenueByYear();
    //report.RevenueByMonth();

    System.Console.WriteLine("\nPress any key to continue");
    Console.ReadKey();
}