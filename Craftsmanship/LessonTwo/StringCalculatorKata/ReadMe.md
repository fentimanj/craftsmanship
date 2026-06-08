# StringCalculatorKata
String calculator kata - part I

1- Create a string calculator with a method int Add(string numbers)
The method can take 0, 1 or 2 numbers comma separated and will return their sum.
For an empty string it has to return 0. For example “” will return 0, “1” will return 1 and
“1,2” will return 3.

2- Allow the Add method to handle an undefined amount of numbers

3- Allow the Add method to handle also new lines as separator.
For example “1\n2,3” will return 6, but “1,\n2” is not a valid input

4- Support different delimiters. To setup the delimiter prefix the input with double
forward slash [“//”] followed by the delimiter and “\n”. Example: “//;\n1\n2;3” will return
6

5- Throw “negatives not allowed” exception with the list of negative numbers found
when input contains any negative number

