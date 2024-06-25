using ModelEFCore;

namespace BlogHelper
{
    public class GenerateToken
    {
        public string LoginToken(Account account)
        {
            // 定义 token
            string token = "";
            // 获取当前日期和时间
            DateTime now = DateTime.Now;
            // 拼接年月日时分秒 ("%02d" 转换为两位数的字符串)
            string dataTimeString = now.Year.ToString() +
                                     now.Month.ToString("00") +
                                     now.Day.ToString("00") +
                                     now.Hour.ToString("00") +
                                     now.Minute.ToString("00") +
                                     now.Second.ToString("00");

            Random random = new Random();
            // 随机生成5位数
            int randomNumber = random.Next(10000, 99999);
            string randomNum = randomNumber.ToString();
            // 拼接 token
            token = dataTimeString + account.User_Name + randomNum;
            return token;
        }
    }

}
