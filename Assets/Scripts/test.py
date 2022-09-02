def main():
    
    #Propmt user to type 2 digets that fit criteria
    do{
        num1 = int(input('Enter a 2 didget number:'))
    }
    while(num1 > 99 or num1 <9):

    #Verify if number is 2 didgets
    if num1 > 9 and num1 < 99:
        num2 = int(input('Enter a DIFFERENT 2 didget number:'))
    else:
        print('Something is wrong with the first input. Try again')


    #Create a difference formula
    if num1 > num2:
        dif = (num1 - num2)
    else:
        dif = (num2 - num1)

    #Create a way to keep the larger number in front
    if num1 > num2:
        numbig = num1
        numsmall = num2
    else:
        numbig = num2
        numsmall = num1 


                #Prompt for the second integer
    if num2 > 9 and num1 < 99 and num1 != num2:
        print(f'{numbig} is bigger than {numsmall} by {dif}')
    else:
        print('Something is wrong with the second input. Try again')