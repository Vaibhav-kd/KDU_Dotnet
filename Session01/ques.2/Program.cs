/*Write a method that takes as a parameter an integer n (n<1000) and print all the
numbers from 1 to n that are divisible by 3 (Use the test of divisibility). */

Console.WriteLine("enter a number:");
int n = Convert.ToInt32(Console.ReadLine()); 
int i=1;
while(i<=n){
    int x=i;
    int sum=0;
    while(x>0){
        sum+=x%10;
        x/=10;
    }
    if(sum%3==0)
        Console.WriteLine(i+" ");
    i++;
}