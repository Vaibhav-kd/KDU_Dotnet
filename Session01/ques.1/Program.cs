/*Write a program to generate the following series:
1, 4, 7, 12, 23, 42, 77, ... N
1, 4, 9, 25, 36, 49, 81, 100, ... N
1, 5, 13, 29, 49, 77, ... N */


// Series :1
int n=12;

Console.WriteLine("Series1:");
int a0=1 ,
    a1=2,
    a2=1;
for(int i=1; i<=n ;i++){
    int ans= a0+a1+a2;
    a0=a1;
    a1=a2;
    a2=ans;
    Console.Write(ans+" ");
}
    Console.WriteLine();


//Series : 2     --  1 4 9 16....

Console.WriteLine("Series2:");
for(int i=1; i<=n ;i++){
    int ans= i*i;;
    Console.Write(ans+" ");
}
Console.WriteLine();


//Series : 3   --  1 5 13 29 49.....
Console.WriteLine("Series3:");
int x = 1, y=1, z=0;
  
while(y <= n+z)
  {
   if(y%3!=0)
   {
    Console.Write(x + " ");
    x = x+4*y;
   }else
    z++;
    y++; 
  }
  