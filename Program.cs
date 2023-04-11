﻿using mis_221_pa_5_clmiller16;

string userInput = GetMenuChoice();
while (userInput != "5"){
    Route(userInput);
    userInput = GetMenuChoice();
}


// methods
static string GetMenuChoice(){
    DisplayMenu();
    string userInput = Console.ReadLine();

    while (!ValidMenuChoice(userInput)){
        Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
        Console.WriteLine("Press any key to continue....");
        Console.ReadKey();

        DisplayMenu();
        userInput = Console.ReadLine();
    }

    return userInput;
}

static void DisplayMenu(){
    Console.Clear();
    Console.WriteLine("1:   Manage Trainers");
    Console.WriteLine("2:   Manage Listings");
    Console.WriteLine("3:   Manage Bookings");
    Console.WriteLine("4:   Run Reports");
    Console.WriteLine("5:   Exit App");
}

static bool ValidMenuChoice(string userInput){
    if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5"){
        return true;
    } else return false;
}

static void Route(string userInput){

    if (userInput == "1"){
        ManageTrainers();
    } else if (userInput == "2"){
        ManageListings();
    } else if (userInput == "3"){
        ManageBookings();
    } else if (userInput == "4"){
        System.Console.WriteLine("YOU ARE INSIDE 4");
        Console.ReadKey();
    } else if (userInput == "5"){
        System.Console.WriteLine("YOU ARE INSIDE 5");
        Console.ReadKey();
    } else{
        System.Console.WriteLine("YOU ARE INSIDE 6");
        Console.ReadKey();
    }
}

// MANAGE TRAINERS
static void ManageTrainers(){
    string userInput = GetTrainerChoice();
    while (userInput != "4"){
        RouteTrainer(userInput);
        userInput = GetTrainerChoice();
    }
}

static string GetTrainerChoice(){
    DisplayTrainerMenu();
    string userInput = Console.ReadLine();

    while (!ValidMenuChoiceTrainer(userInput)){
        Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
        Console.WriteLine("Press any key to continue....");
        Console.ReadKey();

        DisplayTrainerMenu();
        userInput = Console.ReadLine();
    }

    return userInput;
}

static void DisplayTrainerMenu(){
    Console.Clear();
    Console.WriteLine("1:   Add Trainer");
    Console.WriteLine("2:   Edit Trainer");
    Console.WriteLine("3:   Delete Trainer");
    Console.WriteLine("4:   Exit");
    System.Console.WriteLine();

    Trainer[] trainers = new Trainer[50];
    TrainerUtility utility = new TrainerUtility(trainers);
    utility.GetAllTrainersFromFile();
    int count = Trainer.GetCount();
    System.Console.WriteLine("\nTrainers:");
    for (int i = 0; i < count; i++){
        if (trainers[i].GetDeleted() == false){
            System.Console.WriteLine(trainers[i].ToStringFormatted());
        }
    }

}

static bool ValidMenuChoiceTrainer(string userInput){
    if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4"){
        return true;
    } else return false;
}

static void RouteTrainer(string userInput){

    if (userInput == "1"){
        AddTrainer();
    } else if (userInput == "2"){
        EditTrainer();
    } else{
        DeleteTrainer();
        // System.Console.WriteLine("delete trainer here");
        // Console.ReadKey();
    }
}

static void AddTrainer(){
    Trainer[] trainers = new Trainer[50];
    TrainerUtility utility = new TrainerUtility(trainers);
    TrainerReport report = new TrainerReport(trainers);

    utility.GetAllTrainersFromFile();

    int count = Trainer.GetCount();
    
    //Trainer.FindMaxID(trainers);

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

static void EditTrainer(){
    Trainer[] trainers = new Trainer[50];
    TrainerUtility utility = new TrainerUtility(trainers);
    TrainerReport report = new TrainerReport(trainers);

    utility.GetAllTrainersFromFile();
    utility.UpdateTrainer();

    System.Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}

static void DeleteTrainer(){
    Trainer[] trainers = new Trainer[50];
    TrainerUtility utility = new TrainerUtility(trainers);
    TrainerReport report = new TrainerReport(trainers);

    utility.GetAllTrainersFromFile();
    utility.DeleteTrainer();
    utility.Save(); 
}

// _____________________________________________________________________

static void ManageListings(){
    string userInput = GetListingChoice();
    while (userInput != "4"){
        RouteListing(userInput);
        userInput = GetListingChoice();
    }    
}

static string GetListingChoice(){
    DisplayListingMenu();
    string userInput = Console.ReadLine();

    while (!ValidMenuChoiceTrainer(userInput)){
        Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
        Console.WriteLine("Press any key to continue....");
        Console.ReadKey();

        DisplayListingMenu();
        userInput = Console.ReadLine();
    }

    return userInput;
}

static void DisplayListingMenu(){
    Console.Clear();
    Console.WriteLine("1:   Add Listing");
    Console.WriteLine("2:   Edit Listing");
    Console.WriteLine("3:   Delete Listing");
    Console.WriteLine("4:   Exit");

    Listing[] listings = new Listing[50];
    ListingUtility utility = new ListingUtility(listings);
    utility.GetAllListingsFromFile();
    int count = Listing.GetCount();

    System.Console.WriteLine("\nListings:");
    for (int i = 0; i < count; i++){
         if (listings[i].GetDeleted() == false){
            System.Console.WriteLine(listings[i].ToStringFormatted());
         }
    }
}

static void RouteListing(string userInput){

    if (userInput == "1"){
        AddListing();
    } else if (userInput == "2"){
        EditListing();
    } else{
        DeleteListing();
    }
}

static void AddListing(){
    Listing[] listings = new Listing[50];
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

static void EditListing(){
    Listing[] listings = new Listing[50];
    ListingUtility utility = new ListingUtility(listings);
    ListingReport report = new ListingReport(listings);

    utility.GetAllListingsFromFile();
    utility.UpdateListing();

    System.Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}

static void DeleteListing(){
    Listing[] listings = new Listing[50];
    ListingUtility utility = new ListingUtility(listings);
    ListingReport report = new ListingReport(listings);

    utility.GetAllListingsFromFile();
    utility.DeleteListing();
    utility.Save(); 
}


// _______________________________________________________________________________

static void ManageBookings(){
    string userInput = GetBookingChoice();
    while (userInput != "3"){
        RouteBooking(userInput);
        userInput = GetBookingChoice();
    }    
}

static string GetBookingChoice(){
    DisplayBookingMenu();
    string userInput = Console.ReadLine();

    while (!ValidMenuChoiceBooking(userInput)){
        Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
        Console.WriteLine("Press any key to continue....");
        Console.ReadKey();

        DisplayBookingMenu();
        userInput = Console.ReadLine();
    }

    return userInput;
}

static bool ValidMenuChoiceBooking(string userInput){
    if (userInput == "1" || userInput == "2" || userInput == "3"){
        return true;
    } else return false;
}

static void DisplayBookingMenu(){
    Console.Clear();
    Console.WriteLine("1:   View Available Sessions");
    Console.WriteLine("2:   Book a Session");
    Console.WriteLine("3:   Exit");

    Booking[] bookings = new Booking[50];
    BookingUtility utility = new BookingUtility(bookings);
    utility.GetAllBookingsFromFile();
    int count = Booking.GetCount();

    // System.Console.WriteLine("Sessions:");
    // for (int i = 0; i < count; i++){
    //     System.Console.WriteLine(bookings[i].ToStringFormatted());
    // }
}

static void RouteBooking(string userInput){

    if (userInput == "1"){
        ViewAvailableSessions();
    } else {
        BookASession();
    }
}



static void ViewAvailableSessions(){

    Booking[] bookings = new Booking[50];
    BookingUtility utility = new BookingUtility(bookings);

    utility.GetAllBookingsFromFile();
    int count = Booking.GetCount();
    

    System.Console.WriteLine("\nSessions:");
    for (int i = 0; i < count; i++){
        System.Console.WriteLine(bookings[i].ToStringFormatted());
    }

    System.Console.WriteLine("\n(Press any key to continue)");
    Console.ReadKey();
}


static void BookASession(){

}







static void AddBooking(){
    Booking[] bookings = new Booking[50];
    BookingUtility utility = new BookingUtility(bookings);
    // BookingReport report = new BookingReport(bookings);

    utility.GetAllBookingsFromFile();
    utility.AddBooking();
    utility.Save();

    System.Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}

static void EditBooking(){
    Booking[] bookings = new Booking[50];
    BookingUtility utility = new BookingUtility(bookings);
    // BookingReport report = new BookingReport(bookings);

    utility.GetAllBookingsFromFile();
    utility.UpdateBooking();

    System.Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}

// static void DeleteListing(){
//     Listing[] listings = new Listing[50];
//     ListingUtility utility = new ListingUtility(listings);
//     ListingReport report = new ListingReport(listings);

//     utility.GetAllListingsFromFile();
//     utility.DeleteListing();
//     utility.Save(); 
// }
















// Trainer jeff = new Trainer(7, "jeff", "123 dirt road", "jefflucas@ua.edu");
// System.Console.WriteLine(jeff.GetTrainerAddress());


// Console.Clear();

// Trainer[] trainers = new Trainer[50];
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

// Listing[] listings = new Listing[50];
// ListingUtility utility1 = new ListingUtility(listings);
// ListingReport report1 = new ListingReport(listings);

// utility1.GetAllListingsFromFile();
// report1.PrintAllListings();




// System.Console.WriteLine("sorted:");
// report.IDByEmail();