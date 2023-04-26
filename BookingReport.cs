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

            System.Console.WriteLine("What was your email?");
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
        }

        public void SessionsPerCustomer(){
            string curr = bookings[0].GetCustomerName();
            int count = 1;
            for (int i = 0; i < Booking.GetCount(); i++){
                if (bookings[i].GetCustomerName() == curr){
                    count ++;
                } else {
                    ProcessBreak(ref curr, ref count, bookings[i]);
                }
            }
            ProcessBreak(curr, count);
        }

        public void ProcessBreak(ref string curr, ref int count, Booking newBooking){
            System.Console.WriteLine($"{curr}: \t {count}");
            curr = newBooking.GetCustomerName();
            count = 1;
        }

        public void ProcessBreak(string curr, int count){
            System.Console.WriteLine($"{curr}: \t {count}");
        }


    }
}