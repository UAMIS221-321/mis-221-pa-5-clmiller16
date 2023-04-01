using mis_221_pa_5_clmiller16;

// Trainer jeff = new Trainer(7, "jeff", "123 dirt road", "jefflucas@ua.edu");
// System.Console.WriteLine(jeff.GetTrainerAddress());


Console.Clear();

Trainer[] trainers = new Trainer[50];
TrainerUtility utility = new TrainerUtility(trainers);
TrainerReport report = new TrainerReport(trainers);

utility.GetAllTrainersFromFile();

System.Console.WriteLine("raw file:");
report.PrintAllTrainers();

System.Console.WriteLine();
utility.UpdateTrainer();

System.Console.WriteLine("\n new file:");
report.PrintAllTrainers();


// System.Console.WriteLine("\n\n");



// System.Console.WriteLine("sorted:");
// report.IDByEmail();