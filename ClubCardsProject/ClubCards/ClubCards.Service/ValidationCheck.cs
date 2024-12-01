
namespace ClubCardsProject.Entities
{
    public static class ValidationCheck 
    {
        public static bool IsTzValid(string value) 
        { 
            if (string.IsNullOrEmpty(value) || value.Length != 9) 
                return false;
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                if (i%2==0)
                    sum+=(2* value[i]);
                else
                    sum += value[i];
            }
            if(sum>100)
                sum= sum/100+sum %10+sum /10%10;
            else 
                sum=sum/10+sum %10;
            return sum == 10;

        }
        public static bool IsEmailValid(string value)
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
