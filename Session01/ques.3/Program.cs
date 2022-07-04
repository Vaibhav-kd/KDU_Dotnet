//Write a program to check if the string is a palindrome

Console.WriteLine("Enter a string: ");
string s= Console.ReadLine();
int length = s.Length;
int check=0;
for (int i = 0; i < length / 2; i++)
{
    if (s[i] != s[length - i - 1]){
        check=1;
        Console.WriteLine("String is not palindrome") ;
        break;
    }
}
if(check==0)
    Console.WriteLine("String is a palindrome");

