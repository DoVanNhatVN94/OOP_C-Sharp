namespace OOP {
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        // Vì đã gọi contructor có tham số nên sẽ ko tự động tạo contructor ko tham số nữa, nếu tạo instance bằng contructor ko tham số sẽ báo lỗi 
        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Notes = note;
        }

        public void ShowTransaction() {
            Console.WriteLine("Amount: {0}, Date: {1}, Notes: {2}",Amount,Date,Notes);   
        }
    }
}

