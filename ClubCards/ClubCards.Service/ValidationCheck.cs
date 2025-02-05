
namespace ClubCardsProject.Entities
{
    public static class ValidationCheck 
    {
        public static bool IsTzValid( this string value) 
        { 
            // בדיקה ראשונית: האם המספר קיים באורך הנכון
            if (string.IsNullOrEmpty(value) || value.Length != 9)
                return false;

            int sum = 0;

            // חישוב ספרת הביקורת
            for (int i = 0; i < 9; i++)
            {
                // המרת תווים למספרים
                int digit = value[i] - '0';

                // הכפלה לסירוגין
                int multiplied = (i % 2 == 0) ? digit : digit * 2;

                // אם התוצאה דו-ספרתית, חיבור ספרותיה
                if (multiplied > 9)
                    multiplied = (multiplied / 10) + (multiplied % 10);

                // הוספת התוצאה לסכום הכללי
                sum += multiplied;
            }

            // המספר חוקי אם השארית של החלוקה ב-10 היא 0
            return (sum % 10 == 0);
        }
        public static bool IsEmailValid(this string value)
        {
            if (value == null)
                return false;
            int x = value.IndexOf('@');
            int y = value.LastIndexOf('.');
            if ( x!= -1 &&y!= -1&&y>x)
                return true;
            return false;
        }
    }
}
