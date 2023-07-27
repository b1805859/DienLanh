namespace JLPT_API.Common
{
    public class C_Message
    {
        // ==========================INFO CODE=====================
        public const string INF00001 = "INF00001"; // Xử lý thành công
        public const string INF00002 = "INF00002"; // Chứng thực thành công
        public const string INF00003 = "INF00003"; // Không tìm thấy dữ liệu
        // ==========================INFO CODE=====================

        //  ==========================ERR CODE =====================
        public const string ERR00001 = "ERR00001"; // {$} đã tồn tại
        public const string ERR00002 = "ERR00002"; // Dữ liệu không hợp lệ".
        public const string ERR00003 = "ERR00003"; // Đăng ký dữ liệu không thành công
        public const string ERR00004 = "ERR00004"; // Xây dựng chuỗi chứng thực không thành công
        public const string ERR00005 = "ERR00005"; // Sử dụng 6 ký tự trở lên cho mật khẩu của bạn
        public const string ERR00006 = "ERR00006"; // Hết thời gian
        public const string ERR00007 = "ERR00007"; // Đã có lỗi xảy ra, vui lòng liên lạc với người quản trị ứng dụng
        public const string ERR00008 = "ERR00008"; // Không được kết nối mạng!
        public const string ERR00009 = "ERR00009"; // Email không tồn tại
        public const string ERR00010 = "ERR00010"; // Update không thành công!
        public const string ERR00011 = "ERR00011"; // E-mail hoặc mật khẩu không hợp lệ!"
	    public const string ERR00012 = "ERR00012"; // Insert không thành công!
        public const string ERR00013 = "ERR00013"; // Delete không thành công!
        // ==========================ERR CODE=====================

        public static String getMessageByID(string id)
        {
            string message = "";

            switch (id)
            {
                case ERR00001:
                    message = "{$} đã tồn tại";
                    break;
                case ERR00002:
                    message = "Dữ liệu không hợp lệ";
                    break;
                case ERR00003:
                    message = "Đăng ký dữ liệu không thành công";
                    break;
                case ERR00004:
                    message = "Xây dựng chuỗi chứng thực không thành công";
                    break;
                case ERR00005:
                    message = "Sử dụng 6 ký tự trở lên cho mật khẩu của bạn";
                    break;
                case ERR00006:
                    message = "Hết thời gian chờ";
                    break;
                case ERR00007:
                    message = "Đã có lỗi xảy ra, vui lòng liên lạc với quản trị viên";
                    break;
                case ERR00008:
                    message = "Không được kết nối mạng!";
                    break;
                case ERR00009:
                    message = "Email không tồn tại";
                    break;
                case ERR00010:
                    message = "Update không thành công!";
                    break;
                case ERR00011:
                    message = "E-mail hoặc mật khẩu không hợp lệ!";
                    break;
		        case ERR00012:
                    message = "Insert không thành công!";
                    break;
                case ERR00013:
                    message = "Delete không thành công!";
                    break;
                case INF00001:
                    message = "Success";
                    break;
                case INF00002:
                    message = "Authenticated";
                    break;
                case INF00003:
                    message = "Data Not Found";
                    break;
            }

            return message;
    }
    }
}