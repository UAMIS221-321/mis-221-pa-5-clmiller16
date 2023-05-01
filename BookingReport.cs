namespace mis_221_pa_5_clmiller16
{
    public class BookingReport
    {
        Booking[] bookings;

        public BookingReport(Booking[] bookings){
            this.bookings = bookings;
        }

        public void PrintAllBookings(){
            System.Console.WriteLine();
            for (int i = 0; i < Booking.GetCount(); i++){
                System.Console.WriteLine(bookings[i].ToStringFormatted());
            }
        }

        public void SessionsForCustomer(){

            System.Console.WriteLine("What was the customer email?");
            string email = Console.ReadLine();

            // string curr = bookings[0].GetCustomerEmail();

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

            (left, top) = Console.GetCursorPosition();
            int numSessionsPrinted = 0;
            for (int i = 0; i < Booking.GetCount(); i++){
                if (bookings[i].GetCustomerEmail() == email){
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
            }
            System.Console.WriteLine("\nWould you like to save this report to a file?");
            string response = Console.ReadLine();
            if (response.ToUpper() == "YES"){
                System.Console.WriteLine("What is the name of the file you want to save it to?");
                string fileName = Console.ReadLine();
                StreamWriter outFile = new StreamWriter(fileName);

                (left, top) = Console.GetCursorPosition();
                Console.SetCursorPosition(0,top + 1);
                outFile.WriteLine("Session ID");
                Console.SetCursorPosition(15, top + 1);
                outFile.WriteLine("Customer Name");
                Console.SetCursorPosition(35, top + 1);
                outFile.WriteLine("Customer Email");
                Console.SetCursorPosition(55, top + 1);
                outFile.WriteLine("Date");
                Console.SetCursorPosition(75, top + 1);
                outFile.WriteLine("Trainer ID");
                Console.SetCursorPosition(90, top + 1);
                outFile.WriteLine("Trainer Name");
                Console.SetCursorPosition(110, top + 1);
                outFile.WriteLine("Status");

                (left, top) = Console.GetCursorPosition();
                numSessionsPrinted = 0;
                for (int i = 0; i < Booking.GetCount(); i++){
                    if (bookings[i].GetCustomerEmail() == email){
                        //outFile.WriteLine(bookings[i].ToStringFormatted());

                        Console.SetCursorPosition(0, numSessionsPrinted + top);
                        outFile.Write(bookings[i].GetSessionID());
                        Console.SetCursorPosition(15, numSessionsPrinted + top);
                        outFile.Write(bookings[i].GetCustomerName());
                        Console.SetCursorPosition(35, numSessionsPrinted + top);
                        outFile.Write(bookings[i].GetCustomerEmail());
                        Console.SetCursorPosition(55, numSessionsPrinted + top);
                        outFile.Write(bookings[i].GetTrainingDate());
                        Console.SetCursorPosition(75, numSessionsPrinted + top);
                        outFile.Write(bookings[i].GetTrainerID());
                        Console.SetCursorPosition(90, numSessionsPrinted + top);
                        outFile.Write(bookings[i].GetTrainerName());
                        Console.SetCursorPosition(110, numSessionsPrinted + top);
                        outFile.Write(bookings[i].GetStatus());

                        numSessionsPrinted++;
                    }
                }

                outFile.Close();
            }
        }

        public void SessionsPerCustomer(){
            string curr = bookings[0].GetCustomerName();
            int count = 0;
            for (int i = 0; i < Booking.GetCount(); i++){
                if (bookings[i].GetCustomerName() == curr){
                    count ++;
                } else {
                    ProcessBreak(ref curr, ref count, bookings[i]);
                }
            }
            ProcessBreak(curr, count);

            System.Console.WriteLine("\nWould you like to save this report to a file?");
            string response = Console.ReadLine();
            if (response.ToUpper() == "YES"){
                System.Console.WriteLine("What is the name of the file you want to save it to?");
                string fileName = Console.ReadLine();

                StreamWriter outFile = new StreamWriter(fileName);

                outFile.WriteLine("\nSessions by Customer then by Date:");
                (int left, int top) = Console.GetCursorPosition();
                //Console.SetCursorPosition(0,top + 1);
                outFile.Write("Session ID\t");
                //Console.SetCursorPosition(15, top + 1);
                outFile.Write("Customer Name\t");
                //Console.SetCursorPosition(35, top + 1);
                outFile.Write("Customer Email\t");
                //Console.SetCursorPosition(55, top + 1);
                outFile.Write("Date\t");
                //Console.SetCursorPosition(75, top + 1);
                outFile.Write("Trainer ID\t");
                //Console.SetCursorPosition(90, top + 1);
                outFile.Write("Trainer Name\t");
                //Console.SetCursorPosition(110, top + 1);
                outFile.Write("Status\t");

                (left, top) = Console.GetCursorPosition();
                int numSessionsPrinted = 0;
                for (int i = 0; i < Booking.GetCount(); i++){
                    //outFile.WriteLine(bookings[i].ToStringFormatted());

                    //Console.SetCursorPosition(0, numSessionsPrinted + top);
                    outFile.WriteLine(bookings[i].GetSessionID());
                    //Console.SetCursorPosition(15, numSessionsPrinted + top);
                    outFile.WriteLine(bookings[i].GetCustomerName());
                    //Console.SetCursorPosition(35, numSessionsPrinted + top);
                    outFile.WriteLine(bookings[i].GetCustomerEmail());
                    //Console.SetCursorPosition(55, numSessionsPrinted + top);
                    outFile.WriteLine(bookings[i].GetTrainingDate());
                    //Console.SetCursorPosition(75, numSessionsPrinted + top);
                    outFile.WriteLine(bookings[i].GetTrainerID());
                    //Console.SetCursorPosition(90, numSessionsPrinted + top);
                    outFile.WriteLine(bookings[i].GetTrainerName());
                    //Console.SetCursorPosition(110, numSessionsPrinted + top);
                    outFile.WriteLine(bookings[i].GetStatus());

                    numSessionsPrinted++;
                }
                
                outFile.WriteLine();
                outFile.WriteLine("# of Sessions Booked Per Customer:");

                curr = bookings[0].GetCustomerName();
                count = 0;
                for (int i = 0; i < Booking.GetCount(); i++){
                    if (bookings[i].GetCustomerName() == curr){
                        count ++;
                    } else {
                        //ProcessBreakFile(ref curr, ref count, bookings[i]);
                        outFile.WriteLine($"{curr}: \t {count}");
                        curr = bookings[i].GetCustomerName();
                        count = 1;
                    }
                }
                //ProcessBreakFile(curr, count);
                outFile.WriteLine($"{curr}: \t {count}");

                outFile.Close();
            }
        }

        public void ProcessBreak(ref string curr, ref int count, Booking newBooking){
            System.Console.WriteLine($"{curr}: \t {count}");
            curr = newBooking.GetCustomerName();
            count = 1;
        }

        public void ProcessBreak(string curr, int count){
            System.Console.WriteLine($"{curr}: \t {count}");
        }

        public void ProcessBreakFile(ref string curr, ref int count, Booking newBooking){
            System.Console.WriteLine($"{curr}: \t {count}");
            curr = newBooking.GetCustomerName();
            count = 1;
        }

        public void ProcessBreakFile(string curr, int count){
            System.Console.WriteLine($"{curr}: \t {count}");
        }

        // public void RevenueByMonthAndYear(){
        //     int currMonth = bookings[0].GetMonth();
        //     int currYear = bookings[0].GetYear();
        //     int count = 1;
        //     int revTotal = 0;

        //     System.Console.WriteLine();
        //     System.Console.WriteLine(currMonth);

        //     for (int i = 0; i < Booking.GetCount(); i++){
        //         if (currYear == bookings[i].GetYear()){
        //             count++; //placeholder
        //             if (currMonth == bookings[i].GetMonth()){
        //                 count++; //placeholder
        //                 if (bookings[i].GetStatus() == "completed"){
        //                     System.Console.WriteLine(bookings[i].ToStringFormatted());
        //                     System.Console.WriteLine(bookings[i].GetCost());
        //                     revTotal += bookings[i].GetCost();
        //                 }
        //             } else ProcessMonthBreak(ref revTotal, bookings[i], ref currMonth);
        //         } //else ProcessYearBreak();

        //     }

        // }

        public void RevenueByYear(){
            int currYear = bookings[0].GetYear();
            int revYearTotal = bookings[0].GetCost();

            System.Console.WriteLine();
            System.Console.WriteLine(currYear.ToString());

            //System.Console.WriteLine(bookings[0].ToStringFormatted());

            for (int i = 1; i < Booking.GetCount(); i++){
                if (currYear == bookings[i].GetYear() && bookings[i].GetStatus() == "completed"){
                    // System.Console.WriteLine(bookings[i].ToStringFormatted());
                    // System.Console.WriteLine($"${bookings[i].GetCost()} \n");
                    revYearTotal += bookings[i].GetCost();

                } else ProcessYearBreak(ref revYearTotal, bookings[i], ref currYear);

            }
            ProcessYearBreak(currYear, revYearTotal);
        }
        public void RevenueByMonth(){
            //int currYear = bookings[0].GetYear();
            int currMonth = bookings[0].GetMonth();
            //int revYearTotal = bookings[0].GetCost();
            int revMonthTotal = bookings[0].GetCost();

            System.Console.WriteLine();
            //System.Console.WriteLine(currYear.ToString());
            System.Console.WriteLine("Month- " + currMonth.ToString());

            //System.Console.WriteLine(bookings[0].ToStringFormatted());

            for (int i = 1; i < Booking.GetCount(); i++){
                if (currMonth == bookings[i].GetMonth() && bookings[i].GetStatus() == "completed"){
                    // System.Console.WriteLine(bookings[i].ToStringFormatted());
                    // System.Console.WriteLine($"${bookings[i].GetCost()} \n");
                    revMonthTotal += bookings[i].GetCost();

                    // if(currMonth == bookings[i].GetMonth()){
                    //     revMonthTotal += bookings[i].GetCost();
                    // } else ProcessMonthBreak(ref revMonthTotal, bookings[i], ref currMonth);

                } else{
                    ProcessMonthBreak(ref revMonthTotal, bookings[i], ref currMonth);
                } 

            }
            // ProcessYearBreak(currYear, revYearTotal);
            ProcessMonthBreak(currMonth, revMonthTotal);
        }

        public void RevenueByMonthAndYear(){
            int currYear = bookings[0].GetYear();
            int currMonth = bookings[0].GetMonth();
            int revYearTotal = bookings[0].GetCost();
            int revMonthTotal = bookings[0].GetCost();

            System.Console.WriteLine();
            System.Console.WriteLine(currYear.ToString());
            System.Console.WriteLine(currMonth.ToString());

            //System.Console.WriteLine(bookings[0].ToStringFormatted());

            for (int i = 1; i < Booking.GetCount(); i++){
                if (currMonth == bookings[i].GetMonth() && bookings[i].GetStatus() == "completed"){
                    // System.Console.WriteLine(bookings[i].ToStringFormatted());
                    // System.Console.WriteLine($"${bookings[i].GetCost()} \n");
                    revMonthTotal += bookings[i].GetCost();

                    // if(currMonth == bookings[i].GetMonth()){
                    //     revMonthTotal += bookings[i].GetCost();
                    // } else ProcessMonthBreak(ref revMonthTotal, bookings[i], ref currMonth);

                    if (currYear == bookings[i].GetYear()){
                        revYearTotal += bookings[i].GetCost();
                    } else ProcessYearBreak(ref revYearTotal, bookings[i], ref currYear);

                } else{
                    ProcessMonthBreak(ref revMonthTotal, bookings[i], ref currMonth);
                } 

            }
            // ProcessYearBreak(currYear, revYearTotal);
            ProcessMonthBreak(currMonth, revMonthTotal);
        }


        public void ProcessMonthBreak(ref int revMonthTotal, Booking newBooking, ref int currMonth){
            //System.Console.WriteLine(newBooking.ToStringFormatted());

            System.Console.WriteLine($"Monthy Revenue: ${revMonthTotal}");

            currMonth = newBooking.GetMonth();
            revMonthTotal = newBooking.GetCost();

            System.Console.WriteLine("Month- " + currMonth.ToString());
        }

        public void ProcessMonthBreak(int currMonth, int revMonthTotal){
            System.Console.WriteLine($"Monthly Revenue: ${revMonthTotal}");
        }
        public void ProcessYearBreak(ref int revYearTotal, Booking newBooking, ref int currYear){
            //System.Console.WriteLine(newBooking.ToStringFormatted());
            System.Console.WriteLine($"Yearly Revenue: ${revYearTotal}\n");
            revYearTotal = newBooking.GetCost();


            currYear = newBooking.GetYear();

            System.Console.WriteLine(currYear.ToString());
        }

        public void ProcessYearBreak(int currYear,int revYearTotal){
            System.Console.WriteLine($"Yearly Revenue: ${revYearTotal}\n");
        }


    }
}