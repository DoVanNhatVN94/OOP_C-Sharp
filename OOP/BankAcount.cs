using System;
using System.Text;

namespace OOP
{
	public class BankAcount
	{
		// static là biết tĩnh được thiết lập sẵn trong quá trình comblie, có thẻ truy suất từ class hoặc instance, các method, nó ko bị thiết lặt lại cho đến khi app hoặc chương trình đóng hoặc restart
		public static int accountNumberSeed = 1234567890;
		
		// Hỗ trợ tính bao đóng
		//property
		public string Number {
            //accesor chỉ hỗ trợ gọi, ko thể thay đổi gia tri
            get;
		}
		//emet: prop + tab cho phép gõ nanh cú pháp khai báo
		public string Owner { get; set; }
		public decimal Balance { get
			{
				//Mỗi khi đc gọi, nó sẽ trả về kết quả tính toán giữa các giao dịch , ko bị tác động hay thay đổi trực t bởi các vấn đề bên ngoài
				decimal balance = 0;
				foreach (var item in allTransactions) {
					balance += item.Amount;
				}
				return balance;
			}
				}
		// Tạo list các giao dịch
		private List<Transaction> allTransactions = new List<Transaction>();


		// COntructor
		// Nếu ko khai báo bất kỳ contructor() ko tham số nào, nó sẽ tự mặc định tạo và gọi khi instance đc khởi tạo

		//Overload : Cho phép khai báo một số contructor cùng tên hay method nhưng khác về số lượng tham số, hay type tham số 
		public BankAcount() { }

        public BankAcount(string name,decimal initaBalance )
	     {
			//Nếu ko có biến hay tham số nào trùng tên với properties hay accesor của class có thể ko cần biến this 
			Owner = name;
			//Vì accesor gán chỉ get nên ko set giá trị trong contructor được
			//Balance = initaBalance;

			//khi tài khoản đc tạo, với với số tiền khởi tạo sẽ đc sữ dụng trong phương thức gữi tiền
			MakeDeposit(initaBalance, DateTime.Now, "Initial Balace");

			Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }


        //Method gữi tiền
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
			//số tiền ko đc âm
            if (amount <= 0)
            {
				// Throw ra một ngoại lệ
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
		//lấy tiền
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            var withdrawal = new Transaction(-amount, date, note);
			//thêm giao dịch vào list quản lý
            allTransactions.Add(withdrawal);
        }
        public void ShowInfor() {
			Console.WriteLine("Acount {0}\nOwner : {1} \nBalance: {2}",Number, Owner, Balance);
		}

		public string ShowAllTranssaction() {

			var report = new StringBuilder();
			//tạo một header
			report.AppendLine("--------------------\nDate\tAmmount\tNote");
			foreach (var item in allTransactions)
			{
				// các dòng
				report.AppendLine($"{item.Date},{item.Amount},{item.Notes}");
			}
			return report.ToString();
		}
	}	
}

/*
 * Đặc tả:
 File này sẽ chứa định nghĩa của một tài khoản ngân hàng. Lập trình hướng đối tượng tổ chức mã thông qua việc tạo các loại dữ liệu dưới dạng lớp. Các lớp này chứa mã thể hiện một thực thể cụ thể. Lớp BankAccount đại diện cho một tài khoản ngân hàng. Mã thực hiện các hoạt động cụ thể thông qua các phương thức và thuộc tính. Trong bài hướng dẫn này, tài khoản ngân hàng hỗ trợ các hành vi sau:

Nó có một số có 10 chữ số để duy nhất xác định tài khoản ngân hàng.
Nó có một chuỗi lưu trữ tên hoặc các tên của các chủ sở hữu.
Số dư có thể được lấy.
Nó chấp nhận khoản gửi tiền.
Nó chấp nhận rút tiền.
Số dư ban đầu phải là dương.
Các khoản rút tiền không được dẫn đến số dư âm.



 */