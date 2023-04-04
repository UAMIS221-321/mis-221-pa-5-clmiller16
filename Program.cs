using mis_221_pa_5_clmiller16;

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
    Console.WriteLine("5:   Exit Game");
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
        System.Console.WriteLine("YOU ARE INSIDE 2");
        Console.ReadKey();
    } else if (userInput == "3"){
        System.Console.WriteLine("YOU ARE INSIDE 3");
        Console.ReadKey();
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
        System.Console.WriteLine("delete trainer here");
        Console.ReadKey();
    }
}

static void AddTrainer(){
    Trainer[] trainers = new Trainer[50];
    TrainerUtility utility = new TrainerUtility(trainers);
    TrainerReport report = new TrainerReport(trainers);

    utility.GetAllTrainersFromFile();
    utility.AddTrainer();
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